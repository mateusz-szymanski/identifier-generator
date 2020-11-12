import { TestBed } from '@angular/core/testing';
import { MessenagerService } from './messenager.service';

describe('MessenagerService', () => {
  beforeEach(() => TestBed.configureTestingModule({ providers: [MessenagerService] }));

  it('should be created', () => {
    const service: MessenagerService = TestBed.get(MessenagerService);
    expect(service).toBeTruthy();
  });

  it('should trigger identifierAddedMessage once identifier added', () => {
    const service: MessenagerService = TestBed.get(MessenagerService);

    const identifier = {
      factoryCode: 'F001',
      categoryCode: 'C001',
      value: 1
    };

    let triggerCounter = 0;

    service.identifierAddedMessage.subscribe((localIdentifier) => {
      expect(localIdentifier).toBe(identifier);
      triggerCounter++;
    });
    service.identifierAdded(identifier);

    expect(triggerCounter).toBe(1);
  });
});
