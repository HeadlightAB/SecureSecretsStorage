using System;
using FluentAssertions;
using Microsoft.Extensions.DependencyInjection;

namespace HelloVault
{
    class Program
    {
        // args[0] = "http://vps.freddes.se:81", args[1]="myroot"
        // in app args in project properties
        static void Main(string[] args)
        {
            var serviceProvider = ServiceProviderConfiguration.CreateProvider(args[0], args[1]);

            var thingSpeak = serviceProvider.GetService<ThingSpeak>();
            var feedData = thingSpeak.ReadFeed().Result;

            feedData.feeds.Length.Should().Be(100);
            feedData.channel.id.Should().Be(693480);

            Console.WriteLine("Everything went great!");
            Console.ReadLine();
        }
    }
}