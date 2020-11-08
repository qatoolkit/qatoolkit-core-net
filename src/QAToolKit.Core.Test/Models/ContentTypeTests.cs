using QAToolKit.Core.Exceptions;
using QAToolKit.Core.Models;
using System;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class ContentTypeTests
    {
        [Fact]
        public void ContentTypeJsonTestsPresent_Success()
        {
            Assert.Equal("application/json", ContentType.Json.Value());
        }

        [Fact]
        public void ContentTypeXmlTestsPresent_Success()
        {
            Assert.Equal("application/xml", ContentType.Xml.Value());
        }

        [Fact]
        public void ContentTypeFormTestsPresent_Success()
        {
            Assert.Equal("application/x-www-form-urlencoded", ContentType.FormUrlEncoded.Value());
        }

        [Fact]
        public void ContentTypeBinaryTestsPresent_Success()
        {
            Assert.Equal("application/octet-stream", ContentType.OctetStream.Value());
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
        [InlineData("application/octet-stream")]
        public void ConvertBinaryFromString_Success(string value)
        {
            Assert.Equal(ContentType.OctetStream, ContentType.From(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("application/pdf")]
        public void ConvertFromString_Fails(string value)
        {
            Assert.Throws<QAToolKitCoreException>(() => ContentType.From(value));
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

        [Theory]
        [InlineData(ContentType.Enumeration.OctetStream)]
        public void ConvertBinaryFromEnum_Success(ContentType.Enumeration value)
        {
            Assert.Equal(ContentType.OctetStream, ContentType.From(value));
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
        public void ConvertBinaryObjectToString_Success()
        {
            Assert.Equal("application/octet-stream", ContentType.OctetStream.Value());
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
        public void ConvertBinaryObjectToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.OctetStream, ContentType.ToEnum(ContentType.OctetStream));
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

        [Fact]
        public void ConvertBinaryStringToEnum_Success()
        {
            Assert.Equal(ContentType.Enumeration.OctetStream, ContentType.ToEnum("application/octet-stream"));
        }
    }
}
