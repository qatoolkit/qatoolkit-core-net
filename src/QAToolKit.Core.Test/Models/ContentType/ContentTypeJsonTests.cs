using QAToolKit.Core.Exceptions;
using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeJsonTests
    {
        [Fact]
        public void ContentTypeJsonTestsPresent_Success()
        {
            Assert.Equal("application/json", ContentType.Json.Value());
        }

        [Theory]
        [InlineData("application/json")]
        public void ConverJsonFromString_Success(string value)
        {
            Assert.Equal(ContentType.Json, ContentType.From(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("somestring")]
        public void ConvertFromString_Fails(string value)
        {
            Assert.Throws<QAToolKitCoreException>(() => ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.Json)]
        public void ConverJsonFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.Json, ContentType.From(value));
        }

        [Fact]
        public void ConvertJsonObjectToString_Success()
        {
            Assert.Equal("application/json", ContentType.Json.Value());
        }

        [Fact]
        public void ConvertJsonObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Json, ContentType.ToEnum(ContentType.Json));
        }

        [Fact]
        public void ConvertJsonStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Json, ContentType.ToEnum("application/json"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("somestring")]
        public void ConvertStringToEnum_Fails(string value)
        {
            Assert.Throws<QAToolKitCoreException>(() => ContentType.ToEnum(value));
        }

        [Fact]
        public void ConvertJsonStringToContentType_Success()
        {
            Assert.Equal(ContentType.Json, ContentType.From("application/json"));
        }
    }
}
