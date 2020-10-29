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
            Assert.Equal("@oauth2", AuthenticationType.Oauth2.Value());
        }
    }
}
