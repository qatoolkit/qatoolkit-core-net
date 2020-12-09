using QAToolKit.Core.Exceptions;
using QAToolKit.Core.Models;
using Xunit;

namespace QAToolKit.Core.Test.Models
{
    public class AuthenticationTypeTests
    {
        [Fact]
        public void AdminAuthenticationTypesPresent_Success()
        {
            Assert.Equal("@administrator", AuthenticationType.Administrator.Value());
        }

        [Fact]
        public void CustomerAuthenticationTypesPresent_Success()
        {
            Assert.Equal("@customer", AuthenticationType.Customer.Value());
        }

        [Fact]
        public void ApiKeyAuthenticationTypesPresent_Success()
        {
            Assert.Equal("@apikey", AuthenticationType.ApiKey.Value());
        }

        [Fact]
        public void BasicAuthAuthenticationTypesPresent_Success()
        {
            Assert.Equal("@basic", AuthenticationType.Basic.Value());
        }

        [Fact]
        public void Oauth2AuthenticationTypesPresent_Success()
        {
            Assert.Equal("@oauth2", AuthenticationType.OAuth2.Value());
        }

        [Theory]
        [InlineData("@customer")]
        public void ConverCustomerFromString_Success(string value)
        {
            Assert.Equal(AuthenticationType.Customer, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData("@administrator")]
        public void ConvertAdministratorFromString_Success(string value)
        {
            Assert.Equal(AuthenticationType.Administrator, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData("@oauth2")]
        public void ConvertOauth2FromString_Success(string value)
        {
            Assert.Equal(AuthenticationType.OAuth2, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData("@apikey")]
        public void ConvertApiKeyFromString_Success(string value)
        {
            Assert.Equal(AuthenticationType.ApiKey, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData("@basic")]
        public void ConvertBasicFromString_Success(string value)
        {
            Assert.Equal(AuthenticationType.Basic, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("somestring")]
        public void ConvertFromString_Fails(string value)
        {
            Assert.Throws<QAToolKitCoreException>(() => AuthenticationType.From(value));
        }

        [Theory]
        [InlineData(AuthenticationType.Enumeration.Customer)]
        public void ConverCustomerFromEnum_Success(AuthenticationType.Enumeration value)
        {
            Assert.Equal(AuthenticationType.Customer, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData(AuthenticationType.Enumeration.Administrator)]
        public void ConvertAdministratorFromEnum_Success(AuthenticationType.Enumeration value)
        {
            Assert.Equal(AuthenticationType.Administrator, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData(AuthenticationType.Enumeration.OAuth2)]
        public void ConvertOAuth2FromEnum_Success(AuthenticationType.Enumeration value)
        {
            Assert.Equal(AuthenticationType.OAuth2, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData(AuthenticationType.Enumeration.ApiKey)]
        public void ConvertApiKeyFromEnum_Success(AuthenticationType.Enumeration value)
        {
            Assert.Equal(AuthenticationType.ApiKey, AuthenticationType.From(value));
        }

        [Theory]
        [InlineData(AuthenticationType.Enumeration.Basic)]
        public void ConvertBasicFromEnum_Success(AuthenticationType.Enumeration value)
        {
            Assert.Equal(AuthenticationType.Basic, AuthenticationType.From(value));
        }

        [Fact]
        public void ConvertCustomerObjectToString_Success()
        {
            Assert.Equal("@customer", AuthenticationType.Customer.Value());
        }

        [Fact]
        public void ConvertAdministratorObjectToString_Success()
        {
            Assert.Equal("@administrator", AuthenticationType.Administrator.Value());
        }

        [Fact]
        public void ConvertOAuth2ObjectToString_Success()
        {
            Assert.Equal("@oauth2", AuthenticationType.OAuth2.Value());
        }

        [Fact]
        public void ConvertApiKeyObjectToString_Success()
        {
            Assert.Equal("@apikey", AuthenticationType.ApiKey.Value());
        }

        [Fact]
        public void ConvertBasicObjectToString_Success()
        {
            Assert.Equal("@basic", AuthenticationType.Basic.Value());
        }



        [Fact]
        public void ConvertCustomerObjectToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.Customer, AuthenticationType.ToEnum(AuthenticationType.Customer));
        }

        [Fact]
        public void ConvertAdministratorObjectToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.Administrator, AuthenticationType.ToEnum(AuthenticationType.Administrator));
        }

        [Fact]
        public void ConvertOAuth2ObjectToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.OAuth2, AuthenticationType.ToEnum(AuthenticationType.OAuth2));
        }

        [Fact]
        public void ConvertApiKeyObjectToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.ApiKey, AuthenticationType.ToEnum(AuthenticationType.ApiKey));
        }

        [Fact]
        public void ConvertBasicObjectToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.Basic, AuthenticationType.ToEnum(AuthenticationType.Basic));
        }

        [Fact]
        public void ConvertCustomerStringToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.Customer, AuthenticationType.ToEnum("@customer"));
        }

        [Fact]
        public void ConvertAdministratorStringToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.Administrator, AuthenticationType.ToEnum("@administrator"));
        }

        [Fact]
        public void ConvertOAuth2StringToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.OAuth2, AuthenticationType.ToEnum("@oauth2"));
        }

        [Fact]
        public void ConvertApiKeyStringToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.ApiKey, AuthenticationType.ToEnum("@apikey"));
        }

        [Fact]
        public void ConvertBasicStringToEnum_Success()
        {
            Assert.Equal(AuthenticationType.Enumeration.Basic, AuthenticationType.ToEnum("@basic"));
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("somestring")]
        public void ConvertStringToEnum_Fails(string value)
        {
            Assert.Throws<QAToolKitCoreException>(() => AuthenticationType.ToEnum(value));
        }

        [Fact]
        public void ConvertCustomerStringToAuthenticationType_Success()
        {
            Assert.Equal(AuthenticationType.Customer, AuthenticationType.From("@customer"));
        }

        [Fact]
        public void ConvertAdministratorStringToAuthenticationType_Success()
        {
            Assert.Equal(AuthenticationType.Administrator, AuthenticationType.From("@administrator"));
        }

        [Fact]
        public void ConvertOAuth2StringToAuthenticationType_Success()
        {
            Assert.Equal(AuthenticationType.OAuth2, AuthenticationType.From("@oauth2"));
        }

        [Fact]
        public void ConvertApiKeyStringToAuthenticationType_Success()
        {
            Assert.Equal(AuthenticationType.ApiKey, AuthenticationType.From("@apikey"));
        }

        [Fact]
        public void ConvertBasicStringToAuthenticationType_Success()
        {
            Assert.Equal(AuthenticationType.Basic, AuthenticationType.From("@basic"));
        }
    }
}
