using QAToolKit.Core.Exceptions;
using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeTextJsonTests
    {
        [Fact]
        public void ContentTypeTextJsonTestsPresent_Success()
        {
            Assert.Equal("text/json", ContentType.TextJson.Value());
        }

        [Theory]
        [InlineData("text/json")]
        public void ContentTypeTextJsonFromString_Success(string value)
        {
            Assert.Equal(ContentType.TextJson, ContentType.From(value));
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
        [InlineData(ContentType.Enumeration.TextJson)]
        public void ConverTextJsonFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.TextJson, ContentType.From(value));
        }

        [Fact]
        public void ConvertTextJsonObjectToString_Success()
        {
            Assert.Equal("text/json", ContentType.TextJson.Value());
        }

        [Fact]
        public void ConvertTextJsonObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextJson, ContentType.ToEnum(ContentType.TextJson));
        }

        [Fact]
        public void ConvertTextJsonStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextJson, ContentType.ToEnum("text/json"));
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
        public void ConvertTextJsonStringToContentType_Success()
        {
            Assert.Equal(ContentType.TextJson, ContentType.From("text/json"));
        }
    }
}
