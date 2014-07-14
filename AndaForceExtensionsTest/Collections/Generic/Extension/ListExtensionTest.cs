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

        [Test]
        public void TestSort()
        {
            var list = new List<int> {1, 3, 4, 8, 2, 9, 3, 1, 5};
            list.QuickSort((a, b) => a.CompareTo(b));


            var list2 = new List<SortingClass>()
            {
                new SortingClass(1, 2, 3),
                new SortingClass(1, 2, 2),
                new SortingClass(1, 1, 1),
            };

            list2.QuickSort(
                (first, second) => first.A.CompareTo(second.A),
                (first, second) => first.B.CompareTo(second.B),
                (first, second) => first.C.CompareTo(second.C));

            var arfg = 1;
        }

        internal class SortingClass
        {
            public int A;
            public int B;
            public int C;

            public SortingClass(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }
        }
    }
}