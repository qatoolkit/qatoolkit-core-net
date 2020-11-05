namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Key value pair for replacing a placeholder with another value
    /// </summary>
    public class ReplacementValue
    {
        /// <summary>
        /// Replacement key
        /// </summary>
        public string Key { get; set; }
        /// <summary>
        /// Replacement value object
        /// </summary>
        public object Value { get; set; }
    }
}
