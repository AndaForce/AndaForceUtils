using System;
using System.Collections.Generic;
using AndaForceUtils.Collections.Generic.Extension;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.Generic.Extension
{
    [TestFixture]
    public class DictionaryExtensionTest
    {
        [Test]
        public void TestGetRandomKey()
        {
            var dictionary = new Dictionary<int, String>
            {
                {0, "0"},
                {1, "1"},
                {2, "2"},
                {3, "3"},
                {4, "4"},
                {5, "5"},
            };
            var randomKey = dictionary.GetRandomKey();

            Assert.IsTrue(dictionary.ContainsKey(randomKey), "Wrong key received");
        }

        [Test]
        public void TestGetRandomItem()
        {
            var dictionary = new Dictionary<int, String>
            {
                {0, "0"},
                {1, "1"},
                {2, "2"},
                {3, "3"},
                {4, "4"},
                {5, "5"},
            };
            var randomItem = dictionary.GetRandomItem();

            Assert.IsTrue(dictionary.ContainsValue(randomItem), "Wrong value received");
        }

        [Test]
        public void TestGetOneKey()
        {
            var dictionary = new Dictionary<int, String>
            {
                {123, "123"}
            };

            Assert.AreEqual(123, dictionary.GetRandomKey(), "Wrong item received");
        }

        [Test]
        public void TestGetOneItem()
        {
            var dictionary = new Dictionary<int, String>
            {
                {123, "123"}
            };

            Assert.AreEqual("123", dictionary.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestEmptyKeys()
        {
            var dictionary = new Dictionary<int, String>();

            Assert.AreEqual(0, dictionary.GetRandomKey(), "Wrong key received");
        }

        [Test]
        public void TestEmptyItem()
        {
            var dictionary = new Dictionary<int, String>();

            Assert.AreEqual(null, dictionary.GetRandomItem(), "Wrong item received");
        }
    }
}