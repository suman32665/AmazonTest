using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest.Support
{
    internal class JSExecutor
    {
        private IWebDriver _driver;

        public JSExecutor(IWebDriver driver)
        {
            _driver = driver;
        }

        public void ScrollIntoElement(IWebElement element)
        {
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].scrollIntoView(true);", element);
            Thread.Sleep(500);

        }
    }
}
