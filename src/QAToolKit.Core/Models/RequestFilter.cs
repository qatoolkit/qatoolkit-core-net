using System.Collections.Generic;
using System.Net.Http;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// RequestFilter object that can be used to filter out the requests
    /// </summary>
    public class RequestFilter
    {
        /// <summary>
        /// Filter requests by a list of endpoint names which are allowed to be processed.
        /// </summary>
        public string[] EndpointNameWhitelist { get; set; }
        /// <summary>
        /// Filter requests by a list of allowed authentication types. AuthenticationType is a tag or a placeholder you can place in the Swagger endpoint description.
        /// </summary>
        public IEnumerable<AuthenticationType.Enumeration> AuthenticationTypes { get; set; }
        /// <summary>
        /// Filter requests by a list of allowed test types. TestType is a tag or a placeholder you can place in the Swagger endpoint description.
        /// </summary>
        public IEnumerable<TestType.Enumeration> TestTypes { get; set; }
        /// <summary>
        /// Filter requests by a list of HTTP methods whiltelist.
        /// </summary>
        public IEnumerable<HttpMethod> HttpMethodsWhitelist { get; set; }
        /// <summary>
        /// Filter requests by a list of strings which can be found in swagger description, summary or tags. String case is ignored.
        /// </summary>
        public IEnumerable<string> GeneralContains { get; set; }
    }
}