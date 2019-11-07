#/bin/bash
set -x
set -e

zoneName="example-zone"
zoneDns="example-zone.com"
appName="identifier-generator.example-zone.com."
apiName="api.identifier-generator.example-zone.com."

pushd ..

docker image rm \
    eu.gcr.io/identifier-generator/nginx-ng eu.gcr.io/identifier-generator/webapi \
    eu.gcr.io/identifier-generator/tools-create-db-user \
    eu.gcr.io/identifier-generator/tools-ef-migrate-database

docker build -t eu.gcr.io/identifier-generator/webapi \
    -f ./IdentifierGenerator.WebApi/Dockerfile .
docker build -t eu.gcr.io/identifier-generator/nginx-ng \
    -f ./IdentifierGenerator.Web.Angular/Dockerfile .
docker build -t eu.gcr.io/identifier-generator/tools-create-db-user \
    -f ./InfraAsCode/create-db-user/Dockerfile ./InfraAsCode/create-db-user
docker build -t eu.gcr.io/identifier-generator/tools-ef-migrate-database \
    -f ./InfraAsCode/ef-migrate-database/Dockerfile .

docker push eu.gcr.io/identifier-generator/nginx-ng
docker push eu.gcr.io/identifier-generator/webapi
docker push eu.gcr.io/identifier-generator/tools-create-db-user
docker push eu.gcr.io/identifier-generator/tools-ef-migrate-database

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

kubectl apply -f identifier-generator.secrets.yaml -f sqldb.statefulset.yaml -f sqldb.service.yaml -f sqldb.create-user.job.yaml -f webapi.ef-migrate-database.job.yaml -f webapi.deployment.yaml -f webapi.loadbalancer.yaml -f nginx-ng.configmap.yaml -f nginx-ng.deployment.yaml -f nginx-ng.loadbalancer.yaml -f identifier-generator.ingress.yaml

dnsDomains=$(gcloud dns record-sets list --zone example-zone --filter="type=ns" --format="value(DATA)")

set +x

echo

echo =========
echo "You can resolve application address $appName using one of the nameservers: "
echo ${dnsDomains}
echo =========