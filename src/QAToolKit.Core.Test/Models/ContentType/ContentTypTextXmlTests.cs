using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeTextXmlTests
    {
        [Fact]
        public void ContentTypeTextXmlTestsPresent_Success()
        {
            Assert.Equal("text/xml", ContentType.TextXml.Value());
        }

        [Theory]
        [InlineData("text/xml")]
        public void ConvertXmlFromString_Success(string value)
        {
            Assert.Equal(ContentType.TextXml, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.TextXml)]
        public void ConvertXmlFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.TextXml, ContentType.From(value));
        }

        [Fact]
        public void ConvertXmlObjectToString_Success()
        {
            Assert.Equal("text/xml", ContentType.TextXml.Value());
        }

        [Fact]
        public void ConvertXmlObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextXml, ContentType.ToEnum(ContentType.TextXml));
        }

        [Fact]
        public void ConvertXmlStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextXml, ContentType.ToEnum("text/xml"));
        }

        [Fact]
        public void ConvertXmlStringToContentType_Success()
        {
            Assert.Equal(ContentType.TextXml, ContentType.From("text/xml"));
        }
    }
}
