using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

namespace HelloVault
{
    public class ServiceProviderConfiguration
    {
        public static ServiceProvider CreateProvider(string vaultServiceUri, string token)
        {
            var services = new ServiceCollection()
                .AddSingleton(service => Configuration.Create(VaultSecrets.Read(new VaultClientSettings(vaultServiceUri, new TokenAuthMethodInfo(token)))))
                .AddSingleton<HttpClient>()
                .AddTransient<ThingSpeak>();

            return services.BuildServiceProvider();
        }
    }
}