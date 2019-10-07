using IdentifierGenerator.Web.AngularJs.FunctionalTests.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests.Pages.IdentifiersList
{
    class IdentifierRow
    {
        private readonly IWebDriver _webDriver;
        private readonly string _baseCssSelector;

        public IdentifierRow(IWebDriver webDriver, string baseCssSelector)
        {
            _webDriver = webDriver;
            _baseCssSelector = baseCssSelector;
        }

        public string FactoryCode => _webDriver.WaitForElement(By.CssSelector($"{_baseCssSelector} td:nth-child(1)")).Text;
        public string CategoryCode => _webDriver.WaitForElement(By.CssSelector($"{_baseCssSelector} td:nth-child(2)")).Text;
        public int CurrentValue => int.Parse(_webDriver.WaitForElement(By.CssSelector($"{_baseCssSelector} td:nth-child(3)")).Text);
    }
}
