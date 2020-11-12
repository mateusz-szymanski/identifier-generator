import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Identifier } from './identifier';
import { IdentifierHistoryEntry } from './identifier-history-entry';
import { AppConfigurationService } from '../app-configuration.service';

@Injectable({
  providedIn: 'root'
})
export class IdentifierDataService {

  constructor(private httpClient: HttpClient, private appConfigurationService: AppConfigurationService) { }

  private combineUrl(resourceAddress: string): string {
    const apiUrl = this.appConfigurationService.getConfig().apiUrl;
    const apiUrlTemplate = `${apiUrl}/api/{resource}`;
    const url = apiUrlTemplate.replace('{resource}', resourceAddress);

    return url;
  }

  getIdentifiers(): Observable<Identifier[]> {
    const url = this.combineUrl('identifier');

    return this.httpClient.get<Identifier[]>(url).pipe(
      catchError((error: HttpErrorResponse) => throwError(error))
    );
  }

  getIdentifierHistory(factoryCode: string, categoryCode: string): Observable<IdentifierHistoryEntry[]> {
    const url = this.combineUrl(`identifier/${factoryCode}/${categoryCode}`);

    return this.httpClient.get<IdentifierHistoryEntry[]>(url).pipe(
      catchError((error: HttpErrorResponse) => throwError(error))
    );
  }

  generateNewIdentifier(factoryCode: string, categoryCode: string): Observable<any> {
    const url = this.combineUrl(`identifier/${factoryCode}/${categoryCode}`);

    return this.httpClient.post(url, {}, { responseType: 'text' }).pipe(
      catchError((error: HttpErrorResponse) => throwError(error))
    );
  }
}
