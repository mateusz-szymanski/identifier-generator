import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, Resolve, RouterStateSnapshot } from '@angular/router';
import { Observable, of } from 'rxjs';
import { mergeMap, take } from 'rxjs/operators';
import { Identifier } from '../model/identifier';
import { IdentifierDataService } from '../model/identifier-data-service';

@Injectable({
  providedIn: 'root'
})
export class IdentifierListResolverService implements Resolve<Identifier[]> {
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<Identifier[]> | Observable<never> {
    return this.identifierDataService.getIdentifiers()
      .pipe(take(1), mergeMap(data => of(data)));
  }

  constructor(private identifierDataService: IdentifierDataService) { }
}
