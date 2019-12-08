provider "google" {
  credentials = file(var.credentials_file)
  project     = "identifier-generator"
  region      = "europe-west1"
  zone        = "europe-west1-b"
}
