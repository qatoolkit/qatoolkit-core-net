using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeXmlTests
    {
        [Fact]
        public void ContentTypeXmlTestsPresent_Success()
        {
            Assert.Equal("application/xml", ContentType.Xml.Value());
        }

        [Theory]
        [InlineData("application/xml")]
        public void ConvertXmlFromString_Success(string value)
        {
            Assert.Equal(ContentType.Xml, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.Xml)]
        public void ConvertXmlFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.Xml, ContentType.From(value));
        }

        [Fact]
        public void ConvertXmlObjectToString_Success()
        {
            Assert.Equal("application/xml", ContentType.Xml.Value());
        }

        [Fact]
        public void ConvertXmlObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Xml, ContentType.ToEnum(ContentType.Xml));
        }

        [Fact]
        public void ConvertXmlStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Xml, ContentType.ToEnum("application/xml"));
        }

        [Fact]
        public void ConvertXmlStringToContentType_Success()
        {
            Assert.Equal(ContentType.Xml, ContentType.From("application/xml"));
        }
    }
}
