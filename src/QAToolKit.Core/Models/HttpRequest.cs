using System.Collections.Generic;
using System.Net.Http;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// HttpTestRequest object
    /// </summary>
    public class HttpRequest
    {
        /// <summary>
        /// Url base path
        /// </summary>
        public string BasePath { get; set; }
        /// <summary>
        /// Url relative path
        /// </summary>
        public string Path { get; set; }
        /// <summary>
        /// Name of the HTTP request
        /// </summary>
        public string OperationId { get; set; }
        /// <summary>
        /// Http method
        /// </summary>
        public HttpMethod Method { get; set; }
        /// <summary>
        /// Summary of the HTTP request
        /// </summary>
        public string Summary { get; set; }
        /// <summary>
        /// Description of the HTTP request
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// HTTP request tags
        /// </summary>
        public string[] Tags { get; set; }
        /// <summary>
        /// A list of HTTP parameters
        /// </summary>
        public List<Parameter> Parameters { get; set; }
        /// <summary>
        /// Request bodies
        /// </summary>
        public List<RequestBody> RequestBodies { get; set; }
        /// <summary>
        /// List of HTTP response parameters
        /// </summary>
        public List<Response> Responses { get; set; }
        /// <summary>
        /// List of test type tags
        /// </summary>
        public List<TestType.Enumeration> TestTypes { get; set; }
        /// <summary>
        /// A list of authentication type tags
        /// </summary>
        public List<AuthenticationType.Enumeration> AuthenticationTypes { get; set; }
    }
}
