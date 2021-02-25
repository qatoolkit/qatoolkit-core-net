using System;

namespace QAToolKit.Core.Interfaces
{
    /// <summary>
    /// SQL test result interface
    /// </summary>
    [Obsolete("It will be removed in future releases. Database nuget has it's own interfaces.")]
    public interface ISqlTestResult
    {
        /// <summary>
        /// SQL result exists
        /// </summary>
        public bool Exists { get; set; }
    }
}

