# gcloud container clusters get-credentials gcloud-standard-cluster
kubectl create namespace identifier-generator
kubectl create serviceaccount -n identifier-generator azure-pipelines-deploy
kubectl create clusterrolebinding azure-pipelines --clusterrole=cluster-admin --serviceaccount=identifier-generator:azure-pipelines-deploy

kubectl get -n identifier-generator secret $(kubectl get -n identifier-generator serviceaccounts azure-pipelines-deploy -o custom-columns=":secrets[0].name") -o yaml
