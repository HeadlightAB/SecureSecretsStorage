using System;
using System.Net.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HelloAzureKeyVault
{
    public class ServiceProviderConfiguration
    {
        public static IServiceProvider CreateProvider(string keyVaultEndpoint)
        {
            var services = new ServiceCollection()
                .AddSingleton(service =>
                {
                    IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
                    configurationBuilder.AddAzureKeyVault(keyVaultEndpoint);

                    return Configuration.Create(configurationBuilder.Build());
                })
                .AddSingleton<HttpClient>()
                .AddTransient<ThingSpeak>().BuildServiceProvider();

            return services;
        }
    }
}