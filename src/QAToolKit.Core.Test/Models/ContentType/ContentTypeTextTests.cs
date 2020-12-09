using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeTextTests
    {
        [Fact]
        public void ContentTypeTextTestsPresent_Success()
        {
            Assert.Equal("text/plain", ContentType.TextPlain.Value());
        }

        [Theory]
        [InlineData("text/plain")]
        public void ConvertFromTextString_Success(string value)
        {
            Assert.Equal(ContentType.TextPlain, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.TextPlain)]
        public void ConvertFromTextEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.TextPlain, ContentType.From(value));
        }

        [Fact]
        public void ConvertTextObjectToString_Success()
        {
            Assert.Equal("text/plain", ContentType.TextPlain.Value());
        }

        [Fact]
        public void ConvertTextObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextPlain, ContentType.ToEnum(ContentType.TextPlain));
        }

        [Fact]
        public void ConvertTextStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextPlain, ContentType.ToEnum("text/plain"));
        }

        [Fact]
        public void ConvertTextStringToContentType_Success()
        {
            Assert.Equal(ContentType.TextPlain, ContentType.From("text/plain"));
        }
    }
}
