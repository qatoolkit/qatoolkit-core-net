using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("QAToolKit.Core.Test")]
namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// HttpRequest data generator options
    /// </summary>
    public class HttpRequestDataGeneratorOptions
    {
        /// <summary>
        /// Should data be automatically generated
        /// </summary>
        internal bool UseDataGeneration { get; private set; } = false;

        /// <summary>
        /// Add data generation to the Swagger processor
        /// </summary>
        /// <returns></returns>
        public HttpRequestDataGeneratorOptions AddDataGeneration()
        {
            UseDataGeneration = true;
            return this;
        }
    }
}
