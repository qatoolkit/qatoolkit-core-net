namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Test types tags
    /// </summary>
    public class TestType
    {
        private readonly string _value;

        public static readonly TestType LoadTest = new TestType("@loadtest");
        public static readonly TestType IntegrationTest = new TestType("@integrationtest");
        public static readonly TestType SecurityTest = new TestType("@securitytest");
        public static readonly TestType SqlTest = new TestType("@sqltest");

        public TestType(string value)
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
