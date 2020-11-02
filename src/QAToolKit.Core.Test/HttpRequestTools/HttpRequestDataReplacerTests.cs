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

            var generator = new HttpRequestDataReplacer(request, replacementValues);

            var path = generator.ReplacePathParameters();
            var query = generator.ReplaceQueryParameters();

            _logger.LogInformation(JsonConvert.SerializeObject(path, Formatting.Indented));

            Assert.Equal("/users/100", path);
            Assert.Null(query);
        }

        [Fact]
        public void PostRequestDataGeneratorWithOneRequest()
        {
            var requests = AddNewUserHttpRequest.Get();
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

            var generator = new HttpRequestDataReplacer(requests, replacementValues);

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":100,""name"":""Miha J.""}", (string)body);
        }

        [Fact]
        public async Task ReplaceBodyTest_Successfull()
        {
            var content = File.ReadAllText("Assets/addPet.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);
            
            var generator = new HttpRequestDataReplacer(requests.FirstOrDefault(), new ReplacementValue[] {
                new ReplacementValue(){
                        Key = "id",
                        Value = "100"
                    },
                new ReplacementValue(){
                        Key = "name",
                        Value = "Miha J."
                    }
            });

            var body = generator.ReplaceRequestBodyModel(ContentType.Enumeration.Json);

            _logger.LogInformation(JsonConvert.SerializeObject(body, Formatting.Indented));

            Assert.Equal(@"{""id"":100,""name"":""Miha J.""}", (string)body);
        }

        [Fact]
        public async Task ReplacePathTest_Successfull()
        {
            var content = File.ReadAllText("Assets/getPetById.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestDataReplacer(requests.FirstOrDefault(), new ReplacementValue[] {
                new ReplacementValue(){
                        Key = "petId",
                        Value = "1000"
                    },
                new ReplacementValue(){
                        Key = "name",
                        Value = "Miha J."
                    }
            });

            var url = generator.ReplaceUrlParameters();

            _logger.LogInformation(url.ToString());

            Assert.Equal("/pet/1000", url.ToString());
        }

        [Fact]
        public async Task ReplacePathAndUrlTest_Successfull()
        {
            var content = File.ReadAllText("Assets/getPetByIdAndStatus.json");
            var requests = JsonConvert.DeserializeObject<IList<HttpRequest>>(content);

            var generator = new HttpRequestDataReplacer(requests.FirstOrDefault(), new ReplacementValue[] {
                new ReplacementValue(){
                        Key = "petId",
                        Value = "1000"
                    },
                new ReplacementValue(){
                        Key = "status",
                        Value = 2
                    }
            });

            var url = generator.ReplaceUrlParameters();

            _logger.LogInformation(url.ToString());

            Assert.Equal("/pet/1000?status=2", url.ToString());
        }
    }
}
