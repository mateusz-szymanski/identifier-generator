import { Injectable } from '@angular/core';
import { Identifier } from './identifier-history-entry';
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { IdentifierDataService } from './identifier-data-service';
import { take, mergeMap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class IdentifierListResolverService implements Resolve<Identifier[]>{
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Identifier[]> | Observable<never> {
    return this.identifierDataService.getIdentifiers()
      .pipe(take(1), mergeMap(data => of(data)));
  }

  constructor(private identifierDataService: IdentifierDataService) { }
}
