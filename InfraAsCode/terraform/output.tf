output "app_ip" {
  value = google_compute_global_address.static_ip.address
}
output "app_url" {
  value = google_dns_record_set.dns_record_app.name
}
output "api_url" {
  value = google_dns_record_set.dns_record_api.name
}
output "dns" {
  value = google_dns_managed_zone.dns_zone.name_servers
}
