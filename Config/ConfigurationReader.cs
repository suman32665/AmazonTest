using Newtonsoft.Json;

namespace AmazonTest.Config
{
    internal class ConfigurationReader
    {
        public static Configuration ReadConfiguration(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    string jsonContent = File.ReadAllText(filePath);
                    return JsonConvert.DeserializeObject<Configuration>(jsonContent);
                }
                else
                {
                    throw new FileNotFoundException($"The JSON configuration file at {filePath} was not found.");
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Error reading or deserializing the JSON configuration file: {ex.Message}");
            }
        }
    }
}
