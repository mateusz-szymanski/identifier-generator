import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentifierHistoryComponent } from './identifier-history.component';

describe('IdentifierHistoryComponent', () => {
  let component: IdentifierHistoryComponent;
  let fixture: ComponentFixture<IdentifierHistoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IdentifierHistoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdentifierHistoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
