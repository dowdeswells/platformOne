using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using leases.api.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Xunit;

namespace leases.api.test
{
    public class ValuesTests : IClassFixture<WebApplicationFactory<Startup>>
    {
        private readonly WebApplicationFactory<Startup> _factory;

        public ValuesTests(WebApplicationFactory<Startup> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetValuesReturns3Values()
        {
            var client = CreateTestConfiguredHttpClient();
            var response = await client.GetAsync("/api/values");

            var json = await response.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<string[]>(json);
            Assert.Equal(3, values.Length);
        }

        private HttpClient CreateTestConfiguredHttpClient()
        {
            var client = _factory.WithWebHostBuilder(b =>
                    b.ConfigureTestServices(services =>
                    {
                        services.AddTransient<IValuesRepository, TestValuesRepository>();
                    }))
                .CreateClient();
            return client;
        }
    }

    public class TestValuesRepository : IValuesRepository
    {
        public IEnumerable<string> GetAll()
        {
            return new[] {"TestValue1", "TestValue2", "TestValue3"};
        }
    }
}