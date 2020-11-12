import { by, element } from 'protractor';
import { Identifier } from '../../Identifier';
import { IdentifierGenerationForm } from '../identifier-generation-form.po';
import { Pagination } from './pager';

export class IdentifierListPage {
  async openIdentifierGenerationForm(): Promise<IdentifierGenerationForm> {
    const generateNewButton = element(by.css('#open-new-identifier-form-button'));
    await generateNewButton.click();

    return new IdentifierGenerationForm();
  }

  async searchForIdentifierRow(factoryCode: string, categoryCode: string): Promise<Identifier> {
    const pagination = new Pagination();

    const rowSelectorTemplate = 'table#identifier-list tbody tr:nth-child({elementNumber})';
    const rowsSelector = 'table#identifier-list tbody tr';

    do {
      const numberOfRows = await element.all(by.css(rowsSelector)).count();
      for (let rowIndex = 1; rowIndex <= numberOfRows; ++rowIndex) {
        const rowSelector = rowSelectorTemplate.replace('{elementNumber}', `${rowIndex}`);
        const elementFactoryCode = await element(by.css(`${rowSelector} td:nth-child(1)`)).getText();
        const elementCategoryCode = await element(by.css(`${rowSelector} td:nth-child(2)`)).getText();
        const elementCurrentValue = await element(by.css(`${rowSelector} td:nth-child(3)`)).getText();

        const identifier: Identifier = {
          factoryCode: elementFactoryCode,
          categoryCode: elementCategoryCode,
          value: +elementCurrentValue
        };

        if (identifier.factoryCode === factoryCode && identifier.categoryCode === categoryCode) {
          return identifier;
        }
      }
    } while (await pagination.navigateNextPage());

    throw new Error(`${factoryCode}/${categoryCode} not found`);
  }
}
