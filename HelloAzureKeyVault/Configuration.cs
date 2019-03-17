using System;
using System.Collections.Generic;

namespace HelloAzureKeyVault
{
    public class Configuration : IConfiguration
    {
        public string Token { get; }
        public Uri FieldUrl { get; }

        public static IConfiguration Create(IDictionary<string, string> secrets) => new Configuration(secrets);

        private Configuration(IDictionary<string, string> secrets)
        {
            Token = secrets["token"];
            FieldUrl = new Uri(secrets["fieldUrl"]);
        }        
    }
}
