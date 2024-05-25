using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using AmazonTest.Config;
using OpenQA.Selenium;

namespace AmazonTest.Support
{
    public class WebDriverSupport
    {
        public IWebDriver Driver { get; set; } 
        public WebsiteInfo WebsiteInfo { get; set; } 

        public IWebDriver SetupAndGetChromeBrowser()
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions chromeBrowserOptions = new ChromeOptions();
            chromeBrowserOptions.AddArgument("--test-type");
            chromeBrowserOptions.AddArgument("--silent");
            chromeBrowserOptions.AddArgument("--disable-plugins");
            chromeBrowserOptions.AddArgument("--disable-infobars");
            chromeBrowserOptions.AddArgument("--ignore-certificate-errors");
            chromeBrowserOptions.AddArgument("--no-sandbox");
            chromeBrowserOptions.AddArgument("--start-maximized");
            chromeBrowserOptions.AddArgument("--user-data-dir=C:\\Chrome_Temp");
            chromeBrowserOptions.AddArgument("--disable-dev-shm-usage");
            ChromeDriver driver = new ChromeDriver(chromeBrowserOptions);
            return driver;
        }
    
        
    }

}