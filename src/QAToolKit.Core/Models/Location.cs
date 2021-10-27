namespace QAToolKit.Core.Models
{
    /// <summary>
    /// The location of parameter in HTTP request
    /// </summary>
    public enum Location
    {
        /// <summary>
        /// Undefined
        /// </summary>
        Undefined,
        /// <summary>
        /// URI path
        /// </summary>
        Path,
        /// <summary>
        /// URI query
        /// </summary>
        Query,
        /// <summary>
        /// Header parameter
        /// </summary>
        Header,
        /// <summary>
        /// Cookie parameter
        /// </summary>
        Cookie
    }
}