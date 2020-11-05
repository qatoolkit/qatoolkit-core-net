using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QAToolKit.Core.HttpRequestTools;
using QAToolKit.Core.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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

            Assert.Equal("https://petstore3.swagger.io/api/v3/pet/{petId}", urlGenerator.GetUrl());
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

        [Fact]
        public void GenerateUrlGetAllBikesWithExampleTest_Success()
        {
            var content = File.ReadAllText("Assets/GetAllBikes.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var urlGenerator = new HttpRequestUrlGenerator(requests.FirstOrDefault());
            _logger.LogInformation(urlGenerator.GetUrl());

            Assert.Equal("https://qatoolkitapi.azurewebsites.net/api/bicycles?api-version=1", urlGenerator.GetUrl());
        }

        [Fact]
        public void GenerateUrlGetAllBikesWithReplacedVersionAndTypeTest_Success()
        {
            var content = File.ReadAllText("Assets/GetAllBikes.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var urlGenerator = new HttpRequestUrlGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new ReplacementValue[] {
                    new ReplacementValue(){
                        Key = "api-version",
                        Value = "2"
                    },
                    new ReplacementValue(){
                        Key = "bicycleType",
                        Value = "1"
                    }
                });
            });
            _logger.LogInformation(urlGenerator.GetUrl());

            Assert.Equal("https://qatoolkitapi.azurewebsites.net/api/bicycles?bicycleType=1&api-version=2", urlGenerator.GetUrl());
        }

        [Fact]
        public void GenerateUrlGetAllBikesWithReplacedVersioTest_Success()
        {
            var content = File.ReadAllText("Assets/GetAllBikes.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var urlGenerator = new HttpRequestUrlGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new ReplacementValue[] {
                    new ReplacementValue(){
                        Key = "api-version",
                        Value = "2"
                    }
                });
            });
            _logger.LogInformation(urlGenerator.GetUrl());

            Assert.Equal("https://qatoolkitapi.azurewebsites.net/api/bicycles?api-version=2", urlGenerator.GetUrl());
        }
    }
}
