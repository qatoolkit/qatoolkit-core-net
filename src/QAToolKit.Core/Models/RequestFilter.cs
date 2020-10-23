using System.Collections.Generic;

namespace QAToolKit.Core.Models
{
    public class RequestFilter
    {
        public string[] EndpointNameWhitelist { get; set; }
        public IEnumerable<AuthenticationType> AuthenticationTypes { get; set; }
        public IEnumerable<TestType> TestTypes { get; set; }
    }
}