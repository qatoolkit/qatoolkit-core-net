using QAToolKit.Core.Helpers;
using System.Collections.Generic;
using Xunit;

namespace QAToolKit.Core.Test.Helpers
{
    public class DictionaryHelperTests
    {
        [Fact]
        public void DictionaryContainsKey_Success()
        {
            var dictionary = new Dictionary<string, object> {
                { "Key1", "Id"},
                { "category", "cars"},
                { "Name", "MJ"}
            };

            Assert.True(dictionary.KeyExists("key1"));
            Assert.True(dictionary.KeyExists("kEy1"));
            Assert.True(dictionary.KeyExists("caTegory"));
            Assert.True(dictionary.KeyExists("Category"));
            Assert.True(dictionary.KeyExists("category"));
            Assert.True(dictionary.KeyExists("Name"));
            Assert.True(dictionary.KeyExists("name"));
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
