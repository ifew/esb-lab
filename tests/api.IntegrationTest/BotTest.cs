using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using api.IntegrationTest.Fixtures;
using System.Net;
using Newtonsoft.Json;
using api.IntegrationTest.Models;

namespace api.IntegrationTest
{
    [Collection("SystemCollection")]
    public class BotTest
    {    
        private readonly TestContext _context;

        public BotTest(TestContext context)
        {
            _context = context;
        }

        [Fact]
        public async Task When_Ping_Returns_OK()
        {
            var response = await _context.Client.GetAsync("/api/bot/ping");

            response.EnsureSuccessStatusCode();

            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async Task When_Get_Date_1Feb2017_Return_Selling_35_3182000()
        {
            var response = await _context.Client.GetAsync("/api/bot/exchange_rate/daily_average/2017-02-01/2017-02-01/USD");
            RootObject repositories = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);
            
            response.EnsureSuccessStatusCode();

            Assert.Equal("35.3182000", repositories.result.data.data_detail[0].selling);
        }

    }
}
