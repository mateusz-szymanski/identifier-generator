import { TestBed } from '@angular/core/testing';

import { MessenagerService } from './messenager.service';

describe('MessenagerService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: MessenagerService = TestBed.get(MessenagerService);
    expect(service).toBeTruthy();
  });
});
