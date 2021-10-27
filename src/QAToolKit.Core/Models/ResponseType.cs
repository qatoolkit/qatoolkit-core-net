namespace QAToolKit.Core.Models
{
    /// <summary>
    /// Response body type
    /// </summary>
    public enum ResponseType
    {
        /// <summary>
        /// undefined response type
        /// </summary>
        Undefined,
        /// <summary>
        /// Empty body response
        /// </summary>
        Empty,
        /// <summary>
        /// Single item/object response
        /// </summary>
        Object,
        /// <summary>
        /// List of objects response
        /// </summary>
        Objects,
        /// <summary>
        /// Array of primitive values
        /// </summary>
        Array,
        /// <summary>
        /// Primitive value like integer, string, bool
        /// </summary>
        Primitive
    }
}