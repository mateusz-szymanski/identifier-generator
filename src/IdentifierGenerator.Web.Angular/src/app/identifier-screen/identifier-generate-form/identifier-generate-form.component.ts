import { Component, ViewChild } from '@angular/core';
import { FormBuilder, NgForm, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { IdentifierDataService } from '../../model/identifier-data-service';
import { MessenagerService } from '../messenager.service';

@Component({
  selector: 'app-identifier-generate-form',
  templateUrl: './identifier-generate-form.component.html',
  styleUrls: ['./identifier-generate-form.component.scss']
})
export class IdentifierGenerateFormComponent {
  identifierForm = this.formBuilder.group({
    factoryName: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    categoryName: ['', { validators: [Validators.required, Validators.maxLength(30)] }]
  });

  get factoryName() { return this.identifierForm.get('factoryName'); }
  get categoryName() { return this.identifierForm.get('categoryName'); }

  isLoading = false;

  @ViewChild('formRef', { static: false })
  private identifierFormRef: NgForm;

  constructor(
    private dialogRef: MatDialogRef<IdentifierGenerateFormComponent>,
    private formBuilder: FormBuilder,
    private identifierDataService: IdentifierDataService,
    private messenagerService: MessenagerService) { }

  generateIdentifier() {
    const { factoryName, categoryName } = this.identifierForm.value;

    this.isLoading = true;
    this.identifierDataService.generateNewIdentifier(factoryName, categoryName)
      .subscribe(() => {
        this.identifierForm.reset();
        this.identifierFormRef.resetForm();
        this.dialogRef.close();
        this.isLoading = false;

        this.messenagerService.identifierAdded({factoryCode: factoryName, categoryCode: categoryName, value: 1});
      });
  }

}
