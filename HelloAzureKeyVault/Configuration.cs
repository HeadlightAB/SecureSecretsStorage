using System;
using Microsoft.Extensions.Configuration;

namespace HelloAzureKeyVault
{
    public class Configuration : IConfiguration
    {
        public string Token { get; }
        public Uri FieldUrl { get; }

        public static IConfiguration Create(IConfigurationRoot configurationRoot) => new Configuration(configurationRoot);

        private Configuration(IConfigurationRoot configurationRoot)
        {
            Token = configurationRoot["token"];
            FieldUrl = new Uri(configurationRoot["fieldUrl"]);
        }        
    }
}
