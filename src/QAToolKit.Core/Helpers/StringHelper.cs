using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace QAToolKit.Core.Helpers
{
    /// <summary>
    /// Collection of string helper functions
    /// </summary>
    public static class StringHelper
    {
        /// <summary>
        /// Replace multiple spaces with one in a string
        /// </summary>
        /// <param name="input">String you want to remove spaces from</param>
        /// <returns></returns>
        public static string ReplaceMultipleSpacesWithOne(string input)
        {
            const RegexOptions options = RegexOptions.None;
            var regex = new Regex("[ ]{2,}", options);
            return regex.Replace(input, " ");
        }

        /// <summary>
        /// Grab string between strings
        /// </summary>
        /// <param name="mainString"></param>
        /// <param name="firstString"></param>
        /// <param name="lastString"></param>
        /// <returns></returns>
        public static string Between(string mainString, string firstString, string lastString)
        {
            var pos1 = mainString.ToLower().IndexOf(firstString.ToLower()) + firstString.Length;
            var pos2 = mainString.ToLower().IndexOf(lastString.ToLower());

            if (pos1 > pos2)
            {
                var allIndexes = AllIndexesOf(mainString.ToLower(), lastString.ToLower());

                foreach (var index in allIndexes)
                {
                    if (index <= pos1) continue;
                    pos2 = index;
                    break;
                }
            }

            var finalString = mainString.ToLower().Substring(pos1, pos2 - pos1);
            return finalString;
        }


        /// <summary>
        /// Remove all non numeric chars with RegEx
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string RemoveAllNonNumericChars(string input)
        {
            return Regex.Replace(input, @"[^0-9\.,]+", "");
        }

        /// <summary>
        /// Replace dot with comma
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string ReplaceDotWithComma(string input)
        {
            return Regex.Replace(input, @"[.]+", ",");
        }

        /// <summary>
        /// Trim whitespace from both ends of a string
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string TrimString(string input)
        {
            return input.Trim();
        }

        /// <summary>
        /// Get a list of all indexes of a string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static IEnumerable<int> AllIndexesOf(string str, string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", nameof(value));
            var indexes = new List<int>();
            for (var index = 0;; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }

        /// <summary>
        /// Obfuscate a string with custom data between two strings
        /// </summary>
        /// <param name="original"></param>
        /// <param name="startTag"></param>
        /// <param name="endTag"></param>
        /// <param name="replaceWith"></param>
        /// <returns></returns>
        public static string ObfuscateStringBetween(string original, string startTag, string endTag, string replaceWith)
        {
            var pattern = startTag + "(.*?)" + endTag;
            var regex = new Regex(pattern, RegexOptions.RightToLeft);

            foreach (Match match in regex.Matches(original))
            {
                original = original.Replace(match.Groups[1].Value, replaceWith);
            }

            return original;
        }

        /// <summary>
        /// Check if string contains string by ignoring case
        /// </summary>
        /// <param name="text"></param>
        /// <param name="value"></param>
        /// <param name="stringComparison"></param>
        /// <returns></returns>
        public static bool ContainsCaseInsensitive(this string text, string value,
            StringComparison stringComparison = StringComparison.CurrentCultureIgnoreCase)
        {
            return text.IndexOf(value, stringComparison) >= 0;
        }

        /// <summary>
        /// Convert strings with different separators to pascal case string
        /// </summary>
        /// <param name="input"></param>
        /// <param name="separators"></param>
        /// <returns></returns>
        public static string ToPascalCase(this string input, string[] separators)
        {
            var words = input.Split(separators, StringSplitOptions.RemoveEmptyEntries)
                .Select(word => word.Substring(0, 1).ToUpper() + word.Substring(1).ToLower());

            var result = string.Concat(words);
            return result;
        }
    }
}