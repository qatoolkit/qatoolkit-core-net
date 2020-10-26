namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Swagger authentication Type tag
    /// </summary>
    public class AuthenticationType
    {
        private readonly string _value;

        public static readonly AuthenticationType Customer = new AuthenticationType("@customer");
        public static readonly AuthenticationType Administrator = new AuthenticationType("@administrator");
        public static readonly AuthenticationType Oauth2 = new AuthenticationType("@oauth2");
        public static readonly AuthenticationType ApiKey = new AuthenticationType("@apikey");
        public static readonly AuthenticationType Basic = new AuthenticationType("@basic");

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
