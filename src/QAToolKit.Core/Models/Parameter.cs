namespace QAToolKit.Core.Models
{
    /// <summary>
    /// An URL parameter
    /// </summary>
    public class Parameter
    {
        /// <summary>
        /// Parameter name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Parameter type like string, integer, number,...
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Parameter format like int32, int64, double,...
        /// </summary>
        public string Format { get; set; }
        /// <summary>
        /// Is parameter nullable
        /// </summary>
        public bool Nullable { get; set; }
        /// <summary>
        /// Parameter value
        /// </summary>
        public string Value { get; set; }
        /// <summary>
        /// Is parameter required
        /// </summary>
        public bool Required { get; set; }
        /// <summary>
        /// Parameter location can be either path or in query
        /// </summary>
        public Location Location { get; set; }
    }
}