using QAToolKit.Core.Helpers;
using System.Collections.Generic;
using Xunit;

namespace QAToolKit.Core.Test.Helpers
{
    public class DictionaryHelperTests
    {
        [Theory]
        [InlineData("key1")]
        [InlineData("kEy1")]
        [InlineData("caTegory")]
        [InlineData("Category")]
        [InlineData("category")]
        [InlineData("Name")]
        [InlineData("name")]
        public void DictionaryContainsKey_Success(string key)
        {
            var dictionary = new Dictionary<string, object> {
                { "Key1", "Id"},
                { "category", "cars"},
                { "Name", "MJ"}
            };

            Assert.True(dictionary.KeyExists(key)); ;
        }

        [Fact]
        public void GetDictionaryValueByCaseInsensitiveKey_Success()
        {
            var dictionary = new Dictionary<string, object> {
                { "Key1", "Id"},
                { "category", "cars"},
                { "Name", "MJ"}
            };

            Assert.Equal("Id", dictionary.GetValue("Key1"));
            Assert.Equal("Id", dictionary.GetValue("key1"));
            Assert.Equal("MJ", dictionary.GetValue("Name"));
            Assert.Equal("MJ", dictionary.GetValue("name"));
            Assert.Equal("cars", dictionary.GetValue("category"));
            Assert.Equal("cars", dictionary.GetValue("Category"));
        }
    }
}
