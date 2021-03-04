using QAToolKit.Core.Helpers;
using System.Linq;
using Xunit;

namespace QAToolKit.Core.Test.Helpers
{
    public class StringHelperTests
    {
        [Theory]
        [InlineData("test string")]
        [InlineData("test    string")]
        public void ReplaceMultipleSpacesWithOne_Success(string input)
        {
            var result = StringHelper.ReplaceMultipleSpacesWithOne(input);

            Assert.Equal("test string", result);
        }

        [Theory]
        [InlineData("test string   ")]
        [InlineData("test  string ")]
        [InlineData("test string     ")]
        public void ReplaceMultipleSpacesWithOne_Suffix_Fails(string input)
        {
            var result = StringHelper.ReplaceMultipleSpacesWithOne(input);

            Assert.Equal("test string ", result);
        }

        [Theory]
        [InlineData("   test string")]
        [InlineData(" test string")]
        [InlineData("     test  string")]
        public void ReplaceMultipleSpacesWithOne_Prefix_Fails(string input)
        {
            var result = StringHelper.ReplaceMultipleSpacesWithOne(input);

            Assert.Equal(" test string", result);
        }

        [Theory]
        [InlineData("124 56 my new test string", "56", "test", " my new ")]
        [InlineData("124 56mynewtest string", "56", "test", "mynew")]
        public void Between_Success(string main, string start, string end, string expected)
        {
            var result = StringHelper.Between(main, start, end);

            Assert.Equal(expected, result);
        }

        [Theory]
        [InlineData("124 56 my new test string")]
        [InlineData("adfg 1 @24 56 my new test string")]
        public void RemoveAllNonNumericChars_Success(string input)
        {
            var result = StringHelper.RemoveAllNonNumericChars(input);

            Assert.Equal("12456", result);
        }

        [Theory]
        [InlineData("124.56")]
        public void ReplaceDotWithComma_Success(string input)
        {
            var result = StringHelper.ReplaceDotWithComma(input);

            Assert.Equal("124,56", result);
        }

        [Theory]
        [InlineData("    my string   ")]
        [InlineData("my string")]
        [InlineData(" my string ")]
        public void TrimString_Success(string input)
        {
            var result = StringHelper.TrimString(input);

            Assert.Equal("my string", result);
        }

        [Theory]
        [InlineData("    my string my 3546245 456   ", "my")]
        public void AllIndexesOf_Success(string input, string substring)
        {
            var result = StringHelper.AllIndexesOf(input, substring);

            Assert.Equal(2, result.Count());
        }

        [Theory]
        [InlineData(" \"Auth: krjhsa54+343= \"", "\"Auth: ", "\"", "***")]
        public void ObfuscateStringBetween_Success(string input, string startTag, string endTag, string replaceWith)
        {
            var result = StringHelper.ObfuscateStringBetween(input, startTag, endTag, replaceWith);

            Assert.Equal(" \"Auth: ***\"", result);
        }

        [Theory]
        [InlineData("TEST STRING 1")]
        [InlineData("test string 1")]
        [InlineData("Test String 1")]
        [InlineData("test String 1")]
        [InlineData("Test StrIng 1")]
        public void StringContainsCaseInsensitive_Success(string input)
        {
            Assert.True(input.ContainsCaseInsensitive("Test STrinG 1"));
        }
        
        [Theory]
        [InlineData("test string   ")]
        [InlineData("test string")]
        [InlineData("test-string ")]
        [InlineData(" test_string")]
        [InlineData("TEST string   ")]
        [InlineData("test String")]
        [InlineData("test-STRING ")]
        [InlineData(" TEST STRING")]
        public void ConvertStringToPascalCase_Success(string input)
        {
            var result = StringHelper.ToPascalCase(input, new string[]{"-","_"," "});

            Assert.Equal("TestString", result);
        }
    }
}
