namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Test types tags
    /// </summary>
    public class TestType
    {
        private readonly string _value;

        /// <summary>
        /// Load test tag
        /// </summary>
        public static readonly TestType LoadTest = new TestType("@loadtest");
        /// <summary>
        /// Integration test tag
        /// </summary>
        public static readonly TestType IntegrationTest = new TestType("@integrationtest");
        /// <summary>
        /// Security test tag
        /// </summary>
        public static readonly TestType SecurityTest = new TestType("@securitytest");
        /// <summary>
        /// SQL test tag
        /// </summary>
        public static readonly TestType SqlTest = new TestType("@sqltest");

        /// <summary>
        /// Test type constructor
        /// </summary>
        /// <param name="value"></param>
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
