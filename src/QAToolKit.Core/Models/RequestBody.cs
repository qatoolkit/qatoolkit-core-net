using System.Collections.Generic;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Request body object
    /// </summary>
    public class RequestBody
    {
        /// <summary>
        /// Request body model name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Is parameter required
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Request body content type
        /// </summary>
        public ContentType.Enumeration ContentType { get; set; }
        /// <summary>
        /// Request body model properties
        /// </summary>
        public List<Property> Properties { get; set; }
    }
}