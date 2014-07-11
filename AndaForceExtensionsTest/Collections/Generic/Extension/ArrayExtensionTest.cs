using System;
using System.Linq;
using AndaForceUtils.Collections.Generic.Extension;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.Generic.Extension
{
    [TestFixture]
    public class ArrayExtensionTest
    {
        [Test]
        public void TestGetRandomItem()
        {
            var array = new[] {1, 2, 3, 4, 5, 6};
            var randomItem = array.GetRandomItem();

            Assert.IsTrue(array.Contains(randomItem), "Wrong item received");
        }

        [Test]
        public void TestGetOneItem()
        {
            var array = new[] {123456789};

            Assert.AreEqual(123456789, array.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestEmpty()
        {
            var array = new int[0];

            Assert.AreEqual(0, array.GetRandomItem(), "Wrong item received");
        }

        [Test]
        public void TestSpread()
        {
            var array = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9};
            var testList = new int[1000];

            for (int i = 0; i < 1000; i++)
            {
                testList[i] = array.GetRandomItem();
            }

            foreach (var i in array)
            {
                Assert.True(testList.Contains(i), String.Format("Result array doesn't contains source item! ({0})", i));
            }
        }
    }
}