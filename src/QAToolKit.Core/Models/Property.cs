using System.Collections.Generic;

namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Request body or response property
    /// </summary>
    public class Property
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Property description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// OpenApi property format of an object; string, date-time, int64,...
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// OpenApi property type integer, string, array, object
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Property value
        /// </summary>
        public object Value { get; set; }
        /// <summary>
        /// Is property required
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Schema properties
        /// </summary>
        public List<Property> Properties { get; set; }
    }
}