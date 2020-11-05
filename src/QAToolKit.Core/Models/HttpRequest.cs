using System.Collections.Generic;
using System.Net;
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
        public List<TestType> TestTypes { get; set; }
        /// <summary>
        /// A list of authentication type tags
        /// </summary>
        public List<AuthenticationType> AuthenticationTypes { get; set; }
    }

    /// <summary>
    /// An URL parameter
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Paramter name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Paramter type
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Is parameter nullable
        /// </summary>
        public bool Nullable { get; set; }
        /// <summary>
        /// Paramter value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Is parameter required
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Parameter location can be either path or in query
        /// </summary>
        public Location Location { get; set; }
    }

    /// <summary>
    /// Request body or response property
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// OpenApi property format of an object; string, date-time, int64,...
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// OpenApi property type integer, string, array, object
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Property value
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Is property required
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Schema properties
        /// </summary>
        public List<Property> Properties { get; set; }
    }

    /// <summary>
    /// Request body object
    /// </summary>
    public class RequestBody
    {
        /// <summary>
        /// Request body model name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is parameter required
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Request body content type
        /// </summary>
        public ContentType.Enumeration ContentType { get; set; }
        /// <summary>
        /// Request body model properties
        /// </summary>
        public List<Property> Properties { get; set; }
    }

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
        /// Response paramters
        /// </summary>
        public List<Property> Properties { get; set; }
    }

    /// <summary>
    /// The location of paramter in HTTP request
    /// </summary>
    public enum Location
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,
        /// <summary>
        /// URI path
        /// </summary>
        Path,
        /// <summary>
        /// URI query
        /// </summary>
        Query,
        /// <summary>
        /// Header parameter
        /// </summary>
        Header,
        /// <summary>
        /// Cookie parameter
        /// </summary>
        Cookie
    }

    /// <summary>
    /// Response body type
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// undefined response type
        /// </summary>
        Undefined,
        /// <summary>
        /// Empty body response
        /// </summary>
        Empty,
        /// <summary>
        /// Single item/object response
        /// </summary>
        Object,
        /// <summary>
        /// List of objects response
        /// </summary>
        Objects,
        /// <summary>
        /// Array of primitive values
        /// </summary>
        Array,
        /// <summary>
        /// Primitive value like integer, string, bool
        /// </summary>
        Primitive
    }
}
