using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QAToolKit.Core.HttpRequestTools;
using QAToolKit.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace QAToolKit.Core.Test.HttpRequestTools
{
    public class HttpUrlGeneratorTests
    {
        private readonly ILogger<HttpUrlGeneratorTests> _logger;

        public HttpUrlGeneratorTests(ITestOutputHelper testOutputHelper)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
            _logger = loggerFactory.CreateLogger<HttpUrlGeneratorTests>();
        }

        [Fact]
        public void GenerateUrlAddPetTest_Success()
        {
            var content = File.ReadAllText("Assets/addPet.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var urlGenerator = new HttpRequestUrlGenerator(requests.FirstOrDefault());
            _logger.LogInformation(urlGenerator.GetUrl());

            Assert.Equal("https://petstore3.swagger.io/api/v3/pet", urlGenerator.GetUrl());
        }

        [Fact]
        public void GenerateUrlGetPetByIdAndStatusTest_Success()
        {
            var content = File.ReadAllText("Assets/getPetByIdAndStatus.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var urlGenerator = new HttpRequestUrlGenerator(requests.FirstOrDefault());
            _logger.LogInformation(urlGenerator.GetUrl());

            Assert.Equal("https://petstore3.swagger.io/api/v3/pet/{petId}?status={status}", urlGenerator.GetUrl());
        }

        [Fact]
        public void GenerateUrlGetPetByIdTest_Success()
        {
            var content = File.ReadAllText("Assets/getPetById.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var urlGenerator = new HttpRequestUrlGenerator(requests.FirstOrDefault());
            _logger.LogInformation(urlGenerator.GetUrl());

            Assert.Equal("https://petstore3.swagger.io/api/v3/pet/{petId}", urlGenerator.GetUrl());
        }

        [Fact]
        public void GenerateUrlNoRequestsTest_Fails()
        {
            var content = File.ReadAllText("Assets/addPet.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            Assert.Throws<ArgumentNullException>(() => new HttpRequestUrlGenerator(null));
        }
    }
}
