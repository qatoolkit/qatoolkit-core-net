using System;
using System.Runtime.Serialization;

namespace QAToolKit.Core.Exceptions
{
    internal class QAToolKitCoreException : Exception
    {
        public QAToolKitCoreException(string message) : base(message)
        {
        }

        public QAToolKitCoreException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected QAToolKitCoreException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
