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
        private static readonly BotHttpClient _botService = new BotHttpClient();
        private double _feePercent = 0.03;

        public double GetFeeFromExchangeRate(double exchangeRate) {
            return exchangeRate * _feePercent;
        }

        public string ExchangeRateDailyAverageWithFee(string start_date="2002-01-12", string end_date="2002-01-15", string currency="USD") {
            

            RootObject exchangeRateJson = ExchangeRateDailyAverage(start_date, end_date, currency);
            double exchangeRate = Double.Parse(exchangeRateJson.result.data.data_detail[0].selling);

            return Math.Round(exchangeRate + GetFeeFromExchangeRate(exchangeRate), 2, MidpointRounding.AwayFromZero).ToString();
        }

        public RootObject ExchangeRateDailyAverage(string start_date="2002-01-12", string end_date="2002-01-15", string currency="USD")
        {
            string url = "https://iapi.bot.or.th/Stat/Stat-ExchangeRate/DAILY_AVG_EXG_RATE_V1/?start_period="+start_date+"&end_period="+end_date+"&currency="+currency;

            RootObject result = _botService.CallGet(url).Result;

            return result;
        }

    }

}
