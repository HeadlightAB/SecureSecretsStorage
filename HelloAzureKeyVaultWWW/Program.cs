using System.Linq;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Azure.KeyVault;
using Microsoft.Azure.Services.AppAuthentication;
using Microsoft.Extensions.Configuration;

namespace HelloAzureKeyVaultWWW
{
    public class Program
    {
        // args[0] = "https://configuration-demo.vault.azure.net/"
        // in app args in project properties, in Debug - Profile: HelloAzureKeyVaultWWW
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config =>
                {
                    var azTokenProvider = new AzureServiceTokenProvider();
                    var kvClient = new KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azTokenProvider.KeyVaultTokenCallback));
                    var secrets = kvClient.GetSecretsAsync(args[0]).GetAwaiter().GetResult()
                        .Select(x => kvClient.GetSecretAsync(x.Id))
                        .ToDictionary(x => x.Result.SecretIdentifier.Name, x => x.Result.Value);

                    config.AddInMemoryCollection(secrets);
                })
                .UseStartup<Startup>();
    }
}
