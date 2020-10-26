using System.Collections.Generic;
using System.Net.Http;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// HttpTestRequest object
    /// </summary>
    public class HttpTestRequest
    {
        public string BasePath { get; set; }
        public string Path { get; set; }
        public string OperationId { get; set; }
        public HttpMethod Method { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public List<Parameter> Parameters { get; set; }
        public RequestBody RequestBody { get; set; }
        public List<Response> Responses { get; set; }
        public IEnumerable<TestType> TestTypes { get; set; }
        public IEnumerable<AuthenticationType> AuthenticationTypes { get; set; }
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool Nullable { get; set; }
        public string Value { get; set; }
    }

    public class Property
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }

    public class RequestBody
    {
        public string Name { get; set; }
        public List<Property> Properties { get; set; }
    }

    public class Response
    {
        public string StatusCode { get; set; }
        public List<Property> Properties { get; set; }
    }
}
