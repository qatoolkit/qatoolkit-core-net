using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeMultipartTests
    {
        [Fact]
        public void ContentTypeMultipartTestsPresent_Success()
        {
            Assert.Equal("multipart/form-data", ContentType.MultipartFormData.Value());
        }

        [Theory]
        [InlineData("multipart/form-data")]
        public void ConvertMultipartFromString_Success(string value)
        {
            Assert.Equal(ContentType.MultipartFormData, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.MultipartFormData)]
        public void ConvertMultipartFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.MultipartFormData, ContentType.From(value));
        }

        [Fact]
        public void ConvertMultipartObjectToString_Success()
        {
            Assert.Equal("multipart/form-data", ContentType.MultipartFormData.Value());
        }

        [Fact]
        public void ConvertMultipartObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.MultipartFormData, ContentType.ToEnum(ContentType.MultipartFormData));
        }

        [Fact]
        public void ConvertMultipartStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.MultipartFormData, ContentType.ToEnum("multipart/form-data"));
        }

        [Fact]
        public void ConvertMultipartStringToContentType_Success()
        {
            Assert.Equal(ContentType.MultipartFormData, ContentType.From("multipart/form-data"));
        }
    }
}
