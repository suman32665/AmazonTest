using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest.Pages
{
    internal class SearchPage
    {
        private IWebDriver _driver;
        private WebDriverWait ShortWait;

        public SearchPage(IWebDriver driver)
        {
            _driver = driver;
            ShortWait = new WebDriverWait(_driver, new System.TimeSpan(0, 0, 10));
        }

        //Input Fields
        public IWebElement SearchInput => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id='twotabsearchtextbox']")));

        //Button or Icon
        public IWebElement SearchIcon => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id = 'nav-search-submit-button']")));

        //Search Result
        public void VerifyResultXpath(string productName, string reviews, string price_whole, string price_decimal)
        {
             ShortWait.Until(d => d.FindElement(By.XPath("//*[text()=\""+productName+"\"]" +
                 "//ancestor::*[@class='puisg-col-inner']//*[text()='"+reviews+"']" +
                 "//ancestor::*[@class='puisg-col-inner']//*[@class='a-price-whole' and text()='"+ price_whole + "']" +
                 "//following-sibling::*[@class='a-price-fraction' and text()='"+price_decimal+"']")));
        }
    }
    public class SearchResult
    {
        public string Product { get; set; } = String.Empty;
        public string Reviews { get; set; } = String.Empty;
        public string Price { get; set; } = String.Empty;

    }
}
