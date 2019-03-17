using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace HelloAzureKeyVault
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderConfiguration.CreateProvider("https://configuration-demo.vault.azure.net/");

            var thingSpeak = serviceProvider.GetService<ThingSpeak>();
            var feedData = thingSpeak.ReadFeed().Result;

            feedData.feeds.Length.Should().Be(100);
            feedData.channel.id.Should().Be(693480);

            Console.WriteLine("Everything went great!");
            Console.ReadLine();
        }
    }
}
