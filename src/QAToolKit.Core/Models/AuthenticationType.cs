using QAToolKit.Core.Exceptions;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Built-in authentication type tag
    /// </summary>
    public class AuthenticationType
    {
        /// <summary>
        /// Authentication type enumeration representation
        /// </summary>
        public enum Enumeration
        {
            /// <summary>
            /// Endpoint allows only customer users
            /// </summary>
            Customer,
            /// <summary>
            /// Endpoint allows only administrator users
            /// </summary>
            Administrator,
            /// <summary>
            /// Endpoint is protected by OAuth2 token
            /// </summary>
            OAuth2,
            /// <summary>
            /// Endpoint is protected by ApiKey
            /// </summary>
            ApiKey,
            /// <summary>
            /// Endpoint is protected by Basic authentication
            /// </summary>
            Basic
        }

        private readonly string _value;

        /// <summary>
        /// @customer tag for customer role
        /// </summary>
        public static readonly AuthenticationType Customer = new AuthenticationType("@customer");
        /// <summary>
        /// @administrator tag for administrator role
        /// </summary>
        public static readonly AuthenticationType Administrator = new AuthenticationType("@administrator");
        /// <summary>
        /// @oauth2 tag for OAuth2 authentication
        /// </summary>
        public static readonly AuthenticationType OAuth2 = new AuthenticationType("@oauth2");
        /// <summary>
        /// @apikey tag for api keys
        /// </summary>
        public static readonly AuthenticationType ApiKey = new AuthenticationType("@apikey");
        /// <summary>
        /// @basic tag for basic authentication
        /// </summary>
        public static readonly AuthenticationType Basic = new AuthenticationType("@basic");

        /// <summary>
        /// Authentication type constructor
        /// </summary>
        /// <param name="value"></param>
        public AuthenticationType(string value)
        {
            _value = value;
        }

        /// <summary>
        /// Return code as integer
        /// </summary>
        /// <returns></returns>
        public string Value()
        {
            return _value;
        }

        /// <summary>
        /// Convert to content type from string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AuthenticationType From(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new QAToolKitCoreException($"{value} is invalid authentication type. Check the documentation which types are supported.");
            }

            return (value.ToLower()) switch
            {
                "@customer" => Customer,
                "@administrator" => Administrator,
                "@oauth2" => OAuth2,
                "@apikey" => ApiKey,
                "@basic" => Basic,
                _ => throw new QAToolKitCoreException($"{value} is invalid authentication type. Check the documentation which types are supported."),
            };
        }

        /// <summary>
        /// Convert to content type object from Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static AuthenticationType From(Enumeration value)
        {
            return value switch
            {
                Enumeration.Customer => Customer,
                Enumeration.Administrator => Administrator,
                Enumeration.OAuth2 => OAuth2,
                Enumeration.ApiKey => ApiKey,
                Enumeration.Basic => Basic,
                _ => throw new QAToolKitCoreException($"{value} is invalid authentication type. Check the documentation which types are supported."),
            };
        }

        /// <summary>
        /// Convert content type object to enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Enumeration ToEnum(AuthenticationType value)
        {
            if (value == null)
            {
                throw new QAToolKitCoreException($"{value} is invalid authentication type. Check the documentation which types are supported.");
            }

            return value._value switch
            {
                "@customer" => Enumeration.Customer,
                "@administrator" => Enumeration.Administrator,
                "@oauth2" => Enumeration.OAuth2,
                "@apikey" => Enumeration.ApiKey,
                "@basic" => Enumeration.Basic,
                _ => throw new QAToolKitCoreException($"{value} is invalid authentication type. Check the documentation which types are supported."),
            };
        }

        /// <summary>
        /// Convert string content type to enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Enumeration ToEnum(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new QAToolKitCoreException($"{value} is invalid authentication type. Check the documentation which types are supported.");
            }

            return value switch
            {
                "@customer" => Enumeration.Customer,
                "@administrator" => Enumeration.Administrator,
                "@oauth2" => Enumeration.OAuth2,
                "@apikey" => Enumeration.ApiKey,
                "@basic" => Enumeration.Basic,
                _ => throw new QAToolKitCoreException($"{value} is invalid authentication type. Check the documentation which types are supported."),
            };
        }
    }
}
