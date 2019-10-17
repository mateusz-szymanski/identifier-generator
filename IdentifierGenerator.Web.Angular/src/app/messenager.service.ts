import { Injectable } from '@angular/core';
import { ReplaySubject } from 'rxjs';
import { Identifier } from './identifier';

@Injectable({
  providedIn: 'root'
})
export class MessenagerService {
  private identifierAddedBehaviourSubject: ReplaySubject<Identifier> = new ReplaySubject<Identifier>(1);
  public identifierAddedMessage = this.identifierAddedBehaviourSubject.asObservable();

  public identifierAdded(identifier: Identifier) {
    this.identifierAddedBehaviourSubject.next(identifier);
  }

  constructor() { }
}
