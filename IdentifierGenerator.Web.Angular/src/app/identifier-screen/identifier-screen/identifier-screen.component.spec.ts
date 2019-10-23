import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentifierScreenComponent } from './identifier-screen.component';

describe('IdentifierScreenComponent', () => {
  let component: IdentifierScreenComponent;
  let fixture: ComponentFixture<IdentifierScreenComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IdentifierScreenComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdentifierScreenComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
