using IdentifierGenerator.Web.AngularJs.FunctionalTests.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IdentifierGenerator.Web.AngularJs.FunctionalTests.Pages.IdentifiersList
{
    class IdentifiersTable
    {
        private readonly IWebDriver _webDriver;
        private readonly string _baseSelector;

        public IdentifiersTable(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            _baseSelector = "factory-list";
        }

        public Pager Pager => new Pager(_webDriver, $"{_baseSelector} .ng-table-pager");

        public IdentifierRow SearchWholeTableForIdentifierRow(string factory, string category)
        {
            for (var pageNumber = Pager.PageNumber; pageNumber <= Pager.NumberOfPages; ++pageNumber)
            {
                var numberOfRows = _webDriver.WaitForElements(By.CssSelector($"{_baseSelector} table tbody tr")).Count;
                for (var elementNumber = 1; elementNumber <= numberOfRows; ++elementNumber)
                {
                    var rowSelector = $"{_baseSelector} table tbody tr:nth-child({elementNumber})";
                    var row = new IdentifierRow(_webDriver, rowSelector);
                    if (row.FactoryCode == factory && row.CategoryCode == category)
                        return row;
                }

                if (Pager.CanMoveToNextPage())
                {
                    Pager.NextPage();
                    _webDriver.WaitForLoading();
                }
            }

            throw new NoSuchElementException($"Identifier row with given factory and category was not found ({factory}, {category})");
        }
    }
}
