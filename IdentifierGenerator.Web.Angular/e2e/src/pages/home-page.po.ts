import { browser, by, element } from 'protractor';
import { IdentifierListPage } from './identifier-list/identifier-list-page.po';

export class HomePage {

  async navigateToIdentifierList(): Promise<IdentifierListPage> {
    await browser.get('/identifier');
    return new IdentifierListPage();
  }

  async navigateTo() {
    return browser.get(browser.baseUrl) as Promise<any>;
  }

  getFirstParagraphText() {
    return element(by.css('app-home p:first-child')).getText() as Promise<string>;
  }
}
