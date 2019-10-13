import { Injectable } from '@angular/core';
import { delay } from 'q';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { catchError } from 'rxjs/operators';

import { Identifier } from './identifier-history-entry';
import { IdentifierHistoryEntry } from './identifier';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class IdentifierDataService {

  constructor(private httpClient: HttpClient) { }

  private combineUrl(resourceAddress: string): string {
    let apiUrlTemplate = 'http://localhost:5000/api/{resource}';
    let url = apiUrlTemplate.replace('{resource}', resourceAddress);

    return url;
  }

  getIdentifiers(): Observable<Identifier[]> {
    let url = this.combineUrl('identifier');

    return this.httpClient.get<Identifier[]>(url).pipe(
      catchError((error: HttpErrorResponse) => throwError(error))
    );
  }

  getIdentifierHistory(factoryCode: string, categoryCode: string): Observable<IdentifierHistoryEntry[]> {
    let url = this.combineUrl(`identifier/${factoryCode}/${categoryCode}`);

    return this.httpClient.get<IdentifierHistoryEntry[]>(url).pipe(
      catchError((error: HttpErrorResponse) => throwError(error))
    );
  }

  generateNewIdentifier(factoryCode: string, categoryCode: string): Observable<any> {
    let url = this.combineUrl(`identifier/${factoryCode}/${categoryCode}`);

    return this.httpClient.post(url, {}, { responseType: 'text' }).pipe(
      catchError((error: HttpErrorResponse) => throwError(error))
    );
  }
}
