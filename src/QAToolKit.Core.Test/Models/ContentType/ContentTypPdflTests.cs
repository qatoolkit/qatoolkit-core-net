using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypePdfTests
    {
        [Fact]
        public void ContentTypePdfTestsPresent_Success()
        {
            Assert.Equal("application/pdf", ContentType.Pdf.Value());
        }

        [Theory]
        [InlineData("application/pdf")]
        public void ConvertXmlFromString_Success(string value)
        {
            Assert.Equal(ContentType.Pdf, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.Pdf)]
        public void ConvertXmlFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.Pdf, ContentType.From(value));
        }

        [Fact]
        public void ConvertXmlObjectToString_Success()
        {
            Assert.Equal("application/pdf", ContentType.Pdf.Value());
        }

        [Fact]
        public void ConvertXmlObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Pdf, ContentType.ToEnum(ContentType.Pdf));
        }

        [Fact]
        public void ConvertXmlStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Pdf, ContentType.ToEnum("application/pdf"));
        }

        [Fact]
        public void ConvertXmlStringToContentType_Success()
        {
            Assert.Equal(ContentType.Pdf, ContentType.From("application/pdf"));
        }
    }
}
