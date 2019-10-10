import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, Validators, NgForm } from '@angular/forms';

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

  constructor(private formBuilder: FormBuilder) { }

  ngOnInit() {
  }

  generateIdentifier() {
    console.log(`factory: ${this.identifierForm.value.factoryName}`);
    console.log(`category: ${this.identifierForm.value.categoryName}`);

    this.identifierForm.reset();
    this.identifierFormRef.resetForm();
  }
}
