using System;
using QAToolKit.Core.Helpers;
using Xunit;

namespace QAToolKit.Core.Test.Helpers
{
    public class HashingHelperTests
    {
        [Fact]
        public void Hashing_Success()
        {
           var hash = HashingHelper.GenerateStringHash("SET STATISTICS TIME ON;SET STATISTICS IO ON;SELECT * FROM mytable INNER JOIN mytable2 ON mytable.id=mytable2.sampleid;SET STATISTICS TIME OFF;SET STATISTICS IO OFF;");
           
           Assert.Equal("0x3983EB6B3BF4491D4A288DAC9CC66484", hash);
        }
        
        [Theory]
        [InlineData("SETSTATISTICS TIME ON;SET STATISTICS IO ON;SELECT * FROM mytable INNER JOIN mytable2 ON mytable.id=mytable2.sampleid;SET STATISTICS TIME OFF;SET STATISTICS IO OFF;")]
        [InlineData("SETSTATISTICS TIME ON;SET STATISTICS IO ON;SELECT * FROM mytable INNER JOIN mytable2 ON mytable.id=mytable2.sampleid;SET STATISTICS TIME OFF;SET STATISTICS IO OFF")]
        [InlineData("SETSTATISTICS TIME ON;SET STATISTICS IO ON;SELECT * FROM mytable INNER JOIN mytable2 ON mytable.id=mytable2.sid;SET STATISTICS TIME OFF;SET STATISTICS IO OFF;")]
        [InlineData("")]
        public void HashingShouldFail_Success(string input)
        {
            var hash = HashingHelper.GenerateStringHash(input);
           
            Assert.NotEqual("0x3983EB6B3BF4491D4A288DAC9CC66484", hash);
        }
        
        [Fact]
        public void HashingShouldThrowNullException()
        {
            Assert.Throws<ArgumentNullException>(()=> HashingHelper.GenerateStringHash(null));
        }
    }
}