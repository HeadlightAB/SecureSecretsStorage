using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using SecureStorageShared.Models;

namespace HelloVaultWWW
{
    public class ThingSpeak
    {
        private readonly IConfiguration _configuration;
        private readonly HttpClient _httpClient;

        public ThingSpeak(IConfiguration configuration, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClient = httpClient;
        }

        public async Task<ThingSpeakFeed> ReadFeed()
        {
            _httpClient.DefaultRequestHeaders.Clear();
            _httpClient.DefaultRequestHeaders.Add("THINGSPEAKAPIKEY", _configuration["token"]);

            var httpResponseMessage = await _httpClient.GetAsync(_configuration["fieldUrl"]);
            var jsonContent = await httpResponseMessage.Content.ReadAsStringAsync();

            return Newtonsoft.Json.JsonConvert.DeserializeObject<ThingSpeakFeed>(jsonContent);
        }
    }
}