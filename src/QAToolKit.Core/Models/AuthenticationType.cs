namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Authentication Type tag
    /// </summary>
    public class AuthenticationType
    {
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
        public static readonly AuthenticationType Oauth2 = new AuthenticationType("@oauth2");
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
    }
}
