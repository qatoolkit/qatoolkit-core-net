using System;
using System.Collections.Generic;
using System.Linq;

namespace QAToolKit.Core.Helpers
{
    /// <summary>
    /// Dictionary extensions
    /// </summary>
    public static class DictionaryHelper
    {
        /// <summary>
        /// Does key exists in the dictionary case insensitive
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool KeyExists(this Dictionary<string, object> dictionary, string key)
        {
            return dictionary.Any(x => String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase));

        }

        /// <summary>
        /// Get value of the key with case insensitive comparison
        /// </summary>
        /// <param name="dictionary"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static object GetValue(this Dictionary<string, object> dictionary, string key)
        {
            return dictionary.FirstOrDefault(x => String.Equals(x.Key, key, StringComparison.OrdinalIgnoreCase)).Value;
        }
    }
}
