﻿using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using QAToolKit.Core.HttpRequestTools;
using QAToolKit.Core.Models;
using QAToolKit.Core.Test.Fixtures;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
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
        public void GetRequestDataGeneratorWithOneRequest()
        {
            var request = GetUserByIdHttpRequest.Get();
            var replacementValues = new ReplacementValue[] {
            new ReplacementValue(){
                    Key = "userId",
                    Value = "100"
                }
            };

            var generator = new HttpRequestUrlGenerator(request, options =>
            {
                options.AddReplacementValues(replacementValues);
            });

            var url = generator.GetUrl();

            _logger.LogInformation(JsonConvert.SerializeObject(url, Formatting.Indented));

            Assert.NotNull(url);
            Assert.Equal("https://myapi.com/users/100", url);
        }

      /*  [Fact]
        public void PostRequestDataGeneratorWithOneRequest()
        {
            var request = AddNewUserHttpRequest.Get();
            var replacementValues = new ReplacementValue[] {
                new ReplacementValue(){
                        Key = "id",
                        Value = "100"
                    },
                new ReplacementValue(){
                        Key = "name",
                        Value = "Miha J."
                    }
            };

            var generator = new HttpRequestUrlGenerator(request, options =>
            {
                options.AddReplacementValues(new ReplacementValue[] {
               new ReplacementValue(){
                        Key = "id",
                        Value = "100"
                    },
                new ReplacementValue(){
                        Key = "name",
                        Value = "Miha J."
                    }
                });
            });

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":100,""name"":""Miha J.""}", (string)body);
        }*/

     /*   [Fact]
        public void ReplaceBodyTest_Successfull()
        {
            var content = File.ReadAllText("Assets/addPet.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestUrlGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new ReplacementValue[] {
                new ReplacementValue(){
                        Key = "id",
                        Value = "100"
                    },
                new ReplacementValue(){
                        Key = "name",
                        Value = "Miha J."
                    },
                new ReplacementValue(){
                        Key = "category",
                        Value = "{\"id\":1,\"name\":\"dog\"}"
                    }
                });
            });

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":100,""name"":""Miha J."",""Category"":{""id"":1,""name"":""dog""}}", (string)body);
        }*/

        [Fact]
        public void ReplacePathTest_Successfull()
        {
            var content = File.ReadAllText("Assets/getPetById.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestUrlGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new ReplacementValue[] {
                new ReplacementValue(){
                        Key = "petId",
                        Value = "1000"
                    },
                new ReplacementValue(){
                        Key = "name",
                        Value = "Miha J."
                    }
                });
            });

            var url = generator.GetUrl();

            _logger.LogInformation(url.ToString());

            Assert.Equal("https://petstore3.swagger.io/api/v3/pet/1000", url.ToString());
        }

        [Fact]
        public void ReplacePathAndUrlTest_Successfull()
        {
            var content = File.ReadAllText("Assets/getPetByIdAndStatus.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestUrlGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new ReplacementValue[] {
                new ReplacementValue(){
                        Key = "petId",
                        Value = "1000"
                    },
                new ReplacementValue(){
                        Key = "status",
                        Value = 2
                    }
                });
            });

            var url = generator.GetUrl();

            _logger.LogInformation(url.ToString());

            Assert.Equal("https://petstore3.swagger.io/api/v3/pet/1000?status=2", url.ToString());
        }
    }
}
