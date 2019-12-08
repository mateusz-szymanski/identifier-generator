#!/bin/bash

set -x
set -e

kubernetesNamespace="identifier-generator"
applicationInstanceName="identifier-generator"
zoneName="example-zone"
zoneDns="example-zone.com"
appName="${applicationInstanceName}.${zoneDns}"
apiName="api.${appName}"
imageTag="initial"

pushd ..
solutionCatalog="$PWD";
popd

terraformCatalog="${solutionCatalog}/InfraAsCode/terraform"
helmCatalog="${solutionCatalog}/InfraAsCode/k8s"
workingCatalog="${solutionCatalog}/AutomatedTestsWorkCatalog"

rm -rf $workingCatalog
mkdir -p $workingCatalog

pushd $solutionCatalog

set +e
docker image rm \
    eu.gcr.io/identifier-generator/nginx-ng:${imageTag} \
    eu.gcr.io/identifier-generator/webapi:${imageTag} \
    eu.gcr.io/identifier-generator/tools-create-db-user:${imageTag} \
    eu.gcr.io/identifier-generator/tools-ef-migrate-database:${imageTag}
set -e

docker build \
    -t eu.gcr.io/identifier-generator/webapi:${imageTag} \
    -f ./IdentifierGenerator.WebApi/Dockerfile .
docker build \
    -t eu.gcr.io/identifier-generator/nginx-ng:${imageTag} \
    -f ./IdentifierGenerator.Web.Angular/Dockerfile .
docker build \
    -t eu.gcr.io/identifier-generator/tools-create-db-user:${imageTag} \
    -f ./InfraAsCode/tools-dockerfiles/create-db-user/Dockerfile .
docker build \
    -t eu.gcr.io/identifier-generator/tools-ef-migrate-database:${imageTag} \
    -f ./InfraAsCode/tools-dockerfiles/ef-migrate-database/Dockerfile .

docker push eu.gcr.io/identifier-generator/nginx-ng:${imageTag}
docker push eu.gcr.io/identifier-generator/webapi:${imageTag}
docker push eu.gcr.io/identifier-generator/tools-create-db-user:${imageTag}
docker push eu.gcr.io/identifier-generator/tools-ef-migrate-database:${imageTag}

popd

pushd $workingCatalog

terraform init $terraformCatalog
terraform plan \
    -var "credentials_file=$terraformCatalog/gcloud-credentials-identifier-generator.json" \
    -var "application_instance_name=$applicationInstanceName" \
    -var "zone_dns_name=$zoneName" \
    -var "zone_dns=${zoneDns}." \
    -var "load_balancer_static_ip_name=load-balancer-static-ip" \
    -out=plan \
    $terraformCatalog

terraform apply plan

kubectl --kubeconfig $workingCatalog/kube.config create namespace $kubernetesNamespace

helm --kubeconfig $workingCatalog/kube.config install identifier-generator-helm $helmCatalog/identifier-generator \
    --set namespace=$kubernetesNamespace \
    --set dockerTag=${imageTag} \
    --set webapiHost=$apiName \
    --set webHost=$appName

# # TODO
# pushd ../../../IdentifierGenerator.Web.Angular

# ng e2e

# popd

terraform destroy \
    -var "credentials_file=$terraformCatalog/gcloud-credentials-identifier-generator.json" \
    -var "application_instance_name=$applicationInstanceName" \
    -var "zone_dns_name=$zoneName" \
    -var "zone_dns=${zoneDns}." \
    -var "load_balancer_static_ip_name=load-balancer-static-ip" \
    -auto-approve \
    $terraformCatalog

popd
