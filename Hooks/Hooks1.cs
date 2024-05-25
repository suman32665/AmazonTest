using AmazonTest.Config;
using AmazonTest.Support;

namespace AmazonTest.Hooks
{
    [Binding]
    public sealed class Hooks1
    {
        private WebDriverSupport _driverSupport;

        public Hooks1 (WebDriverSupport driverSupport) 
        {
            _driverSupport = driverSupport;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            string currentDirectory = Directory.GetCurrentDirectory().Split("bin")[0]; ;
            string jsonFilePath = currentDirectory + "test-settings.json";

            _driverSupport.WebsiteInfo = ConfigurationReader.ReadConfiguration(jsonFilePath).WebsiteInfo;
            if (_driverSupport.WebsiteInfo != null)
            { 

                if (_driverSupport.WebsiteInfo.Browser.ToLower().Equals("chrome"))
                {
                    _driverSupport.Driver = _driverSupport.SetupAndGetChromeBrowser();
                }
            }
            
        }

        

        [AfterScenario]
        public void AfterScenario()
        {
            if(_driverSupport.Driver != null)
            {
                _driverSupport.Driver.Quit();
            }
            
        }
    }
}