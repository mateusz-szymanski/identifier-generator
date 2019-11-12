# gcloud container clusters get-credentials gcloud-standard-cluster
kubectl create namespace identifier-generator-devops
kubectl create serviceaccount -n identifier-generator-devops azure-pipelines-deploy
kubectl create clusterrolebinding azure-pipelines-deploy --clusterrole=cluster-admin --serviceaccount=identifier-generator-devops:azure-pipelines-deploy

kubectl get -n identifier-generator-devops secret $(kubectl get -n identifier-generator-devops serviceaccounts azure-pipelines-deploy -o custom-columns=":secrets[0].name") -o yaml
