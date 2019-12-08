variable "credentials_file" {
  type        = string
  description = "Path to file with gcloud credentials"
}

variable "application_instance_name" {
  type        = string
  description = "For building address application address: {application_instance_name}.{zone-dns}, eg. identifier-generator-beta.example.com"
}

variable "zone_dns" {
  type        = string
  description = "For building address application address: {application_instance_name}.{zone-dns}, eg. identifier-generator-beta.example.com"
}

variable "zone_dns_name" {
  type        = string
  description = "Name for dns zone resource"
}

variable "load_balancer_static_ip_name" {
  type        = string
  description = "Name of static ip resource - to be used in kubernetes load balancer annotation"
}
