using OpenQA.Selenium;
using System;
using System.Linq;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests.Pages.IdentifiersList
{
    class Pager
    {
        private readonly IWebDriver _webDriver;
        private readonly string _baseCssSelector;

        public Pager(IWebDriver webDriver, string baseCssSelector)
        {
            _webDriver = webDriver;
            _baseCssSelector = baseCssSelector;
        }

        public int PageNumber => int.Parse(_webDriver.FindElement(By.CssSelector($"{_baseCssSelector} .pagination li.active span")).Text);
        public int NumberOfPages => int.Parse(_webDriver.FindElement(By.CssSelector($"{_baseCssSelector} .pagination li.active span")).Text);
        public int PageSize => int.Parse(_webDriver.FindElement(By.CssSelector($"{_baseCssSelector} .ng-table-counts button.active span")).Text);

        private IWebElement NextPageButton => _webDriver.FindElement(By.CssSelector($"{_baseCssSelector} .pagination li:last-child a"));

        public void NextPage()
        {
            NextPageButton.Click();
        }

        public bool CanMoveToNextPage()
        {
            var classes = NextPageButton.GetAttribute("class").Split(' ').Select(c => c.Trim().ToLowerInvariant());
            return !classes.Contains("disabled");
        }
    }
}
