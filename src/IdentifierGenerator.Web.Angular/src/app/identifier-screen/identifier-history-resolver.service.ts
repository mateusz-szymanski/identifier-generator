import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, Router, RouterStateSnapshot } from '@angular/router';
import { EMPTY, Observable, of } from 'rxjs';
import { mergeMap, take } from 'rxjs/operators';
import { IdentifierDataService } from '../model/identifier-data-service';
import { IdentifierHistoryEntry } from '../model/identifier-history-entry';

@Injectable({
  providedIn: 'root'
})
export class IdentifierHistoryResolverService implements Resolve<IdentifierHistoryEntry[]> {
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<IdentifierHistoryEntry[]> | Observable<never> {

    const factoryCode = route.paramMap.get('factoryCode');
    const categoryCode = route.paramMap.get('categoryCode');

    return this.identifierDataService.getIdentifierHistory(factoryCode, categoryCode)
      .pipe(take(1),
        mergeMap(data => {
          if (data.length > 0) {
            return of(data);
          } else {
            this.router.navigate(['/']);
            return EMPTY;
          }
        }));
  }

  constructor(private identifierDataService: IdentifierDataService, private router: Router) { }
}
