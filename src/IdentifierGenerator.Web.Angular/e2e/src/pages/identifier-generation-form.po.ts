import { by, element } from 'protractor';

export class IdentifierGenerationForm {

  async submit() {
    const submitButton = element(by.css('mat-dialog-container button[type=submit]'));
    await submitButton.click();
  }

  async enterIdentifierData(factoryCode: string, categoryCode: string) {
    const factoryInput = element(by.css('mat-dialog-container input#factory-input'));
    const categoryInput = element(by.css('mat-dialog-container input#category-input'));

    await factoryInput.clear();
    await factoryInput.sendKeys(factoryCode);

    await categoryInput.clear();
    await categoryInput.sendKeys(categoryCode);
  }

}
