using QAToolKit.Core.HttpRequestTools;
using QAToolKit.Core.Models;
using System.Linq;
using Xunit;

namespace QAToolKit.Core.Test.HttpRequestTools
{
    public class DataReplacementOptionsTests
    {
        [Fact]
        public void SwaggerAddReplacementValuesTest_Successful()
        {
            var options = new DataReplacementOptions();
            options.AddReplacementValues(new ReplacementValue[] {
                new ReplacementValue() {
                    Key = "userId",
                    Value = "1"
                },
                new ReplacementValue() {
                    Key = "roleId",
                    Value = "100"
                }
            });

            Assert.Equal(2, options.ReplacementValues.Count());
            Assert.Equal("userId", options.ReplacementValues[0].Key);
            Assert.Equal("1", options.ReplacementValues[0].Value);
            Assert.Equal("roleId", options.ReplacementValues[1].Key);
            Assert.Equal("100", options.ReplacementValues[1].Value);
        }
    }
}
