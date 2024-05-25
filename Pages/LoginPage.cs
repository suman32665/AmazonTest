using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonTest.Pages
{
    internal class LoginPage
    {
        private IWebDriver _driver;
        private WebDriverWait ShortWait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            ShortWait = new WebDriverWait(_driver, new System.TimeSpan(0, 0, 10));
        }

        //Nav Bar
        public IWebElement SignInNavBar => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id='nav-link-accountList']")));

        //Input Fields
        public IWebElement EmailInput => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id = 'ap_email']")));
        public IWebElement PasswordInput => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id = 'ap_password']")));


        //Button1
        public IWebElement SigninButton => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id='signInSubmit']")));
        public IWebElement SignOutButton => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id='nav-item-signout']")));
        public IWebElement Continue => ShortWait.Until(d => d.FindElement(By.XPath("//*[@id='continue']")));


        //Message
        public IWebElement ErrorMsgHeading => ShortWait.Until(d => d.FindElement(By.XPath("//*[normalize-space(text())='There was a problem']")));
        public IWebElement InvalidEmailErrorMsg => ShortWait.Until(d => d.FindElement(By.XPath("//*[normalize-space(text())='We cannot find an account with that email address']")));
        public IWebElement IncorrectPasswordErrorMsg => ShortWait.Until(d => d.FindElement(By.XPath("//*[normalize-space(text())='Your password is incorrect']")));

        //Menu
        public IWebElement LoginFromMenu => ShortWait.Until(d => d.FindElement(By.XPath("//*[@class='menu-list']//*[text()='Login']")));

        //Verify User Logged in
        public IWebElement VerifyUserLoggedIn => ShortWait.Until(d => d.FindElement(By.XPath("//*[text()='Hello, Suman']")));
        
       


    }

    public class LoginVariables
    {
        public string? Email { get; set; } = null;
        public string? Password { get; set; } = null;

    }
}
