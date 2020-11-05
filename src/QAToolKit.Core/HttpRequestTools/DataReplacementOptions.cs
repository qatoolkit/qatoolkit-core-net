using QAToolKit.Core.Models;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("QAToolKit.Core.Test")]
namespace QAToolKit.Core.HttpRequestTools
{
    /// <summary>
    /// HttpRequest Data replacer options
    /// </summary>
    public class DataReplacementOptions
    {
        /// <summary>
        /// Key/value pairs of replacement values
        /// </summary>
        internal Dictionary<string,object> ReplacementValues { get; private set; }

        /// <summary>
        /// Use replacement values
        /// </summary>
        /// <param name="replacementValues"></param>
        /// <returns></returns>
        public DataReplacementOptions AddReplacementValues(Dictionary<string, object> replacementValues)
        {
            ReplacementValues = replacementValues;
            return this;
        }
    }
}
