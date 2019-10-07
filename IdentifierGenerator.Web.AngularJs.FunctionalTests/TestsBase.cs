using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Reflection;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests
{
    public abstract class TestsBase : IDisposable
    {
        protected IWebDriver WebDriver { get; set; }
        protected Uri BaseUri = new Uri(@"http://localhost:3000/");

        protected TestsBase()
        {
            CreateChromeWebDriver();
            WebDriver.Navigate().GoToUrl(BaseUri);
        }

        private void CreateChromeWebDriver()
        {
            var currentLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var options = new ChromeOptions();
            options.AddArgument("headless");

            WebDriver = new ChromeDriver(currentLocation, options);
        }

        public void Dispose()
        {
            WebDriver.Quit();
        }
    }
}
