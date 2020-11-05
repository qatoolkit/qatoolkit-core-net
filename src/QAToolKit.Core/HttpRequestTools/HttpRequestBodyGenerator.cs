using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QAToolKit.Core.Exceptions;
using QAToolKit.Core.Models;
using System;
using System.Collections;
using System.Linq;

namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// Http request body generator
    /// </summary>
    public class HttpRequestBodyGenerator
    {
        private readonly HttpRequest _httpRequest;
        private readonly DataReplacementOptions _dataReplacerOptions;

        /// <summary>
        /// Http Url generator
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="dataReplacerOptions"></param>
        public HttpRequestBodyGenerator(HttpRequest httpRequest, Action<DataReplacementOptions> dataReplacerOptions = null)
        {
            _httpRequest = httpRequest ?? throw new ArgumentNullException(nameof(httpRequest));
            _dataReplacerOptions = new DataReplacementOptions();
            dataReplacerOptions?.Invoke(_dataReplacerOptions);
        }

        /// <summary>
        /// Replace http body model
        /// </summary>
        /// <param name="useContentType"></param>
        /// <returns></returns>
        public object ReplaceRequestBodyModel(ContentType.Enumeration useContentType)
        {
            var requestBody = _httpRequest.RequestBodies.FirstOrDefault(body => body.ContentType == useContentType);

            if (requestBody != null)
            {
                return GenerateRequestPayload(requestBody, ContentType.Enumeration.Json);
            }

            return null;
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

            var foundModel = _dataReplacerOptions.ReplacementValues.FirstOrDefault(v => v.Key.ToLower() == requestBody.Name.ToLower());

            if (foundModel != null)
            {
                return JObject.Parse(foundModel.Value.ToString()).ToString(Formatting.None);
            }

            foreach (var property in requestBody.Properties)
            {
                var propertyType = GetPropertyType(property);
                var propertyName = GetPropertyName(property);
                if (IsSimple(propertyType))
                {
                    var value = _dataReplacerOptions.ReplacementValues.FirstOrDefault(v => v.Key.ToLower() == property.Name.ToLower());

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
                    var value = _dataReplacerOptions.ReplacementValues.FirstOrDefault(v => v.Key.ToLower() == property.Name.ToLower());

                    //TODO
                    //if (property.Required)
                    //{
                    if (propertyType == typeof(IList))
                    {
                        //obj.Add(propertyName, new JArray(new JValue("demo")));
                        if (value != null)
                            obj.Add(propertyName, JObject.Parse(value.Value.ToString()));
                    }
                    else if (propertyType == typeof(object))
                    {
                        if (value != null)
                            obj.Add(propertyName, JObject.Parse(value.Value.ToString()));
                        //obj.Add(new JProperty(propertyName, Convert.ChangeType(property.Value, propertyType)));
                    }
                    else if (propertyType == typeof(Enum))
                    {
                        if (value != null)
                            obj.Add(propertyName, JObject.Parse(value.Value.ToString()));
                        //obj.Add(new JProperty(propertyName, Convert.ChangeType(property.Value, propertyType)));
                    }
                    else
                    {
                        throw new QAToolKitCoreException($"{property.Type} not valid a type.");
                    }
                    //}
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
                    throw new QAToolKitCoreException($"{property.Type} not a valid type.");
            }
        }
    }
}
