using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace AspDotNetAppsProgramming.Test
{
    public class ExchangesTests
    {
        private HttpClient _client;

        [SetUp]
        public void CreateServer()
        {
            var factory = new WebApplicationFactory<Startup>();
            _client = factory.CreateClient();
        }

        [Test]
        public async Task Given_RequestExecuted_Expect_SuccessResponse()
        {
            var response = await _client.GetAsync("/api/exchanges");

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
        }
    }
}