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
        /// Get url with parameters
        /// </summary>
        /// <returns></returns>
        public string GetUrl()
        {
            var url = new StringBuilder();

            if (!_httpRequest.BasePath.EndsWith("/"))
            {
                url.Append($"{_httpRequest.BasePath}/");
            }
            else
            {
                url.Append(_httpRequest.BasePath);
            }

            string rawPath = GetPath();
            url.Append(rawPath);

            var rawQuery = GetQuery();
            url.Append(rawQuery);

            return $"{url}";
        }

        /// <summary>
        /// Get query parameters
        /// </summary>
        /// <returns></returns>
        private string GetQuery()
        {
            var queryParts = new List<string>();

            foreach (var parameter in _httpRequest.Parameters.Where(kind => kind.Location == Location.Query))
            {
                if (parameter.Value != null && !HasReplaceValue(parameter.Name))
                {
                    queryParts.Add($"{parameter.Name}={parameter.Value}");
                }
                else
                {
                    if (_dataReplacerOptions.ReplacementValues != null)
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

        private bool HasReplaceValue(string valueName)
        {
            if (_dataReplacerOptions.ReplacementValues != null)
            {
                foreach (var replacementValue in _dataReplacerOptions.ReplacementValues)
                {
                    if (valueName.ToLower() == replacementValue.Key.ToLower())
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Replace Url path parameters
        /// </summary>
        /// <returns></returns>
        internal string GetPath()
        {
            string path = _httpRequest.Path;

            if (_dataReplacerOptions.ReplacementValues != null)
            {
                foreach (var replacementValue in _dataReplacerOptions.ReplacementValues)
                {
                    var type = replacementValue.Value.GetType();

                    if (path.Contains("{" + replacementValue.Key + "}") && (type.Equals(typeof(string)) || type.IsPrimitive))
                    {
                        path = path.Replace("{" + replacementValue.Key + "}", replacementValue.Value.ToString());
                    }
                }
            }

            if (path.StartsWith("/"))
            {
                path = path.Substring(1, path.Length - 1);
            }

            return path;
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
