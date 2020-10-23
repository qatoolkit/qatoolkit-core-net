using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QAToolKit.Core.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Replace multiple spaces with one in a string
        /// </summary>
        /// <param name="input">String you want to remove spaces from</param>
        /// <returns></returns>
        public static string ReplaceMultipleSpacesWithOne(string input)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
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
            string FinalString;
            var Pos1 = mainString.ToLower().IndexOf(firstString.ToLower()) + firstString.Length;
            var Pos2 = mainString.ToLower().IndexOf(lastString.ToLower());

            if (Pos1 > Pos2)
            {
                var allIndexes = AllIndexesOf(mainString.ToLower(), lastString.ToLower());

                foreach (int index in allIndexes)
                {
                    if (index > Pos1)
                    {
                        Pos2 = index;
                        break;
                    }
                }
            }

            FinalString = mainString.ToLower().Substring(Pos1, Pos2 - Pos1);
            return FinalString;
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

        public static List<int> AllIndexesOf(string str, string value)
        {
            if (String.IsNullOrEmpty(value))
                throw new ArgumentException("the string to find may not be empty", "value");
            var indexes = new List<int>();
            for (int index = 0; ; index += value.Length)
            {
                index = str.IndexOf(value, index);
                if (index == -1)
                    return indexes;
                indexes.Add(index);
            }
        }
    }
}
