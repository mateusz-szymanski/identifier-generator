import { by, element } from 'protractor';

export class Pagination {

  private get nextPageButton() {
    return element(by.css('mat-paginator .mat-paginator-range-actions button[aria-label="Next page"]'));
  }

  async navigateNextPage(): Promise<boolean> {
    if (!await this.canNavigateNextPage()) {
      return false;
    }

    const nextPageButton = this.nextPageButton;
    await nextPageButton.click();

    return true;
  }

  private async canNavigateNextPage(): Promise<boolean> {
    const nextPageButton = this.nextPageButton;
    return await nextPageButton.isEnabled();
  }
}
