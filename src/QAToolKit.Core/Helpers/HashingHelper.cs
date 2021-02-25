using System;
using System.Text;
using Murmur;

namespace QAToolKit.Core.Helpers
{
    /// <summary>
    /// Hashing Helper
    /// </summary>
    public static class HashingHelper
    {
        /// <summary>
        /// Generate a non-cryptographic string hash by MurMur algorithm
        /// </summary>
        /// <param name="stringToHash"></param>
        /// <returns></returns>
        public static string GenerateStringHash(string stringToHash)
        {
            if (stringToHash == null)
            {
                throw new ArgumentNullException(nameof(stringToHash));
            }
            
            var hash = MurmurHash.Create128();
            var hashArray = hash.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));

            return ConvertBytesToString(hashArray);
        }

        private static string ConvertBytesToString(in byte[] data)
        {
            Array.Reverse(data);
            var sBuilder = new StringBuilder();
            
            foreach (var t in data)
            {
                sBuilder.Append(t.ToString("x2"));
            }

            // Return the hexadecimal string.
            return $"0x{sBuilder.ToString().ToUpper()}";
        }
    }
}