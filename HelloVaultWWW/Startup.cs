using System;
using System.Net.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace HelloVaultWWW
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

            app.Run(async context =>
            {
                await context.Response.WriteAsync(
                    $"Field data{Environment.NewLine}" +
                    $"{Newtonsoft.Json.JsonConvert.SerializeObject(_serivceProvider.GetService<ThingSpeak>().ReadFeed().Result)}");
            });
        }
    }
}
