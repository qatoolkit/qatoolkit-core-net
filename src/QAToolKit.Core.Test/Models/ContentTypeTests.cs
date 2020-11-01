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
        public void ConverJsonFromString_Success(string value)
        {
            Assert.Equal(ContentType.Json, ContentType.From(value));
        }

        [Theory]
        [InlineData("application/xml")]
        public void ConvertXmlFromString_Success(string value)
        {
            Assert.Equal(ContentType.Xml, ContentType.From(value));
        }

        [Theory]
        [InlineData("application/x-www-form-urlencoded")]
        public void ConvertFormFromString_Success(string value)
        {
            Assert.Equal(ContentType.FormUrlEncoded, ContentType.From(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("application/pdf")]
        public void ConvertFromString_Fails(string value)
        {
            Assert.Throws<Exception>(() => ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.Json)]
        public void ConverJsonFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.Json, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.Xml)]
        public void ConvertXmlFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.Xml, ContentType.From(value));
        }

        [Theory]
        [InlineData(ContentType.Enumeration.FormUrlEncoded)]
        public void ConvertFormFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.FormUrlEncoded, ContentType.From(value));
        }

        [Fact]
        public void ConvertJsonObjectToString_Success()
        {
            Assert.Equal("application/json", ContentType.Json.Value());
        }

        [Fact]
        public void ConvertXmlObjectToString_Success()
        {
            Assert.Equal("application/xml", ContentType.Xml.Value());
        }

        [Fact]
        public void ConvertFormObjectToString_Success()
        {
            Assert.Equal("application/x-www-form-urlencoded", ContentType.FormUrlEncoded.Value());
        }

        [Fact]
        public void ConvertJsonObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Json, ContentType.ToEnum(ContentType.Json));
        }

        [Fact]
        public void ConvertXmlObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Xml, ContentType.ToEnum(ContentType.Xml));
        }

        [Fact]
        public void ConvertFormObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.FormUrlEncoded, ContentType.ToEnum(ContentType.FormUrlEncoded));
        }

        [Fact]
        public void ConvertJsonStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Json, ContentType.ToEnum("application/json"));
        }

        [Fact]
        public void ConvertXmlStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.Xml, ContentType.ToEnum("application/xml"));
        }

        [Fact]
        public void ConvertFormStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.FormUrlEncoded, ContentType.ToEnum("application/x-www-form-urlencoded"));
        }
    }
}
