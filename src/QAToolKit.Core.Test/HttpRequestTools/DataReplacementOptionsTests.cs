using QAToolKit.Core.HttpRequestTools;
using QAToolKit.Core.Models;
using System.Collections.Generic;
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
            options.AddReplacementValues(new Dictionary<string, object> {
                {
                    "userId",
                    "1"
                },
               {
                    "roleId",
                    "100"
                }
            });

            Assert.Equal(2, options.ReplacementValues.Count());
            Assert.True(options.ReplacementValues.ContainsKey("userId"));
            options.ReplacementValues.TryGetValue("userId", out var val1);
            Assert.Equal("1", val1);

            Assert.True(options.ReplacementValues.ContainsKey("roleId"));
            options.ReplacementValues.TryGetValue("roleId", out var val2);
            Assert.Equal("100", val2);
        }
    }
}
