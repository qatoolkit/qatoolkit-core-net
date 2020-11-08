using Microsoft.Extensions.Logging;
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
    public class HttpRequestBodyGeneratorTests
    {
        private readonly ILogger<HttpRequestBodyGeneratorTests> _logger;

        public HttpRequestBodyGeneratorTests(ITestOutputHelper testOutputHelper)
        {
            var loggerFactory = new LoggerFactory();
            loggerFactory.AddProvider(new XunitLoggerProvider(testOutputHelper));
            _logger = loggerFactory.CreateLogger<HttpRequestBodyGeneratorTests>();
        }

        [Fact]
        public void GetRequestDataGeneratorWithOneRequest()
        {
            var request = GetUserByIdHttpRequest.Get();


            var generator = new HttpRequestUrlGenerator(request, options =>
            {
                options.AddReplacementValues(new Dictionary<string, object> {
                    {
                     "userId",
                      "100"
                    }
                });
            });

            var url = generator.GetUrl();

            _logger.LogInformation(JsonConvert.SerializeObject(url, Formatting.Indented));

            Assert.NotNull(url);
            Assert.Equal("https://myapi.com/users/100", url);
        }

        [Fact]
        public void PostRequestDataGeneratorWithOneRequest()
        {
            var request = AddNewUserHttpRequest.Get();
            var replacementValues = new Dictionary<string, object> {
                  {
                     "id",
                      "100"
                    },
                  {
                     "name",
                      "Miha J."
                    }
              };

            var generator = new HttpRequestBodyGenerator(request, options =>
            {
                options.AddReplacementValues(replacementValues);
            });

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":100,""name"":""Miha J.""}", (string)body);
        }

        [Fact]
        public void ReplaceBodyTest_Successfull()
        {
            var content = File.ReadAllText("Assets/addPet.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestBodyGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new Dictionary<string, object>(){
                   {
                     "id",
                      "100"
                   },
                   {
                     "name",
                      "Miha J."
                   },
                   {
                     "Category",
                      "{\"id\":1,\"name\":\"dog\"}"
                   }
                });
            });

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":100,""name"":""Miha J."",""Category"":{""id"":1,""name"":""dog""}}", (string)body);
        }

        [Fact]
        public void ReplaceBodyTestWithLowCaseModelName_Successfull()
        {
            var content = File.ReadAllText("Assets/addPet.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestBodyGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new Dictionary<string, object> {
                   {
                     "id",
                      "100"
                   },
                   {
                     "Name",
                      "Miha J."
                   },
                   {
                     "category",
                      "{\"id\":1,\"name\":\"dog\"}"
                   }
                });
            });

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":100,""name"":""Miha J."",""Category"":{""id"":1,""name"":""dog""}}", (string)body);
        }

        [Fact]
        public void ReplacePathTest_Successfull()
        {
            var content = File.ReadAllText("Assets/getPetById.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestUrlGenerator(requests.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new Dictionary<string, object> {
                    {
                     "petId",
                      "1000"
                    },
                    {
                     "name",
                      "Miha J."
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
                options.AddReplacementValues(new Dictionary<string, object> {
                    {
                     "petId",
                      "1000"
                    },
                    {
                       "status",
                        2
                    }
                });
            });

            var url = generator.GetUrl();

            _logger.LogInformation(url.ToString());

            Assert.Equal("https://petstore3.swagger.io/api/v3/pet/1000?status=2", url.ToString());
        }

        [Fact]
        public void ReplaceHttpBodyForAddBikeAndOptionsTest_Successfull()
        {

            var content = File.ReadAllText("Assets/AddBike.json");
            var httpRequest = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestBodyGenerator(httpRequest.FirstOrDefault(), options =>
            {
                options.AddReplacementValues(new Dictionary<string, object> {
                    {"Bicycle",@"{""id"":66,""name"":""my bike"",""brand"":""cannondale"",""BicycleType"":1}"}
                });
            });

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":66,""name"":""my bike"",""brand"":""cannondale"",""BicycleType"":1}", (string)body);
        }
    }
}
