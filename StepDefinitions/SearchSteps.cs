using AmazonTest.Config;
using AmazonTest.Pages;
using AmazonTest.Support;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace AmazonTest.StepDefinitions
{
    [Binding]
    internal class SearchSteps
    {
        private WebDriverSupport _driverSupport;
        SearchPage _searchPage;

        public SearchSteps(WebDriverSupport driverSupport)
        {
            _driverSupport = driverSupport;
            _searchPage = new SearchPage(_driverSupport.Driver);
        }

        [Given(@"I search following product")]
        public void GivenISearchFollowingProduct(Table table)
        {
            var rows = table.Rows;
            _searchPage.SearchInput.SendKeys(rows[0][0]);
        }

        [When(@"I click Search icon")]
        public void WhenIClickSearchIcon()
        {
            _searchPage.SearchIcon.Click();
        }
      
        [Then(@"following results should be displayed")]
        public void ThenFollowingResultsShouldBeDisplayed(Table table)
        {
            var Rows = table.CreateSet<SearchResult>();
            foreach (var row in Rows)
            {
                _searchPage.VerifyResultXpath(row.Product, row.Reviews, row.Price.Split(".")[0], row.Price.Split(".")[1]);
            }
        }

    }
}