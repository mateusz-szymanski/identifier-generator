using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests.Helpers
{
    static class WebDriverExtensions
    {
        private static TimeSpan _defaultTimeoutTimeSpan = TimeSpan.FromSeconds(2);

        public static IWebElement WaitForElement(this IWebDriver webDriver, By by)
        {
            return webDriver.WaitForElement(by, _defaultTimeoutTimeSpan);
        }

        public static IReadOnlyCollection<IWebElement> WaitForElements(this IWebDriver webDriver, By by)
        {
            return webDriver.WaitForElements(by, _defaultTimeoutTimeSpan);
        }

        public static IWebElement WaitForElement(this IWebDriver webDriver, By by, TimeSpan timeSpan)
        {
            var webDriverWait = new WebDriverWait(webDriver, timeSpan);
            webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            var webElement = webDriverWait.Until((d) =>
            {
                return d.FindElement(by);
            });

            return webElement;
        }

        public static IReadOnlyCollection<IWebElement> WaitForElements(this IWebDriver webDriver, By by, TimeSpan timeSpan)
        {
            var webDriverWait = new WebDriverWait(webDriver, timeSpan);
            webDriverWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            webDriverWait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));

            var webElement = webDriverWait.Until((d) =>
            {
                return d.FindElements(by);
            });

            return webElement;
        }

        public static void WaitForLoading(this IWebDriver webDriver)
        {
            var webDriverWait = new WebDriverWait(webDriver, TimeSpan.FromMilliseconds(500));
            try
            {
                webDriverWait.Until((d) => false);
            }
            catch (Exception) { }
        }
    }
}
