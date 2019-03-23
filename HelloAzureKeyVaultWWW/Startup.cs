using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloAzureKeyVaultWWW
{
    public class Startup
    {
        private ServiceProvider _serivceProvider;

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddTransient<ThingSpeak>()
                .AddSingleton<HttpClient>();

            _serivceProvider = services.BuildServiceProvider();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.Run(async (context) =>
            {
                if (context.Request.Path == "/favicon.ico")
                {
                    context.Response.StatusCode = (int) HttpStatusCode.NotFound;
                    return;
                }

                await context.Response.WriteAsync(
                    $"Field data{Environment.NewLine}" +
                    $"{Newtonsoft.Json.JsonConvert.SerializeObject(_serivceProvider.GetService<ThingSpeak>().ReadFeed().Result)}");
            });
        }
    }
}
