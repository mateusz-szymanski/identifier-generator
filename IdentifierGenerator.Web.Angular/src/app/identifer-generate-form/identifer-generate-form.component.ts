import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators, NgForm } from '@angular/forms';
import { IdentifierDataService } from '../identifier-data-service';

@Component({
  selector: 'app-identifer-generate-form',
  templateUrl: './identifer-generate-form.component.html',
  styleUrls: ['./identifer-generate-form.component.scss']
})
export class IdentiferGenerateFormComponent implements OnInit {

  identifierForm = this.formBuilder.group({
    factoryName: ['', { validators: [Validators.required, Validators.maxLength(30)] }],
    categoryName: ['', { validators: [Validators.required, Validators.maxLength(30)] }]
  });

  get factoryName() { return this.identifierForm.get('factoryName'); }
  get categoryName() { return this.identifierForm.get('categoryName'); }

  @ViewChild('formRef', { static: false })
  private identifierFormRef: NgForm;

  constructor(private formBuilder: FormBuilder, private identifierDataService: IdentifierDataService) { }

  ngOnInit() {
  }

  generateIdentifier() {
    this.identifierDataService.generateNewIdentifier(this.identifierForm.value.factoryName, this.identifierForm.value.categoryName)
    .subscribe();

    this.identifierForm.reset();
    this.identifierFormRef.resetForm();
  }
}
