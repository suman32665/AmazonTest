using System.Threading.Tasks;

namespace AmazonTest.Config
{
    internal class Configuration
    {
        public WebsiteInfo WebsiteInfo { get; set; }

    }
    public class WebsiteInfo
    {
        public string BaseUrl { get; set; } = string.Empty;
        public string Browser { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
