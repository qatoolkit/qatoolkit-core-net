using QAToolKit.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// Http Url generator
    /// </summary>
    public class HttpRequestUrlGenerator
    {
        private readonly HttpRequest _httpRequest;
        private readonly DataReplacementOptions _dataReplacerOptions;

        /// <summary>
        /// Http Url generator
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="dataReplacerOptions"></param>
        public HttpRequestUrlGenerator(HttpRequest httpRequest, Action<DataReplacementOptions> dataReplacerOptions = null)
        {
            _httpRequest = httpRequest ?? throw new ArgumentNullException(nameof(httpRequest));
            _dataReplacerOptions = new DataReplacementOptions();
            dataReplacerOptions?.Invoke(_dataReplacerOptions);
        }

        /// <summary>
        /// Get url with parameter placeholders
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            var url = new StringBuilder();

            ///BASE PATH
            if (!_httpRequest.BasePath.EndsWith("/"))
            {
                url.Append($"{_httpRequest.BasePath}/");
            }
            else
            {
                url.Append(_httpRequest.BasePath);
            }

            /// PATH
            string rawPath;
            if (_httpRequest.Path.StartsWith("/"))
            {
                //TODO fill up the examples value of parameters if any
                rawPath = _httpRequest.Path.Substring(1, _httpRequest.Path.Length - 1);
            }
            else
            {
                //TODO fill up the examples value of parameters if any
                rawPath = _httpRequest.Path;
            }

            if (_dataReplacerOptions.ReplacementValues != null)
            {
                rawPath = ReplacePathParameters(rawPath);
            }

            url.Append(rawPath);


            ///QUERY
            var rawQuery = GetQuery();

            if (_dataReplacerOptions.ReplacementValues != null)
            {
                rawQuery = ReplaceQueryParameters();
                url.Append(rawQuery);
            }
            else
            {
                url.Append(rawQuery);
            }

            return $"{url}";
        }

        private string GetQuery()
        {
            var query = new StringBuilder();
            foreach (var parameter in _httpRequest.Parameters.Where(kind => kind.Location == Location.Query))
            {
                query.Append($"{parameter.Name}={{{parameter.Name}}}");

                if (!query.ToString().StartsWith("?"))
                {
                    return $"?{query}";
                }
                else
                {
                    return $"{query}";
                }
            }

            return String.Empty;
        }

        /// <summary>
        /// Replace Url path parameters
        /// </summary>
        /// <returns></returns>
        internal string ReplacePathParameters(string path)
        {
            foreach (var replacementValue in _dataReplacerOptions.ReplacementValues)
            {
                var type = replacementValue.Value.GetType();

                if (path.Contains("{" + replacementValue.Key + "}") && type.Equals(typeof(string)))
                {
                    path = path.Replace("{" + replacementValue.Key + "}", (string)replacementValue.Value);
                }
            }

            return path;
        }

        /// <summary>
        /// Replace Query parameters
        /// </summary>
        /// <returns></returns>
        internal string ReplaceQueryParameters()
        {
            var queryParts = new List<string>();
            foreach (var parameter in _httpRequest.Parameters.Where(kind => kind.Location == Location.Query))
            {
                foreach (var replacementValue in _dataReplacerOptions.ReplacementValues)
                {
                    if (parameter.Name.ToLower() == replacementValue.Key.ToLower())
                    {
                        var type = replacementValue.Value.GetType();

                        if (type.Equals(typeof(Dictionary<string, string>)))
                        {
                            queryParts.Add(GenerateQueryParameters((Dictionary<string, string>)replacementValue.Value));
                        }
                        else if (type.Equals(typeof(string[])))
                        {
                            var tmp = (string[])replacementValue.Value;
                            queryParts.Add($"{string.Join("&", tmp.Select(item => $"{parameter.Name}={item}"))}");
                        }
                        else if (type.Equals(typeof(int[])))
                        {
                            var tmp = (int[])replacementValue.Value;
                            queryParts.Add($"{string.Join("&", tmp.Select(item => $"{parameter.Name}={item}"))}");
                        }
                        else
                        {
                            queryParts.Add($"{parameter.Name}={replacementValue.Value}");
                        }
                    }
                }
            }

            if (queryParts.Count == 0)
            {
                return String.Empty;
            }

            var query = string.Join("&", queryParts);

            if (!query.ToString().StartsWith("?"))
            {
                return $"?{query}";
            }
            else
            {
                return $"{query}";
            }
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
    }
}
