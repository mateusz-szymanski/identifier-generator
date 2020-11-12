import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { By } from '@angular/platform-browser';
import { LoadingOverlayComponent } from './loading-overlay.component';

describe('LoadingOverlayComponent', () => {
  let component: LoadingOverlayComponent;
  let fixture: ComponentFixture<LoadingOverlayComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      imports: [
        MatProgressSpinnerModule
      ],
      declarations: [LoadingOverlayComponent]
    })
      .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LoadingOverlayComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should show/hide spinner based on isLoading', () => {
    const bySelector = By.css('mat-spinner');

    component.isLoading = false;
    fixture.detectChanges();
    expect(fixture.debugElement.query(bySelector)).toBeNull();

    component.isLoading = true;
    fixture.detectChanges();
    expect(fixture.debugElement.query(bySelector)).not.toBeNull();

    component.isLoading = false;
    fixture.detectChanges();
    expect(fixture.debugElement.query(bySelector)).toBeNull();
  });
});
