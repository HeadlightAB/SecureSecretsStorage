using System;
using System.Collections.Generic;

namespace HelloVault
{
    public class Configuration : IConfiguration
    {
        public string Token { get; }
        public Uri FieldUrl { get; }

        public static IConfiguration Create(IDictionary<string, object> secrets) => new Configuration(secrets);

        private Configuration(IDictionary<string, object> secrets)
        {
            Token = secrets["token"].ToString();
            FieldUrl = new Uri(secrets["fieldUrl"].ToString());
        }
    }
}