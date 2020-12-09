using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeOctetTests
    {
        [Fact]
        public void ContentTypeBinaryTestsPresent_Success()
        {
            Assert.Equal("application/octet-stream", ContentType.OctetStream.Value());
        }

        [Theory]
        [InlineData("application/octet-stream")]
        public void ConvertBinaryFromString_Success(string value)
        {
            Assert.Equal(ContentType.OctetStream, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.OctetStream)]
        public void ConvertBinaryFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.OctetStream, ContentType.From(value));
        }

        [Fact]
        public void ConvertBinaryObjectToString_Success()
        {
            Assert.Equal("application/octet-stream", ContentType.OctetStream.Value());
        }

        [Fact]
        public void ConvertBinaryObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.OctetStream, ContentType.ToEnum(ContentType.OctetStream));
        }

        [Fact]
        public void ConvertBinaryStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.OctetStream, ContentType.ToEnum("application/octet-stream"));
        }

        [Fact]
        public void ConvertBinaryStringToContentType_Success()
        {
            Assert.Equal(ContentType.OctetStream, ContentType.From("application/octet-stream"));
        }
    }
}
