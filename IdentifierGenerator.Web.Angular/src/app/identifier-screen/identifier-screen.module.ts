import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDividerModule } from '@angular/material/divider';
import { MatGridListModule } from '@angular/material/grid-list';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTableModule } from '@angular/material/table';
import { MatToolbarModule } from '@angular/material/toolbar';
import { AppRoutingModule } from '../app-routing.module';
import { SharedModule } from '../shared/shared.module';
import { IdentifierGenerateFormComponent } from './identifier-generate-form/identifier-generate-form.component';
import { IdentifierHistoryComponent } from './identifier-history/identifier-history.component';
import { IdentifierListComponent } from './identifier-list/identifier-list.component';
import { IdentifierScreenRoutingModule } from './identifier-screen-routing.module';

@NgModule({
  declarations: [
    IdentifierGenerateFormComponent,
    IdentifierListComponent,
    IdentifierHistoryComponent
  ],
  imports: [
    IdentifierScreenRoutingModule,
    CommonModule,
    SharedModule,
    AppRoutingModule,
    ReactiveFormsModule,
    MatInputModule,
    MatCardModule,
    MatButtonModule,
    MatGridListModule,
    MatToolbarModule,
    MatTableModule,
    MatPaginatorModule,
    MatProgressSpinnerModule,
    MatDividerModule,
    MatIconModule,
    MatDialogModule
  ],
  entryComponents: [IdentifierGenerateFormComponent]
})
export class IdentifierScreenModule { }
