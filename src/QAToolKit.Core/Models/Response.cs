using System.Collections.Generic;
using System.Net;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Response object
    /// </summary>
    public class Response
    {
        /// <summary>
        /// Response HTTP status code
        /// </summary>
        public HttpStatusCode? StatusCode { get; set; }
        /// <summary>
        /// Is return object a single item or array
        /// </summary>
        public ResponseType Type { get; set; }
        /// <summary>
        /// Response parameters
        /// </summary>
        public List<Property> Properties { get; set; }
    }
}