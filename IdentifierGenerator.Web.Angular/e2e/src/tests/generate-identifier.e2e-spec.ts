import { browser, logging } from 'protractor';
import { Identifier } from '../Identifier';
import { HomePage } from '../pages/home-page.po';
import { IdentifierGenerationForm } from '../pages/identifier-generation-form.po';
import { IdentifierListPage } from '../pages/identifier-list/identifier-list-page.po';

describe('generate-identifier', () => {
  let page: HomePage;

  beforeEach(() => {
    page = new HomePage();
  });

  it('should generate new identfier using form', async () => {
    const factoryCode = `ZZFactoryTest-${Math.floor(Math.random() * 10000)}`;
    const categoryCode = `ZZCategoryTest-${Math.floor(Math.random() * 10000)}`;

    await page.navigateTo();
    const identifierListPage: IdentifierListPage = await page.navigateToIdentifierList();
    const identifierGenerationForm: IdentifierGenerationForm = await identifierListPage.openIdentifierGenerationForm();
    await identifierGenerationForm.enterIdentifierData(factoryCode, categoryCode);
    await identifierGenerationForm.submit();

    const identifier: Identifier = await identifierListPage.searchForIdentifierRow(factoryCode, categoryCode);

    expect(identifier).not.toBeNull();
    expect(identifier.factoryCode).toBe(factoryCode);
    expect(identifier.categoryCode).toBe(categoryCode);
    expect(identifier.value).toBe(1);
  });

  it('should generate new identfier twice using form', async () => {
    const factoryCode = `ZZFactoryTest-${Math.floor(Math.random() * 10000)}`;
    const categoryCode = `ZZCategoryTest-${Math.floor(Math.random() * 10000)}`;

    await page.navigateTo();
    const identifierListPage: IdentifierListPage = await page.navigateToIdentifierList();

    const identifierGenerationForm: IdentifierGenerationForm = await identifierListPage.openIdentifierGenerationForm();
    await identifierGenerationForm.enterIdentifierData(factoryCode, categoryCode);
    await identifierGenerationForm.submit();

    const identifierGenerationForm2: IdentifierGenerationForm = await identifierListPage.openIdentifierGenerationForm();
    await identifierGenerationForm2.enterIdentifierData(factoryCode, categoryCode);
    await identifierGenerationForm2.submit();

    const identifier: Identifier = await identifierListPage.searchForIdentifierRow(factoryCode, categoryCode);

    expect(identifier).not.toBeNull();
    expect(identifier.factoryCode).toBe(factoryCode);
    expect(identifier.categoryCode).toBe(categoryCode);
    expect(identifier.value).toBe(2);
  });

  afterEach(async () => {
    // Assert that there are no errors emitted from the browser
    const logs = await browser.manage().logs().get(logging.Type.BROWSER);
    expect(logs).not.toContain(jasmine.objectContaining({
      level: logging.Level.SEVERE,
    } as logging.Entry));
  });
});
