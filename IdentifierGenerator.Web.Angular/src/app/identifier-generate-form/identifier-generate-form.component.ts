import { Component, ViewChild } from '@angular/core';
import { FormBuilder, Validators, NgForm } from '@angular/forms';
import { IdentifierDataService } from '../identifier-data-service';
import { MatDialogRef } from '@angular/material/dialog';

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

  isLoading: boolean = false;

  @ViewChild('formRef', { static: false })
  private identifierFormRef: NgForm;

  constructor(
    private dialogRef: MatDialogRef<IdentifierGenerateFormComponent>,
    private formBuilder: FormBuilder,
    private identifierDataService: IdentifierDataService) { }

  generateIdentifier() {
    let factoryName = this.identifierForm.value.factoryName;
    let categoryName = this.identifierForm.value.categoryName;

    this.isLoading = true;
    this.identifierDataService.generateNewIdentifier(factoryName, categoryName)
      .subscribe(() => {
        this.identifierForm.reset();
        this.identifierFormRef.resetForm();
        this.dialogRef.close({ factoryName: factoryName, categoryName: categoryName });
        this.isLoading = false;
      });
  }

}
