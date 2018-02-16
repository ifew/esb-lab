using System;
using Xunit;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using System.Net;
using Newtonsoft.Json;
using Stubbery;
using api.UnitTest.Models;
using api.Services;

namespace api.UnitTest
{

    public class BotTest
    {

        private readonly HttpClient httpClient = new HttpClient();

        public BotTest()
        {
        }

        [Fact]
        public void When_Input_35_3182000_And_Get_Fee_3percent()
        {
            var expected = "1.059546";

            BotService botService = new BotService();
            var actual = botService.GetFeeFromExchangeRate(35.3182000);

            Assert.Equal(expected, actual.ToString());
        }

        [Fact]
        public void When_Get_Selling_35_3182000_And_Plus_Fee_3percent()
        {
            var expected = "36.38";

            BotService botService = new BotService();
            var actual = botService.ExchangeRateDailyAverageWithFee("2017-02-01","2017-02-01","USD");

            Assert.Equal(expected, actual);
        }

        [Fact]
        public async Task When_Get_Date_1Feb2017_Return_Selling_35_3182000()
        {
            using (var stub = new ApiStub())
            {
                stub.Get(
                    "/api/bot/exchange_rate/daily_average/2017-02-01/2017-02-01/USD",
                    (req, args) => "{\"result\":{\"success\":\"true\",\"api\":\"Daily Weighted-average Interbank Exchange Rate - THB  USD\",\"timestamp\":\"2018-02-15 12:18:23\",\"data\":{\"data_header\":{\"report_name_eng\":\"Rates of Exchange of Commercial Banks in Bangkok Metropolis (2002-present)\",\"report_name_th\":\"\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E41\u0E25\u0E01\u0E40\u0E1B\u0E25\u0E35\u0E48\u0E22\u0E19\u0E40\u0E09\u0E25\u0E35\u0E48\u0E22\u0E02\u0E2D\u0E07\u0E18\u0E19\u0E32\u0E04\u0E32\u0E23\u0E1E\u0E32\u0E13\u0E34\u0E0A\u0E22\u0E4C\u0E43\u0E19\u0E01\u0E23\u0E38\u0E07\u0E40\u0E17\u0E1E\u0E21\u0E2B\u0E32\u0E19\u0E04\u0E23 (2545-\u0E1B\u0E31\u0E08\u0E08\u0E38\u0E1A\u0E31\u0E19)\",\"report_uoq_name_eng\":\"(Unit : Baht 1 Unit of Foreign Currency)\",\"report_uoq_name_th\":\"(\u0E2B\u0E19\u0E48\u0E27\u0E22 : \u0E1A\u0E32\u0E17 \u0E15\u0E48\u0E2D 1 \u0E2B\u0E19\u0E48\u0E27\u0E22\u0E40\u0E07\u0E34\u0E19\u0E15\u0E23\u0E32\u0E15\u0E48\u0E32\u0E07\u0E1B\u0E23\u0E30\u0E40\u0E17\u0E28)\",\"report_source_of_data\":[{\"source_of_data_eng\":\"Bank of Thailand\",\"source_of_data_th\":\"\u0E18\u0E19\u0E32\u0E04\u0E32\u0E23\u0E41\u0E2B\u0E48\u0E07\u0E1B\u0E23\u0E30\u0E40\u0E17\u0E28\u0E44\u0E17\u0E22\"}],\"report_remark\":[{\"report_remark_eng\":\"Since Nov 16, 2015 the data regarding Buying Transfer Rate of PKR has been changed to Buying Rate using Foreign Exchange Rates (THOMSON REUTERS) with Bangkok Market Crossing.\",\"report_remark_th\":\"\u0E15\u0E31\u0E49\u0E07\u0E41\u0E15\u0E48\u0E27\u0E31\u0E19\u0E17\u0E35\u0E48 16 \u0E1E.\u0E22. 2558 \u0E02\u0E49\u0E2D\u0E21\u0E39\u0E25\u0E43\u0E19\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E0B\u0E37\u0E49\u0E2D\u0E40\u0E07\u0E34\u0E19\u0E42\u0E2D\u0E19\u0E02\u0E2D\u0E07\u0E2A\u0E01\u0E38\u0E25 PKR \u0E44\u0E14\u0E49\u0E40\u0E1B\u0E25\u0E35\u0E48\u0E22\u0E19\u0E40\u0E1B\u0E47\u0E19\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E0B\u0E37\u0E49\u0E2D\u0E17\u0E35\u0E48\u0E43\u0E0A\u0E49\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E43\u0E19\u0E15\u0E25\u0E32\u0E14\u0E15\u0E48\u0E32\u0E07\u0E1B\u0E23\u0E30\u0E40\u0E17\u0E28 (\u0E17\u0E2D\u0E21\u0E2A\u0E31\u0E19\u0E23\u0E2D\u0E22\u0E40\u0E15\u0E2D\u0E23\u0E4C) \u0E04\u0E33\u0E19\u0E27\u0E13\u0E1C\u0E48\u0E32\u0E19\u0E2D\u0E31\u0E15\u0E23\u0E32\u0E0B\u0E37\u0E49\u0E2D\u0E02\u0E32\u0E22\u0E40\u0E07\u0E34\u0E19\u0E14\u0E2D\u0E25\u0E25\u0E32\u0E23\u0E4C \u0E2A\u0E23\u0E2D. \u0E43\u0E19\u0E15\u0E25\u0E32\u0E14\u0E01\u0E23\u0E38\u0E07\u0E40\u0E17\u0E1E\u0E2F\"}],\"last_updated\":\"2018-02-14\"},\"data_detail\":[{\"period\":\"2017-02-01\",\"currency_id\":\"USD\",\"currency_name_th\":\"\u0E2A\u0E2B\u0E23\u0E31\u0E10\u0E2D\u0E40\u0E21\u0E23\u0E34\u0E01\u0E32 : \u0E14\u0E2D\u0E25\u0E25\u0E32\u0E23\u0E4C (USD)\",\"currency_name_eng\":\"USA : DOLLAR (USD) \",\"buying_sight\":\"34.8938000\",\"buying_transfer\":\"34.9785000\",\"selling\":\"35.3182000\",\"mid_rate\":\"35.1484000\"}]}}}");

                stub.Start();

                var response = await httpClient.GetAsync(new UriBuilder(new Uri(stub.Address)) { Path = "/api/bot/exchange_rate/daily_average/2017-02-01/2017-02-01/USD" }.Uri);

                RootObject repositories = JsonConvert.DeserializeObject<RootObject>(response.Content.ReadAsStringAsync().Result);

                Assert.Equal("35.3182000", repositories.result.data.data_detail[0].selling);
            }
        }

    }
}
