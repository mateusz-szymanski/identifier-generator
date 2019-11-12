#/bin/bash
set -x
set -e

zoneName="example-zone"
zoneDns="example-zone.com"
appName="identifier-generator.example-zone.com"
apiName="api.identifier-generator.example-zone.com"

pushd ..

set +e
docker image rm \
    eu.gcr.io/identifier-generator/nginx-ng:initial \
    eu.gcr.io/identifier-generator/webapi:initial \
    eu.gcr.io/identifier-generator/tools-create-db-user:initial \
    eu.gcr.io/identifier-generator/tools-ef-migrate-database:initial
set -e

docker build \
    -t eu.gcr.io/identifier-generator/webapi:initial \
    -f ./IdentifierGenerator.WebApi/Dockerfile .
docker build \
    -t eu.gcr.io/identifier-generator/nginx-ng:initial \
    -f ./IdentifierGenerator.Web.Angular/Dockerfile .
docker build \
    -t eu.gcr.io/identifier-generator/tools-create-db-user:initial \
    -f ./InfraAsCode/create-db-user/Dockerfile .
docker build \
    -t eu.gcr.io/identifier-generator/tools-ef-migrate-database:initial \
    -f ./InfraAsCode/ef-migrate-database/Dockerfile .

docker push eu.gcr.io/identifier-generator/nginx-ng:initial
docker push eu.gcr.io/identifier-generator/webapi:initial
docker push eu.gcr.io/identifier-generator/tools-create-db-user:initial
docker push eu.gcr.io/identifier-generator/tools-ef-migrate-database:initial

popd

gcloud compute addresses create web-static-ip --global
staticIp=$(gcloud compute addresses list --format="value(address)")

gcloud dns managed-zones create $zoneName \
    --dns-name=$zoneDns \
    --description="" \
    --visibility=public


gcloud dns record-sets transaction start --zone=$zoneName

gcloud dns --project=identifier-generator record-sets transaction add $staticIp \
    --name=$appName \
    --ttl=300 \
    --type=A \
    --zone=$zoneName
gcloud dns --project=identifier-generator record-sets transaction add $staticIp \
    --name=$apiName \
    --ttl=300 \
    --type=A \
    --zone=$zoneName

gcloud dns --project=identifier-generator record-sets transaction execute --zone=$zoneName

kubectl create namespace identifier-generator

helm install identifier-generator-helm ./identifier-generator \
    #--namespace identifier-generator \
    --set namespace=identifier-generator
    --set dockerTag=initial \
    --set webapiHost=$apiName \
    --set webHost=$apiName

dnsDomains=$(gcloud dns record-sets list --zone example-zone --filter="type=ns" --format="value(DATA)")

set +x

echo

echo =========
echo "You can resolve application address $appName using one of the nameservers: "
echo ${dnsDomains}
echo =========