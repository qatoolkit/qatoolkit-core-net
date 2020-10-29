using QAToolKit.Core.Models;
using System;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeTests
    {
        [Fact]
        public void IntegrationTestTypesPresent_Success()
        {
            Assert.Equal("application/json", ContentType.Json.Value());
        }

        [Fact]
        public void LoadTestTypesPresent_Success()
        {
            Assert.Equal("application/xml", ContentType.Xml.Value());
        }

        [Fact]
        public void SqlTestTypesPresent_Success()
        {
            Assert.Equal("application/x-www-form-urlencoded", ContentType.FormUrlEncoded.Value());
        }

        [Theory]
        [InlineData("application/json")]
        public void ConverJsontFromString_Success(string value)
        {
            Assert.Equal(ContentType.Json, ContentType.FromString(value));
        }

        [Theory]
        [InlineData("application/xml")]
        public void ConvertXmlFromString_Success(string value)
        {
            Assert.Equal(ContentType.Xml, ContentType.FromString(value));
        }

        [Theory]
        [InlineData("application/x-www-form-urlencoded")]
        public void ConvertFormFromString_Success(string value)
        {
            Assert.Equal(ContentType.FormUrlEncoded, ContentType.FromString(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("application/pdf")]
        public void ConvertFromString_Fails(string value)
        {
            Assert.Throws<Exception>(() => ContentType.FromString(value));
        }
    }
}
