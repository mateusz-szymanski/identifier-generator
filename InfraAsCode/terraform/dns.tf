resource "google_dns_managed_zone" "dns_zone" {
  name     = var.zone_dns
  dns_name = var.zone_dns
}

resource "google_compute_global_address" "static_ip" {
  name = var.load_balancer_static_ip_name
}

resource "google_dns_record_set" "dns_record_app" {
  name = "${var.application_instance_name}.${google_dns_managed_zone.dns_zone.dns_name}"
  type = "A"
  ttl  = 300

  managed_zone = google_dns_managed_zone.dns_zone.name
  rrdatas      = [google_compute_global_address.static_ip.address]
}

resource "google_dns_record_set" "dns_record_api" {
  name = "api.${var.application_instance_name}.${google_dns_managed_zone.dns_zone.dns_name}"
  type = "A"
  ttl  = 300

  managed_zone = google_dns_managed_zone.dns_zone.name
  rrdatas      = [google_compute_global_address.static_ip.address]
}
