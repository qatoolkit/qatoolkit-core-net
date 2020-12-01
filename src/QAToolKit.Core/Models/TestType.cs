using QAToolKit.Core.Exceptions;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Built-in test types tags
    /// </summary>
    public class TestType
    {
        /// <summary>
        /// Test type enumeration representation
        /// </summary>
        public enum Enumeration
        {
            /// <summary>
            /// Load test type
            /// </summary>
            LoadTest,
            /// <summary>
            /// Integration test type
            /// </summary>
            IntegrationTest,
            /// <summary>
            /// Security test type
            /// </summary>
            SecurityTest,
            /// <summary>
            /// Sql test type
            /// </summary>
            SqlTest
        }

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

        /// <summary>
        /// Convert to content type from string
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TestType From(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new QAToolKitCoreException($"{value} is invalid test type. Check the documentation which types are supported.");
            }

            return (value.ToLower()) switch
            {
                "@loadtest" => LoadTest,
                "@integrationtest" => IntegrationTest,
                "@securitytest" => SecurityTest,
                "@sqltest" => SqlTest,
                _ => throw new QAToolKitCoreException($"{value} is invalid test type. Check the documentation which types are supported."),
            };
        }

        /// <summary>
        /// Convert to content type object from Enum
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static TestType From(Enumeration value)
        {
            return value switch
            {
                Enumeration.LoadTest => LoadTest,
                Enumeration.IntegrationTest => IntegrationTest,
                Enumeration.SecurityTest => SecurityTest,
                Enumeration.SqlTest => SqlTest,
                _ => throw new QAToolKitCoreException($"{value} is invalid test type. Check the documentation which types are supported."),
            };
        }

        /// <summary>
        /// Convert content type object to enumeration
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static Enumeration ToEnum(TestType value)
        {
            if (value == null)
            {
                throw new QAToolKitCoreException($"{value} is invalid test type. Check the documentation which types are supported.");
            }

            return value._value switch
            {
                "@loadtest" => Enumeration.LoadTest,
                "@integrationtest" => Enumeration.IntegrationTest,
                "@securitytest" => Enumeration.SecurityTest,
                "@sqltest" => Enumeration.SqlTest,
                _ => throw new QAToolKitCoreException($"{value} is invalid test type. Check the documentation which types are supported."),
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
                throw new QAToolKitCoreException($"{value} is invalid test type. Check the documentation which types are supported.");
            }

            return value switch
            {
                "@loadtest" => Enumeration.LoadTest,
                "@integrationtest" => Enumeration.IntegrationTest,
                "@securitytest" => Enumeration.SecurityTest,
                "@sqltest" => Enumeration.SqlTest,
                _ => throw new QAToolKitCoreException($"{value} is invalid test type. Check the documentation which types are supported."),
            };
        }
    }
}
