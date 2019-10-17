import { Injectable } from '@angular/core';
import { IdentifierHistoryEntry } from './identifier-history-entry';
import { Resolve, RouterStateSnapshot, ActivatedRouteSnapshot, Router } from '@angular/router';
import { Observable, of, EMPTY } from 'rxjs';
import { IdentifierDataService } from './identifier-data-service';
import { mergeMap, take } from 'rxjs/operators';


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
