using QAToolKit.Core.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace QAToolKit.Core.Test.Fixtures
{
    public static class GetUserByIdHttpRequest
    {
        public static HttpRequest Get()
        {
            return new HttpRequest()
            {
                AuthenticationTypes = null,
                BasePath = "https://myapi.com",
                Description = "Get user by id",
                Method = HttpMethod.Get,
                OperationId = "getUserById",
                Parameters = new List<Parameter>() { },
                Path = "/users/{userId}",
                RequestBodies = null,
                Summary = "Get user by Id",
                Tags = new string[] { "Users" },
                Responses = new List<Response>()
                    {
                       new Response()
                        {
                            StatusCode = HttpStatusCode.OK,
                            Type = ResponseType.Object,
                            Properties = new List<Property>()
                                {
                                    new Property(){
                                        Name = "id",
                                        Description = null,
                                        Format = "int64",
                                        Required = false,
                                        Properties = null,
                                        Type = "integer",
                                        Value = "10"
                                    },
                                    new Property(){
                                        Name = "name",
                                        Description = null,
                                        Format = null,
                                        Required = false,
                                        Properties = null,
                                        Type = "string",
                                        Value = "doggie"
                                    }
                            }
                        },
                       new Response()
                        {
                            StatusCode = HttpStatusCode.BadRequest,
                            Type = ResponseType.Undefined,
                            Properties = null
                        },
                       new Response()
                        {
                            StatusCode = HttpStatusCode.NotFound,
                            Type = ResponseType.Undefined,
                            Properties = null
                        }
                    },
                TestTypes = null
            };
        }
    }
}
