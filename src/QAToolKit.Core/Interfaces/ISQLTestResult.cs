﻿namespace QAToolKit.Core.Interfaces
{
    /// <summary>
    /// SQL test result interface
    /// </summary>
    public interface ISqlTestResult
    {
        /// <summary>
        /// SQL result exists
        /// </summary>
        public bool Exists { get; set; }
    }
}

