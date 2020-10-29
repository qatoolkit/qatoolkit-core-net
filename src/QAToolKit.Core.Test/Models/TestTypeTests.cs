using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class TestTypeTests
    {
        [Fact]
        public void IntegrationTestTypesPresent_Success()
        {
            Assert.Equal("@integrationtest", TestType.IntegrationTest.Value());
        }

        [Fact]
        public void LoadTestTypesPresent_Success()
        {
            Assert.Equal("@loadtest", TestType.LoadTest.Value());
        }

        [Fact]
        public void SqlTestTypesPresent_Success()
        {
            Assert.Equal("@sqltest", TestType.SqlTest.Value());
        }

        [Fact]
        public void SecurityTestTypesPresent_Success()
        {
            Assert.Equal("@securitytest", TestType.SecurityTest.Value());
        }
    }
}
