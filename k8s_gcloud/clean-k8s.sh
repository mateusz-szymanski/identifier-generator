#/bin/bash
set -x

zoneName="example-zone"
zoneDns="example-zone.com"
appName="identifier-generator.example-zone.com."
apiName="api.identifier-generator.example-zone.com."

helm uninstall identifier-generator-helm \ 
    --set namespace=identifier-generator
    # --namespace identifier-generator

kubectl delete namespace identifier-generator

staticIp=$(gcloud compute addresses list --format="value(address)")

gcloud dns record-sets transaction start --zone=$zoneName

gcloud dns --project=identifier-generator record-sets transaction remove \
    --name=$appName \
    --ttl=300 \
    --type=A \
    --zone=$zoneName \
    $staticIp
gcloud dns --project=identifier-generator record-sets transaction remove \
    --name=$apiName \
    --ttl=300 \
    --type=A \
    --zone=$zoneName \
    $staticIp

gcloud dns --project=identifier-generator record-sets transaction execute --zone=$zoneName

gcloud dns managed-zones delete $zoneName

gcloud compute addresses delete web-static-ip --global --quiet

gsutil rm -r gs://eu.artifacts.identifier-generator.appspot.com/
