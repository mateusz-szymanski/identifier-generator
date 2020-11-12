using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System.IO;
using System.Reflection;
using Xunit;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests
{
    public class HelloWorldTests
    {
        //[Fact]
        public void HelloWorldWithFirefoxDriver()
        {
            var options = new FirefoxOptions();
            options.AddArgument("headless");

            using (var driver = new FirefoxDriver(options))
            {
                driver.Navigate().GoToUrl(@"http://localhost:3000/");
                var link = driver.FindElement(By.CssSelector(".navbar-brand"));
                Assert.Equal("Identifier Generator", link.Text);
            }
        }

        //[Fact]
        public void HelloWorldWithChromeDriver()
        {
            var currentLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var options = new ChromeOptions();
            options.AddArgument("headless");

            using (var driver = new ChromeDriver(currentLocation, options))
            {
                driver.Navigate().GoToUrl(@"http://localhost:3000/");
                var link = driver.FindElement(By.CssSelector(".navbar-brand"));
                Assert.Equal("Identifier Generator", link.Text);
            }
        }
    }
}
