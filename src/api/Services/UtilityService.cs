using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using api.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace api.Services
{
    public class UtilityService
    {
        private readonly UtilityContext _context;

        public UtilityService(UtilityContext context)
        {
            _context = context;
        }

        public IEnumerable<Zipcode> ListZipcode()
        {
            return _context.Zipcode.ToList();
        }

        public IEnumerable<Zipcode> ListZipcode_by_Province_Code(string id)
        {
            IEnumerable<Zipcode> listResult = _context.Zipcode
                    .Where(m => m.PROVINCE_CODE == int.Parse(id) && m.ZIP_CODE != 0 )
                    .GroupBy(m => m.ZIP_CODE)
                    .Select(m => m.FirstOrDefault())
                    .OrderBy(m => m.ZIP_CODE)
                    .ToList();

            return listResult;
        }

        public IConfiguration Configuration { get; set;}
        public String Get_Config_Text()
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
		        .AddJsonFile($"appsettings.{environment}.json", optional: true);

            Configuration = builder.Build();

            return Configuration["Test:Name"];
        }
    }

}
