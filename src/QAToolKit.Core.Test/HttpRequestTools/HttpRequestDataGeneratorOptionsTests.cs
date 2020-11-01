using QAToolKit.Core.HttpRequestTools;
using Xunit;

namespace QAToolKit.Core.Test.HttpRequestTools
{
    public class HttpRequestDataGeneratorOptionsTests
    {
        [Fact]
        public void SwaggerAddDataGenerationOnRequestFiltersTest_Successful()
        {
            var options = new HttpRequestDataGeneratorOptions();
            options.AddDataGeneration();

            Assert.True(options.UseDataGeneration);
        }

        [Fact]
        public void SwaggerAddDataGenerationOffRequestFiltersTest_Successful()
        {
            var options = new HttpRequestDataGeneratorOptions();

            Assert.False(options.UseDataGeneration);
        }
    }
}