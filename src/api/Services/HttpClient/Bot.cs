using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using api.Models;
using Newtonsoft.Json;

namespace api.Services
{
    public class BotHttpClient
    {
        private static readonly HttpClient client = new HttpClient();

        public async Task<RootObject> CallGet(string url)
        {
            HttpClient _client = new HttpClient();
            _client.DefaultRequestHeaders.Add("api-key", "U9G1L457H6DCugT7VmBaEacbHV9RX0PySO05cYaGsm");
            var response = await _client.GetStringAsync(url);
            var repositories = JsonConvert.DeserializeObject<RootObject>(response);

            return repositories;
        }
    }

}
