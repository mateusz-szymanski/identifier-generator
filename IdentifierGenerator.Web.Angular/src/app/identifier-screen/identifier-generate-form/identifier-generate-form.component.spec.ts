import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentifierGenerateFormComponent } from './identifier-generate-form.component';

describe('IdentifierGenerateFormComponent', () => {
  let component: IdentifierGenerateFormComponent;
  let fixture: ComponentFixture<IdentifierGenerateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IdentifierGenerateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdentifierGenerateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
