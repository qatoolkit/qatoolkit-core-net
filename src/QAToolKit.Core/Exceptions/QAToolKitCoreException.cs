using System;
using System.Runtime.Serialization;

namespace QAToolKit.Core.Exceptions
{
    /// <summary>
    /// QA Toolkit core exception
    /// </summary>
    [Serializable]
    public class QAToolKitCoreException : Exception
    {
        /// <summary>
        /// QA Toolkit core exception
        /// </summary>
        public QAToolKitCoreException(string message) : base(message)
        {
        }

        /// <summary>
        /// QA Toolkit core exception
        /// </summary>
        public QAToolKitCoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// QA Toolkit core exception
        /// </summary>
        protected QAToolKitCoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
