using NUnit.Framework;
using AmazonTest.Support;
using AmazonTest.Config;
using AmazonTest.Pages;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;

namespace AmazonTest.StepDefinitions
{
    [Binding]
    public sealed class LoginSteps
    {
        private WebDriverSupport _driverSupport;
        private WebsiteInfo _siteInfo;
        LoginPage loginPage;
        JSExecutor jSExecutor;
        Actions webactions;

        public LoginSteps(WebDriverSupport driverSupport)
        {
            _driverSupport = driverSupport;
            _siteInfo = _driverSupport.WebsiteInfo;
            loginPage = new LoginPage(_driverSupport.Driver);
            jSExecutor = new JSExecutor(_driverSupport.Driver);
            webactions = new Actions(_driverSupport.Driver);
        }

        [Given(@"I navigate to Amazon application")]
        public void GivenINavigateToAmazonApplication()
        {
            _driverSupport.Driver.Navigate().GoToUrl(_siteInfo.BaseUrl);
        }

        [Given(@"I click on Sign in from Nav bar")]
        public void GivenIClickOnSignInFromNavBar()
        {
            loginPage.SignInNavBar.Click();
        }

        [Given(@"I enter email in Sign In page")]
        public void GivenIEnterEmailInSignInPage()
        {
            loginPage.EmailInput.SendKeys(_siteInfo.Email);
        }

        [Given(@"I click on Continue button in Sign In page")]
        public void GivenIClickOnContinueButtonInSignInPage()
        {
            loginPage.Continue.Click();
        }

        [Given(@"I enter password in Sign In page")]
        public void GivenIEnterPasswordInSignInPage()
        {
            loginPage.PasswordInput.SendKeys(_siteInfo.Password);
        }

        [Given(@"I enter following email in Sign In page")]
        public void GivenIEnterFollowingEmailInSignInPage(Table table)
        {
            var Rows = table.CreateSet<LoginVariables>();
            var row = Rows.ElementAt(0);
            loginPage.EmailInput.SendKeys(row.Email);
        }

        [Given(@"I enter following password in Sign In page")]
        public void GivenIEnterFollowingPasswordInSignInPage(Table table)
        {
            var Rows = table.CreateSet<LoginVariables>();
            var row = Rows.ElementAt(0);
            loginPage.PasswordInput.SendKeys(row.Password);
        }

        [When(@"I click Sign In button")]
        public void WhenIClickSignInButton()
        {
            Thread.Sleep(3000);
            jSExecutor.ScrollIntoElement(loginPage.SigninButton);
            loginPage.SigninButton.Click();
        }

        [When(@"I click Sign Out button")]
        public void WhenIClickSignOutButton()
        {
            webactions.MoveToElement(loginPage.SignInNavBar).Perform();
            loginPage.SignOutButton.Click();
        }

        [Then(@"verify that the user is logged in")]
        public void ThenVerifyThatTheUserIsLoggedIn()
        {
            Assert.True(loginPage.VerifyUserLoggedIn.Displayed);
        }

        [Then(@"verify that the user is redirected to SignIn Page")]
        public void ThenVerifyThatTheUserIsRedirectedToSignInPage()
        {
            Assert.IsTrue(loginPage.EmailInput.Displayed);

        }

        [Then(@"Incorrect Password Message should be displayed")]
        public void ThenIncorrectPasswordMessageShouldBeDisplayed()
        {
            Assert.IsTrue(loginPage.ErrorMsgHeading.Displayed);
            Assert.IsTrue(loginPage.IncorrectPasswordErrorMsg.Displayed);
        }

        [Then(@"Invalid Email Message should be displayed")]
        public void ThenInvalidEmailMessageShouldBeDisplayed()
        {
            Assert.True(loginPage.ErrorMsgHeading.Displayed);
            Assert.True(loginPage.InvalidEmailErrorMsg.Displayed);
        }

        [Given(@"Sign In if not already signed in")]
        public void GivenSignInIfNotAlreadySignedIn()
        {
            try
            {
                ThenVerifyThatTheUserIsLoggedIn();
            }catch (WebDriverTimeoutException)
            {
                GivenIClickOnSignInFromNavBar();
                GivenIEnterEmailInSignInPage();
                GivenIClickOnContinueButtonInSignInPage();
                GivenIEnterPasswordInSignInPage();
                WhenIClickSignInButton();
                ThenVerifyThatTheUserIsLoggedIn();
            }
        }

    }
}