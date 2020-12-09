using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeFormTests
    {
        [Fact]
        public void ContentTypeFormTestsPresent_Success()
        {
            Assert.Equal("application/x-www-form-urlencoded", ContentType.FormUrlEncoded.Value());
        }

        [Theory]
        [InlineData("application/x-www-form-urlencoded")]
        public void ConvertFormFromString_Success(string value)
        {
            Assert.Equal(ContentType.FormUrlEncoded, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.FormUrlEncoded)]
        public void ConvertFormFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.FormUrlEncoded, ContentType.From(value));
        }

        [Fact]
        public void ConvertFormObjectToString_Success()
        {
            Assert.Equal("application/x-www-form-urlencoded", ContentType.FormUrlEncoded.Value());
        }

        [Fact]
        public void ConvertFormObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.FormUrlEncoded, ContentType.ToEnum(ContentType.FormUrlEncoded));
        }

        [Fact]
        public void ConvertFormStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.FormUrlEncoded, ContentType.ToEnum("application/x-www-form-urlencoded"));
        }

        [Fact]
        public void ConvertFormStringToContentType_Success()
        {
            Assert.Equal(ContentType.FormUrlEncoded, ContentType.From("application/x-www-form-urlencoded"));
        }
    }
}
