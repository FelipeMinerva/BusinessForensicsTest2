using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace BusinessForensicsTest2.API.Client
{

    public class WikipediaClient
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public WikipediaClient(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task<string> GetAnimalDescription(string name)
        {
            var request = await _client
                .GetAsync(_config["Services:Description"] + name)
                .ConfigureAwait(false);

            var content = await request.Content.ReadAsStringAsync();

            return JObjectLookup(JObject.Parse(content), "extract");
        }

        private string JObjectLookup(JObject obj, string lookupProperty)
        {   
            var description = obj["query"]["pages"].Children().FirstOrDefault().Path;

            var value = obj.SelectToken(description + "." + lookupProperty);

            return value.Value<string>();
        }

        public async Task<string> GetPictureUrl(string name){
            var request = await _client
                .GetAsync(_config["Services:Picture"] + name)
                .ConfigureAwait(false);

            var content = await request.Content.ReadAsStringAsync();

            return JObjectLookup(JObject.Parse(content), "thumbnail.source");
        }
    }
}