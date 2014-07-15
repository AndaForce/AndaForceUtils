using System;
using System.Collections.Generic;
using AndaForceUtils.Collections.Generic.Extension;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.Generic.Extension
{
    [TestFixture]
    public class ListExtensionTest
    {
        [Test]
        public void TestGetRandomItemOnce()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var randomItem = list.GetRandomItem();

            Assert.IsTrue(list.Contains(randomItem), "Wrong item received");
        }

        [Test]
        public void TestGetRandomItemFromOneItemList()
        {
            var list = new List<int> {123456789};

            Assert.AreEqual(123456789, list.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestGetRandomItemFromEmptyList()
        {
            var list = new List<int>();

            Assert.AreEqual(0, list.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestGetRandomItemManyTimes()
        {
            var sourceList = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var resultList = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                resultList.Add(sourceList.GetRandomItem());
            }

            foreach (var i in sourceList)
            {
                Assert.True(resultList.Contains(i), String.Format("Result list doesn't contains item from source! ({0})", i));
            }
        }
    }
}