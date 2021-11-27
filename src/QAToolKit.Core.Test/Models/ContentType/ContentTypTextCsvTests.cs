using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeTextCsvTests
    {
        [Fact]
        public void ContentTypeTextCSvTestsPresent_Success()
        {
            Assert.Equal("text/csv", ContentType.TextCsv.Value());
        }

        [Theory]
        [InlineData("text/csv")]
        public void ConvertCSvFromString_Success(string value)
        {
            Assert.Equal(ContentType.TextCsv, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.TextCsv)]
        public void ConvertCSvFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.TextCsv, ContentType.From(value));
        }

        [Fact]
        public void ConvertCSvObjectToString_Success()
        {
            Assert.Equal("text/csv", ContentType.TextCsv.Value());
        }

        [Fact]
        public void ConvertCSvObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextCsv, ContentType.ToEnum(ContentType.TextCsv));
        }

        [Fact]
        public void ConvertCSvStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.TextCsv, ContentType.ToEnum("text/csv"));
        }

        [Fact]
        public void ConvertCSvStringToContentType_Success()
        {
            Assert.Equal(ContentType.TextCsv, ContentType.From("text/csv"));
        }
    }
}
