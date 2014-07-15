using System;
using System.Collections.Generic;
using AndaForceUtils.Collections.Generic.Extension;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.Generic.Extension
{
    [TestFixture]
    public class ListExtensionTest
    {
        #region GetRandomItem

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
                Assert.True(resultList.Contains(i),
                    String.Format("Result list doesn't contains item from source! ({0})", i));
            }
        }

        #endregion

        #region Quick Sort

        [Test]
        public void TestQuickSortWithOneComparator()
        {
            // Init
            const int testItemsCount = 1000;
            var rnd = new Random();
            var sourceList = new List<int>();
            for (int i = 0; i < testItemsCount; i++)
            {
                sourceList.Add(rnd.Next(1, 100));
            }

            // Sort
            sourceList.QuickSort((a, b) => a.CompareTo(b));

            // Check
            for (int i = 1; i < testItemsCount; i++)
            {
                if (sourceList[i] < sourceList[i - 1])
                {
                    throw new AssertionException("List is not sorted properly");
                }
            }
        }

        [Test]
        public void TestQuickSortWithManyComparators()
        {
            // Init
            const int testItemsCount = 1000;
            var rnd = new Random();
            var sourceList = new List<TestClassForSorting>();
            for (int i = 0; i < testItemsCount; i++)
            {
                sourceList.Add(
                    new TestClassForSorting(
                        rnd.Next(1, 10),    // Маленький диапазон для обеспечения более частого повторения значений
                        rnd.Next(1, 10),
                        rnd.Next(1, 10)));
            }

            // Sort
            sourceList.QuickSort(
                (a, b) => a.A.CompareTo(b.A),
                (a, b) => a.B.CompareTo(b.B),
                (a, b) => a.C.CompareTo(b.C));

            // Check
            for (int i = 1; i < testItemsCount; i++)
            {
                if (sourceList[i].CompareTo(sourceList[i - 1]) < 0)
                {
                    throw new AssertionException("List is not sorted properly");
                }
            }
        }

        internal class TestClassForSorting : IComparable<TestClassForSorting>
        {
            public int A;
            public int B;
            public int C;

            public TestClassForSorting(int a, int b, int c)
            {
                A = a;
                B = b;
                C = c;
            }

            // Иллюстрирует, насколько сложным и некрасивым может быть компаратор, использующий 3 значения для сортировки
            public int CompareTo(TestClassForSorting other)
            {
                var firstCompareResult = A.CompareTo(other.A);
                if (firstCompareResult == 0)
                {
                    var secondCompareResult = B.CompareTo(other.B);

                    if (secondCompareResult == 0)
                    {
                        return C.CompareTo(other.C);
                    }

                    return secondCompareResult;
                }

                return firstCompareResult;
            }
        }

        #endregion
    }
}