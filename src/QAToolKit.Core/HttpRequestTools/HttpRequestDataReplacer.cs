using QAToolKit.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// Replace request body values with values from ReplacementValue[]
    /// </summary>
    public class HttpRequestDataReplacer
    {
        private readonly IList<HttpRequest> _requests;
        private readonly ReplacementValue[] _replacementValues;

        /// <summary>
        /// Swagger value replacement
        /// </summary>
        /// <param name="requests"></param>
        /// <param name="replacementValues"></param>
        public HttpRequestDataReplacer(IList<HttpRequest> requests, ReplacementValue[] replacementValues)
        {
            _requests = requests;
            _replacementValues = replacementValues;
        }

        /// <summary>
        /// Replace request body, url path and parameters with values from ReplacementValue[]
        /// </summary>
        /// <returns></returns>
        public List<HttpRequest> ReplaceAll()
        {
            ReplaceRequestBodyModel();
            ReplaceQueryParameters();
            ReplacePathParameters();

            return _requests.ToList();
        }

        private void ReplaceRequestBodyModel()
        {
            foreach (var request in _requests)
            {
                if (request.RequestBodies != null)
                {
                    foreach (var requestBody in request.RequestBodies)
                    {
                        if (requestBody.Properties == null)
                        {
                            continue;
                        }

                        if (_replacementValues != null)
                        {
                            foreach (var replacementValue in _replacementValues)
                            {
                                var prop = requestBody.Properties.FirstOrDefault(p => p.Name == replacementValue.Key);

                                if (prop != null)
                                {
                                    prop.Value = replacementValue.Value;
                                }
                            }
                        }
                    }
                }
            }
        }

        private void ReplaceQueryParameters()
        {
            if (_replacementValues != null)
            {
                foreach (var replacementValue in _replacementValues)
                {
                    foreach (var request in _requests)
                    {
                        foreach (var parameter in request.Parameters/*.Where(kind => kind.Location == Location.Query)*/)
                        {
                            if (parameter.Name == replacementValue.Key)
                            {
                                var type = replacementValue.Value.GetType();

                                if (type.Equals(typeof(Dictionary<string, string>)))
                                {
                                    parameter.Value = GenerateQueryParameters((Dictionary<string, string>)replacementValue.Value);
                                }
                                else if (type.Equals(typeof(string[])))
                                {
                                    var tmp = (string[])replacementValue.Value;
                                    parameter.Value = $"{string.Join("&", tmp.Select(item => $"{parameter.Name}={item}"))}";
                                }
                                else if (type.Equals(typeof(int[])))
                                {
                                    var tmp = (int[])replacementValue.Value;
                                    parameter.Value = $"{string.Join("&", tmp.Select(item => $"{parameter.Name}={item}"))}";
                                }
                                else
                                {
                                    parameter.Value = replacementValue.Value.ToString();
                                }
                            }
                        }
                    }
                }
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

        private void ReplacePathParameters()
        {
            if (_replacementValues != null)
            {
                foreach (var replacementValue in _replacementValues)
                {
                    foreach (var request in _requests)
                    {
                        var type = replacementValue.Value.GetType();

                        if (request.Path.Contains("{" + replacementValue.Key + "}") && type.Equals(typeof(string)))
                        {
                            request.Path = request.Path.Replace("{" + replacementValue.Key + "}", (string)replacementValue.Value);
                        }
                    }
                }
            }
        }
    }
}
