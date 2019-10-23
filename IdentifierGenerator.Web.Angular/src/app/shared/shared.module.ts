import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { LoadingOverlayComponent } from './loading-overlay/loading-overlay.component';


@NgModule({
  declarations: [
    LoadingOverlayComponent
  ],
  imports: [
    CommonModule,
    MatProgressSpinnerModule
  ],
  exports: [
    LoadingOverlayComponent
  ]
})
export class SharedModule { }
