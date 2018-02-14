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
    public class BotService
    {
        private static readonly HttpClient client = new HttpClient();

        public BotService()
        {
        }

        public object ExchangeRateDailyAverage(string start_date="2002-01-12", string end_date="2002-01-15", string currency="USD")
        {
            string url = "https://iapi.bot.or.th/Stat/Stat-ExchangeRate/DAILY_AVG_EXG_RATE_V1/?start_period="+start_date+"&end_period="+end_date+"&currency="+currency;
            object result = CallGet(url).Result;

            return result;
        }

        static async Task<object> CallGet(string url)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("api-key", "U9G1L457H6DCugT7VmBaEacbHV9RX0PySO05cYaGsm");
            var response = await client.GetStringAsync(url);
            var repositories = JsonConvert.DeserializeObject<object>(response);

            return repositories;
        }
    }

}
