using System.Collections.Generic;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// RequestFilter object that can be used to filter out the requests
    /// </summary>
    public class RequestFilter
    {
        public string[] EndpointNameWhitelist { get; set; }
        public IEnumerable<AuthenticationType> AuthenticationTypes { get; set; }
        public IEnumerable<TestType> TestTypes { get; set; }
    }
}