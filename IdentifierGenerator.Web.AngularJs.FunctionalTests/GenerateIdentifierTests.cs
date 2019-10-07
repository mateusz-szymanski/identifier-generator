using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;
using System.Reflection;
using Xunit;
using IdentifierGenerator.Web.AngularJs.FunctionalTests.Helpers;
using IdentifierGenerator.Web.AngularJs.FunctionalTests.Pages;
using IdentifierGenerator.Web.AngularJs.FunctionalTests.Pages.IdentifiersList;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests
{
    public class GenerateIdentifierTests : TestsBase
    {
        [Fact]
        public void GenerateIdentifierFormShouldCreateNewIdentifier()
        {
            // arrange
            var factory = $"FactoryTest-{Guid.NewGuid().ToString().ToLower().Substring(0, 4)}";
            var category = $"CategoryTest-{Guid.NewGuid().ToString().ToLower().Substring(0, 4)}";

            // act
            var generateIdentifierForm = new GenerateIdentifierForm(WebDriver);
            generateIdentifierForm.EnterIdentifierData(factory, category);
            generateIdentifierForm.Submit();

            WebDriver.WaitForLoading();

            var identifiersTable = new IdentifiersTable(WebDriver);

            // assert
            var addedRow = identifiersTable.SearchWholeTableForIdentifierRow(factory, category);
            Assert.NotNull(addedRow);
            Assert.Equal(1, addedRow.CurrentValue);
        }


        [Fact]
        public void GenerateIdentifierFormShouldAddNewIdentifierTwice()
        {
            // arrange
            var factory = $"FactoryTest-{Guid.NewGuid().ToString().ToLower().Substring(0, 4)}";
            var category = $"CategoryTest-{Guid.NewGuid().ToString().ToLower().Substring(0, 4)}";

            // act
            var generateIdentifierForm = new GenerateIdentifierForm(WebDriver);
            generateIdentifierForm.EnterIdentifierData(factory, category);
            generateIdentifierForm.Submit();
            WebDriver.WaitForLoading();

            generateIdentifierForm.ClearFormData();
            generateIdentifierForm.EnterIdentifierData(factory, category);
            generateIdentifierForm.Submit();
            WebDriver.WaitForLoading();

            var identifiersTable = new IdentifiersTable(WebDriver);

            // assert
            var addedRow = identifiersTable.SearchWholeTableForIdentifierRow(factory, category);
            Assert.NotNull(addedRow);
            Assert.Equal(2, addedRow.CurrentValue);
        }
    }
}
