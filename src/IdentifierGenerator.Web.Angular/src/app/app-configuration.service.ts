import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AppConfigurationService {
  private configuration;

  constructor(private http: HttpClient) { }

  loadConfiguration() {
    return this.http.get('/assets/applicationConfiguration.json')
      .toPromise()
      .then(data => {
        this.configuration = data;
      });
  }

  getConfig() {
    return this.configuration;
  }
}
