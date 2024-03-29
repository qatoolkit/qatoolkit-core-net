﻿using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QAToolKit.Core.Exceptions;
using QAToolKit.Core.Helpers;
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
            var requestBody = _httpRequest.RequestBodies.FirstOrDefault(body => body.ContentType == ContentType.From(useContentType).Value());

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

        private string GenerateBodyJsonString(RequestBody requestBody)
        {
            JObject obj = new JObject();

            var modelReplacementValue = _dataReplacerOptions.ReplacementValues?.GetValue(requestBody.Name);

            if (modelReplacementValue != null)
            {
                return JObject.Parse(modelReplacementValue.ToString()).ToString(Formatting.None);
            }

            foreach (var property in requestBody.Properties)
            {
                var propertyType = GetPropertyType(property);
                var propertyName = GetPropertyName(property);
                if (IsSimple(propertyType))
                {
                    var propertyReplacementValue = _dataReplacerOptions.ReplacementValues?.GetValue(property.Name);

                    if (propertyReplacementValue != null)
                    {
                        obj.Add(new JProperty(propertyName, Convert.ChangeType(propertyReplacementValue, propertyType)));
                    }
                    else
                    {
                        obj.Add(new JProperty(propertyName, Convert.ChangeType(property.Value, propertyType)));
                    }
                }
                else
                {
                    var propertyReplacementValue = _dataReplacerOptions.ReplacementValues?.GetValue(property.Name);

                    if (propertyType == typeof(IList))
                    {
                        if (propertyReplacementValue != null)
                            obj.Add(propertyName, JObject.Parse(propertyReplacementValue.ToString()));
                    }
                    else if (propertyType == typeof(object))
                    {
                        if (propertyReplacementValue != null)
                            obj.Add(propertyName, JObject.Parse(propertyReplacementValue.ToString()));
                    }
                    else if (propertyType == typeof(Enum))
                    {
                        if (propertyReplacementValue != null)
                            obj.Add(propertyName, JObject.Parse(propertyReplacementValue.ToString()));
                    }
                    else
                    {
                        throw new QAToolKitCoreException($"{property.Type} not valid a type.");
                    }
                }
            }

            return obj.ToString(Formatting.None);
        }

        private static string GetPropertyName(Property property)
        {
            return property.Name;
        }

        private static bool IsSimple(Type type)
        {
            return type == typeof(long)
                || type == typeof(int)
                || type == typeof(string);
        }

        private static Type GetPropertyType(Property property)
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
