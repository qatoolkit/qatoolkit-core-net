using QAToolKit.Core.Exceptions;
using System;
using Xunit;

namespace QAToolKit.Core.Test.Exceptions
{
    public class QAToolKitCoreExceptionTests
    {
        [Fact]
        public void CreateExceptionTest_Successful()
        {
            var exception = new QAToolKitCoreException("my error");

            Assert.Equal("my error", exception.Message);
        }

        [Fact]
        public void CreateExceptionWithInnerExceptionTest_Successful()
        {
            var innerException = new Exception("Inner");
            var exception = new QAToolKitCoreException("my error", innerException);

            Assert.Equal("my error", exception.Message);
            Assert.Equal("Inner", innerException.Message);
        }
    }
}
