resource "google_container_cluster" "k8s_cluster" {
  name                     = "integration-tests-cluster"
  description              = "Used for running automated tests during CI"
  location                 = "europe-west1-b"
  enable_kubernetes_alpha  = true
  min_master_version       = "1.14.8-gke.17"
  remove_default_node_pool = true
  initial_node_count       = 1

  master_auth {
    username = ""
    password = ""

    client_certificate_config {
      issue_client_certificate = false
    }
  }

  provisioner "local-exec" {
    command = "KUBECONFIG='./kube.config' gcloud container clusters get-credentials ${google_container_cluster.k8s_cluster.name} --zone  ${google_container_cluster.k8s_cluster.location}"
  }
}

resource "google_container_node_pool" "cluster_nodes" {
  name       = "integration-tests-cluster-nodes"
  location   = "europe-west1-b"
  cluster    = google_container_cluster.k8s_cluster.name
  node_count = 3

  node_config {
    preemptible  = true
    machine_type = "n1-standard-1"

    metadata = {
      disable-legacy-endpoints = "true"
    }

    oauth_scopes = [
      "https://www.googleapis.com/auth/logging.write",
      "https://www.googleapis.com/auth/monitoring",
    ]
  }
}