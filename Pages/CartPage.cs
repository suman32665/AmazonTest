using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest.Pages
{
    internal class CartPage
    {
        private IWebDriver _driver;
        private WebDriverWait ShortWait;

        public CartPage(IWebDriver driver)
        {
            _driver = driver;
            ShortWait = new WebDriverWait(_driver, new System.TimeSpan(0, 0, 10));
        }

        //Nav Bar
        public IWebElement CartNavBar => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id='nav-cart-count-container']")));

        //Button
        public IWebElement AddToCart => ShortWait.Until(d => d.FindElement(By.XPath("//*[text()='Add to cart']")));
        public IWebElement Delete => ShortWait.Until(d => d.FindElement(By.XPath("//*[@data-feature-id='delete']//input")));

        //Message
        public IWebElement ItemAddedMsg => ShortWait.Until(d => d.FindElement(By.XPath("//*[text()='Item Added']")));

        //Cart Item
        public void VerifyCartItemXpath(string itemName, string price)
        {
            ShortWait.Until(d => d.FindElement(By.XPath("//*[text()='"+itemName+"']" +
                "//ancestor::*[@class='sc-item-content-group']//*[text()='"+price+"']")));
        }
    }

    public class CartItems
    {
        public string ItemName { get; set; } = String.Empty;
        public string Price { get; set; } = String.Empty;

    }
}
