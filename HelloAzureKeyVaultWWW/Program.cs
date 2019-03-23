using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
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
                .ConfigureAppConfiguration(config => config.AddAzureKeyVault(args[0]))
                .UseStartup<Startup>();
    }
}
