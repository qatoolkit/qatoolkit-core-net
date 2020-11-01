using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QAToolKit.Core.HttpRequestTools;
using QAToolKit.Core.Models;
using QAToolKit.Core.Test.Fixtures;
using System.Linq;
using Xunit;
using Xunit.Abstractions;

namespace QAToolKit.Core.Test.HttpRequestTools
{
    public class HttpRequestDataReplacerTests
    {
        private readonly ILogger<HttpRequestDataReplacerTests> _logger;

        public HttpRequestDataReplacerTests(ITestOutputHelper testOutputHelper)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
            _logger = loggerFactory.CreateLogger<HttpRequestDataReplacerTests>();
        }

        [Fact]
        public void DataGeneratorWithOneRequest()
        {
            var requests = GetUserByIdHttpRequest.Get();
            var replacementValues = new ReplacementValue[] {
            new ReplacementValue(){
                    Key = "userId",
                    Value = "100"
                }
            };

            var generator = new HttpRequestDataReplacer(requests, replacementValues);

            var results = generator.ReplaceAll();

            _logger.LogInformation(JsonConvert.SerializeObject(results, Formatting.Indented));

            Assert.Equal("/users/100", results.FirstOrDefault().Path);
        }
    }
}
