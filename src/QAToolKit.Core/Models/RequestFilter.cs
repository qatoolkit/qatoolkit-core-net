using System.Collections.Generic;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// RequestFilter object that can be used to filter out the requests
    /// </summary>
    public class RequestFilter
    {
        /// <summary>
        /// A list of endpoint names which are allowed to be processed.
        /// </summary>
        public string[] EndpointNameWhitelist { get; set; }
        /// <summary>
        /// A list of allowed authentication types
        /// </summary>
        public IEnumerable<AuthenticationType> AuthenticationTypes { get; set; }
        /// <summary>
        /// A list of allowed test types
        /// </summary>
        public IEnumerable<TestType> TestTypes { get; set; }
    }
}