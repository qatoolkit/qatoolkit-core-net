using QAToolKit.Core.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace QAToolKit.Core.Test.Fixtures
{
    class AddNewUserHttpRequest
    {
        public static HttpRequest Get()
        {
            return new HttpRequest()
            {
                AuthenticationTypes = null,
                BasePath = "https://myapi.com",
                Description = "Create new user",
                Method = HttpMethod.Post,
                OperationId = "addUser",
                Parameters = new List<Parameter>() { },
                Path = "/users",
                RequestBodies = new List<RequestBody>() {
                    new RequestBody(){
                        ContentType = ContentType.Enumeration.Json,
                        Name = "User",
                        Required = true,
                        Properties = new List<Property>(){
                                    new Property(){
                                        Name = "id",
                                        Description = null,
                                        Format = "int64",
                                        Required = false,
                                        Properties = null,
                                        Type = "integer",
                                        Value = null
                                    },
                                    new Property(){
                                        Name = "name",
                                        Description = null,
                                        Format = null,
                                        Required = false,
                                        Properties = null,
                                        Type = "string",
                                        Value = null
                                    }
                            }
                        }
                },
                Summary = "Create new user",
                Tags = new string[] { "Users" },
                Responses = new List<Response>()
                    {
                       new Response()
                        {
                            StatusCode = HttpStatusCode.Created,
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
                                        Value = null
                                    },
                                    new Property(){
                                        Name = "name",
                                        Description = null,
                                        Format = null,
                                        Required = false,
                                        Properties = null,
                                        Type = "string",
                                        Value = null
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
