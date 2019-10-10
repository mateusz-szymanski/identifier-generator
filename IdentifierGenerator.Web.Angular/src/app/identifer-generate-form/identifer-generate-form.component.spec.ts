import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { IdentiferGenerateFormComponent } from './identifer-generate-form.component';

describe('IdentiferGenerateFormComponent', () => {
  let component: IdentiferGenerateFormComponent;
  let fixture: ComponentFixture<IdentiferGenerateFormComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ IdentiferGenerateFormComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(IdentiferGenerateFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
