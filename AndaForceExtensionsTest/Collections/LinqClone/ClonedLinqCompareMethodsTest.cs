using System;
using System.Collections.Generic;
using AndaForceUtils.Collections.Generic.Extension;
using AndaForceUtils.Collections.LinqClone;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.LinqClone
{
    [TestFixture]
    public class ClonedLinqCompareMethodsTest
    {
        private static readonly object[] TestCase =
        {
            new TestData
            {
                Collection = new List<IComparable> {1.0f, 2.0f, 3.0f, 4.0f, 5.0f},
                ExpectedMax = 5.0f,
                ExpectedMin = 1
            },
            new TestData {Collection = new List<IComparable> {1, 2, 3, 4, 5}, ExpectedMax = 5, ExpectedMin = 1},
            new TestData {Collection = new List<IComparable> {1, 1, 1, 1, 1}, ExpectedMax = 1, ExpectedMin = 1}
        };

        [Test, TestCaseSource("TestCase")]
        public void TestClonedMax(TestData data)
        {
            Assert.AreEqual(data.ExpectedMax, data.Collection.ClonedMax(),
                String.Format("Failed with arguments c: {0}, exp {1}", data.Collection.PrintElements(), data.ExpectedMax));
        }

        [Test, TestCaseSource("TestCase")]
        public void TestClonedMin(TestData data)
        {
            Assert.AreEqual(data.ExpectedMin, data.Collection.ClonedMin(),
                String.Format("Failed with arguments c: {0}, exp {1}", data.Collection.PrintElements(), data.ExpectedMin));
        }

        public class TestData
        {
            public List<IComparable> Collection;
            public IComparable ExpectedMin;
            public IComparable ExpectedMax;
        }
    }
}