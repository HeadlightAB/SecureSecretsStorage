using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using VaultSharp;
using VaultSharp.V1.AuthMethods.Token;

namespace HelloVaultWWW
{
    public class Program
    {
        // args[0] = "http://vps.freddes.se:81", args[1]="myroot"
        // in app args in project properties, in Debug - Profile: HelloVaultWWW
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost
                .CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(config => config.AddInMemoryCollection(VaultSecrets.Read(new VaultClientSettings(args[0], new TokenAuthMethodInfo(args[1])))))
                .UseStartup<Startup>();
    }
}
