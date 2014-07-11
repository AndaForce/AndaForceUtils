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
        public void TestGetRandomItem()
        {
            var list = new List<int> {1, 2, 3, 4, 5};
            var randomItem = list.GetRandomItem();

            Assert.IsTrue(list.Contains(randomItem), "Wrong item received");
        }

        [Test]
        public void TestGetOneItem()
        {
            var list = new List<int> {123456789};

            Assert.AreEqual(123456789, list.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestEmpty()
        {
            var list = new List<int>();

            Assert.AreEqual(0, list.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestSpread()
        {
            var list = new List<int> {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var testList = new List<int>();

            for (int i = 0; i < 1000; i++)
            {
                testList.Add(list.GetRandomItem());
            }

            foreach (var i in list)
            {
                Assert.True(testList.Contains(i), String.Format("Result list doesn't contains source item! ({0})", i));
            }
        }
    }
}