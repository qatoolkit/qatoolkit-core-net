using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QAToolKit.Core.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// Replace request body values with values from ReplacementValue[]
    /// </summary>
    public class HttpRequestDataReplacer
    {
        private readonly HttpRequest _request;
        private readonly ReplacementValue[] _replacementValues;

        /// <summary>
        /// Swagger value replacement
        /// </summary>
        /// <param name="request"></param>
        /// <param name="replacementValues"></param>
        public HttpRequestDataReplacer(HttpRequest request, ReplacementValue[] replacementValues)
        {
            _request = request;
            _replacementValues = replacementValues;
        }

        /// <summary>
        /// Replace http body model
        /// </summary>
        /// <param name="useContentType"></param>
        /// <returns></returns>
        public object ReplaceRequestBodyModel(ContentType.Enumeration useContentType)
        {
            var requestBody = _request.RequestBodies.FirstOrDefault(body => body.ContentType == useContentType);

            if (requestBody != null)
            {
                return GenerateRequestPayload(requestBody, ContentType.Enumeration.Json);
            }

            return null;
        }

        /// <summary>
        /// Replace URL parameters with replacable values
        /// </summary>
        /// <returns></returns>
        public Uri ReplaceUrlParameters()
        {
            var path = ReplacePathParameters();
            if (string.IsNullOrEmpty(path))
            {
                throw new Exception("Relative path can not be null.");
            }

            var query = ReplaceQueryParameters();
            if (!string.IsNullOrEmpty(query))
            {
                query = $"?{query}";

                return new Uri($"{path}{query}", UriKind.Relative);
            }
            else
            {
                return new Uri(path, UriKind.Relative);
            }
        }

        /// <summary>
        /// Replace Query parameters
        /// </summary>
        /// <returns></returns>
        internal string ReplaceQueryParameters()
        {
            if (_replacementValues != null)
            {
                string query = null;
                foreach (var replacementValue in _replacementValues)
                {
                    foreach (var parameter in _request.Parameters.Where(kind => kind.Location == Location.Query))
                    {
                        if (parameter.Name == replacementValue.Key)
                        {
                            var type = replacementValue.Value.GetType();

                            if (type.Equals(typeof(Dictionary<string, string>)))
                            {
                                query = GenerateQueryParameters((Dictionary<string, string>)replacementValue.Value);
                            }
                            else if (type.Equals(typeof(string[])))
                            {
                                var tmp = (string[])replacementValue.Value;
                                query = $"{string.Join("&", tmp.Select(item => $"{parameter.Name}={item}"))}";
                            }
                            else if (type.Equals(typeof(int[])))
                            {
                                var tmp = (int[])replacementValue.Value;
                                query = $"{string.Join("&", tmp.Select(item => $"{parameter.Name}={item}"))}";
                            }
                            else
                            {
                                query = $"{parameter.Name}={replacementValue.Value}";
                            }
                        }
                    }
                }

                return query;
            }

            return String.Empty;
        }

        /// <summary>
        /// Replace Url path parameters
        /// </summary>
        /// <returns></returns>
        internal string ReplacePathParameters()
        {
            if (_replacementValues != null)
            {
                foreach (var replacementValue in _replacementValues)
                {
                    var type = replacementValue.Value.GetType();

                    if (_request.Path.Contains("{" + replacementValue.Key + "}") && type.Equals(typeof(string)))
                    {
                        _request.Path = _request.Path.Replace("{" + replacementValue.Key + "}", (string)replacementValue.Value);
                    }
                }
            }

            return _request.Path;
        }

        private string GenerateQueryParameters(Dictionary<string, string> keyValuePairs)
        {
            var parameters = new List<string>();

            foreach (var item in keyValuePairs)
            {
                parameters.Add($"{item.Key}={item.Value},");
            }

            return string.Join(",", parameters);
        }

        private string GenerateRequestPayload(RequestBody requestBody, ContentType.Enumeration contentType)
        {
            if (contentType == ContentType.Enumeration.Json)
            {
                return GenerateBodyJsonString(requestBody);
            }
            else
            {
                return String.Empty;
            }
        }

        //TODO: extend to support arrays, enums, object arrays
        private string GenerateBodyJsonString(RequestBody requestBody)
        {
            JObject obj = new JObject();
            foreach (var property in requestBody.Properties)
            {
                var propertyType = GetPropertyType(property);
                var propertyName = GetPropertyName(property);
                if (IsSimple(propertyType))
                {
                    var value = _replacementValues.FirstOrDefault(v => v.Key == property.Name);

                    if (value == null)
                    {
                        obj.Add(new JProperty(propertyName, Convert.ChangeType(property.Value, propertyType)));
                    }
                    else
                    {
                        obj.Add(new JProperty(propertyName, Convert.ChangeType(value.Value, propertyType)));
                    }
                }
                else
                {
                    //TODO
                    if (property.Required)
                    {
                        if (propertyType == typeof(IList))
                        {
                            obj.Add(propertyName, new JArray(new JValue("demo")));
                        }
                        else if (propertyType == typeof(object))
                        {
                            obj.Add(new JProperty(propertyName, Convert.ChangeType(property.Value, propertyType)));
                        }
                        else if (propertyType == typeof(Enum))
                        {
                            obj.Add(new JProperty(propertyName, Convert.ChangeType(property.Value, propertyType)));
                        }
                        else
                        {
                            throw new Exception($"{property.Type} not valid type.");
                        }
                    }
                }
            }

            return obj.ToString(Formatting.None);
        }

        private string GetPropertyName(Property property)
        {
            return property.Name;
        }

        private bool IsSimple(Type type)
        {
            return type == typeof(long)
                || type == typeof(int)
                || type == typeof(string);
        }

        private Type GetPropertyType(Property property)
        {
            switch (property.Type)
            {
                case "integer":
                    if (property.Format == "int64")
                    {
                        return typeof(long);
                    }
                    else
                    {
                        return typeof(int);
                    }
                case "string":
                    return typeof(string);
                case "object":
                    return typeof(object);
                case "array":
                    return typeof(IList);
                case "enum":
                    return typeof(Enum);
                default:
                    throw new Exception($"{property.Type} not valid type.");
            }
        }
    }
}
