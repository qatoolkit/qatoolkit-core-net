using QAToolKit.Core.Exceptions;
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

        [Theory]
        [InlineData("@integrationtest")]
        public void ConverIntegrationTestFromString_Success(string value)
        {
            Assert.Equal(TestType.IntegrationTest, TestType.From(value));
        }

        [Theory]
        [InlineData("@loadtest")]
        public void ConvertLoadTestFromString_Success(string value)
        {
            Assert.Equal(TestType.LoadTest, TestType.From(value));
        }

        [Theory]
        [InlineData("@sqltest")]
        public void ConvertSqlTestFromString_Success(string value)
        {
            Assert.Equal(TestType.SqlTest, TestType.From(value));
        }

        [Theory]
        [InlineData("@securitytest")]
        public void ConvertSecurityTestFromString_Success(string value)
        {
            Assert.Equal(TestType.SecurityTest, TestType.From(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("somestring")]
        public void ConvertFromString_Fails(string value)
        {
            Assert.Throws<QAToolKitCoreException>(() => TestType.From(value));
        }

        [Theory]
        [InlineData(TestType.Enumeration.IntegrationTest)]
        public void ConverIntegrationTestFromEnum_Success(TestType.Enumeration value)
        {
            Assert.Equal(TestType.IntegrationTest, TestType.From(value));
        }

        [Theory]
        [InlineData(TestType.Enumeration.LoadTest)]
        public void ConvertXmlFromEnum_Success(TestType.Enumeration value)
        {
            Assert.Equal(TestType.LoadTest, TestType.From(value));
        }

        [Theory]
        [InlineData(TestType.Enumeration.SqlTest)]
        public void ConvertSqlTestFromEnum_Success(TestType.Enumeration value)
        {
            Assert.Equal(TestType.SqlTest, TestType.From(value));
        }

        [Theory]
        [InlineData(TestType.Enumeration.SecurityTest)]
        public void ConvertSecurityTestFromEnum_Success(TestType.Enumeration value)
        {
            Assert.Equal(TestType.SecurityTest, TestType.From(value));
        }

        [Fact]
        public void ConvertIntegrationTestObjectToString_Success()
        {
            Assert.Equal("@integrationtest", TestType.IntegrationTest.Value());
        }

        [Fact]
        public void ConvertLoadTestObjectToString_Success()
        {
            Assert.Equal("@loadtest", TestType.LoadTest.Value());
        }

        [Fact]
        public void ConvertSqlTestObjectToString_Success()
        {
            Assert.Equal("@sqltest", TestType.SqlTest.Value());
        }

        [Fact]
        public void ConvertSecurityTestObjectToString_Success()
        {
            Assert.Equal("@securitytest", TestType.SecurityTest.Value());
        }

        [Fact]
        public void ConvertIntegrationTestObjectToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.IntegrationTest, TestType.ToEnum(TestType.IntegrationTest));
        }

        [Fact]
        public void ConvertLoadTestObjectToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.LoadTest, TestType.ToEnum(TestType.LoadTest));
        }

        [Fact]
        public void ConvertSqlTestObjectToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.SqlTest, TestType.ToEnum(TestType.SqlTest));
        }

        [Fact]
        public void ConvertSecurityTestObjectToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.SecurityTest, TestType.ToEnum(TestType.SecurityTest));
        }

        [Fact]
        public void ConvertIntegrationTestStringToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.IntegrationTest, TestType.ToEnum("@integrationtest"));
        }

        [Fact]
        public void ConvertLoadTestStringToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.LoadTest, TestType.ToEnum("@loadtest"));
        }

        [Fact]
        public void ConvertSqlTestStringToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.SqlTest, TestType.ToEnum("@sqltest"));
        }

        [Fact]
        public void ConvertSecurityTestStringToEnum_Success()
        {
            Assert.Equal(TestType.Enumeration.SecurityTest, TestType.ToEnum("@securitytest"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("somestring")]
        public void ConvertStringToEnum_Fails(string value)
        {
            Assert.Throws<QAToolKitCoreException>(() => TestType.ToEnum(value));
        }

        [Fact]
        public void ConvertIntegrationTestStringToTestType_Success()
        {
            Assert.Equal(TestType.IntegrationTest, TestType.From("@integrationtest"));
        }

        [Fact]
        public void ConvertLoadTestStringToTestType_Success()
        {
            Assert.Equal(TestType.LoadTest, TestType.From("@loadtest"));
        }

        [Fact]
        public void ConvertSqlTestStringToTestType_Success()
        {
            Assert.Equal(TestType.SqlTest, TestType.From("@sqltest"));
        }

        [Fact]
        public void ConvertSecurityTestStringToTestType_Success()
        {
            Assert.Equal(TestType.SecurityTest, TestType.From("@securitytest"));
        }
    }
}
