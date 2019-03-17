using System;
using System.Linq;
using System.Net.Http;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
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
                    var azTokenProvider = new AzureServiceTokenProvider();
                    var kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azTokenProvider.KeyVaultTokenCallback));
                    var secrets = kvClient.GetSecretsAsync(keyVaultEndpoint).GetAwaiter().GetResult()
                        .Select(x => kvClient.GetSecretAsync(x.Id))
                        .ToDictionary(x => x.Result.SecretIdentifier.Name, x => x.Result.Value);

                    return Configuration.Create(secrets);
                })
                .AddSingleton<HttpClient>()
                .AddTransient<ThingSpeak>().BuildServiceProvider();

            return services;
        }
    }
}