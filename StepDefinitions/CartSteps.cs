using AmazonTest.Pages;
using AmazonTest.Support;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow.Assist;

namespace AmazonTest.StepDefinitions
{
    [Binding]
    internal class CartSteps
    {
        private WebDriverSupport _driverSupport;
        CartPage _cartPage;

        public CartSteps(WebDriverSupport driverSupport)
        {
            _driverSupport = driverSupport;
            _cartPage = new CartPage(_driverSupport.Driver);
        }

        [When(@"I click on Add to cart")]
        public void WhenIClickOnAddToCart()
        {
            _cartPage.AddToCart.Click();
        }

        [Then(@"item added message should be displayed")]
        public void ThenItemAddedMessageShouldBeDisplayed()
        {
            Assert.True(_cartPage.ItemAddedMsg.Displayed);
            Thread.Sleep(5000);
        }

        [When(@"I click on cart on Nav bar")]
        public void WhenIClickOnCartOnNavBar()
        {
            _cartPage.CartNavBar.Click();
        }

        [Then(@"the following item should listed in cart")]
        public void ThenTheFollowingItemShouldListedInCart(Table table)
        {
            var Rows = table.CreateSet<CartItems>();
            foreach (var row in Rows)
            {
                _cartPage.VerifyCartItemXpath(row.ItemName,row.Price);
            }
        }

        [Then(@"delete the item from the cart")]
        public void ThenDeleteTheItemFromTheCart()
        {
            Thread.Sleep(3000);
            _cartPage.Delete.Click();
        }

    }
}
