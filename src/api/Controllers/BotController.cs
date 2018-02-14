using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using api.Models;
using Microsoft.AspNetCore.Authorization;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class BotController : Controller
    {
        private readonly BotService _service;

        public BotController(BotService service)
        {
            _service = service;
        }


        /// <summary>
        /// Test Ping
        /// </summary>
        [HttpGet]
        [Route("ping")]
        public IActionResult Ping()
        {
            return Ok();
        }

        /// <summary>
        /// Get Exchange Rate Average by daily from BOT
        /// </summary>
        [HttpGet("exchange_rate/daily_average/{start_date}/{end_date}/{currency}")]
        public JsonResult ExchangeRateDailyAverage(string start_date, string end_date, string currency)
        {
            object result = _service.ExchangeRateDailyAverage(start_date, end_date, currency);
            return Json(result);
        }
    }
}
