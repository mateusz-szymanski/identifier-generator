using IdentifierGenerator.Web.AngularJs.FunctionalTests.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests.Pages
{
    class GenerateIdentifierForm
    {
        private readonly IWebDriver _webDriver;

        public GenerateIdentifierForm(IWebDriver webDriver)
        {
            _webDriver = webDriver;
        }

        public IWebElement FactoryInput => _webDriver.WaitForElement(By.Id("factoryInput"));
        public IWebElement CategoryInput => _webDriver.WaitForElement(By.Id("categoryInput"));
        public IWebElement SubmitButton => _webDriver.WaitForElement(By.CssSelector("new-factory form button[type=submit]"));

        public void EnterIdentifierData(string factory, string category)
        {
            FactoryInput.SendKeys(factory);
            CategoryInput.SendKeys(category);
        }

        public void ClearFormData()
        {
            FactoryInput.Clear();
            CategoryInput.Clear();
        }

        public void Submit()
        {
            SubmitButton.Click();
        }

    }
}
