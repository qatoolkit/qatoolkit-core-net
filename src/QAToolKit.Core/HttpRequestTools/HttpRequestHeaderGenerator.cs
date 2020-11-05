using QAToolKit.Core.Models;
using System;

namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// Http request header genererator
    /// </summary>
    public class HttpRequestHeaderGenerator
    {
        private readonly HttpRequest _httpRequest;
        private readonly DataReplacementOptions _dataReplacerOptions;

        /// <summary>
        /// Http Url generator
        /// </summary>
        /// <param name="httpRequest"></param>
        /// <param name="dataReplacerOptions"></param>
        public HttpRequestHeaderGenerator(HttpRequest httpRequest, Action<DataReplacementOptions> dataReplacerOptions = null)
        {
            _httpRequest = httpRequest ?? throw new ArgumentNullException(nameof(httpRequest));
            _dataReplacerOptions = new DataReplacementOptions();
            dataReplacerOptions?.Invoke(_dataReplacerOptions);
        }
    }
}
