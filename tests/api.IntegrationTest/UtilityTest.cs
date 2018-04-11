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
using api.Services;
using api.Models;

namespace api.IntegrationTest
{
    [Collection("SystemCollection")]
    public class UtilityTest
    {    

        public UtilityContext _context;
        [Fact]
        public void When_Get_Config_Test_Mobile_Should_Be_0123456789()
        {
            UtilityService utilityService = new UtilityService(_context);
            var actualResult = utilityService.Get_Config_Text();

            Assert.Equal("0123456789", actualResult);
        }

    }
}
