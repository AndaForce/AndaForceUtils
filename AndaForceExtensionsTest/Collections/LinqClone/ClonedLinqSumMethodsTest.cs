using System;
using System.Collections.Generic;
using AndaForceUtils.Collections.Generic.Extension;
using AndaForceUtils.Collections.LinqClone;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.LinqClone
{
    [TestFixture]
    public class ClonedLinqSumMethodsTest
    {
        private static readonly object[] TestCaseSingle =
        {
            new TestDataSingle {Collection = new List<float> {1.0f, 2.0f, 3.0f, 4.0f, 5.0f}, Expected = 15.0f},
            new TestDataSingle {Collection = new List<float> {-1.0f, -2.0f, -3.0f, -4.0f, -5.0f}, Expected = -15.0f},
            new TestDataSingle {Collection = new List<float> {1.0f, 2.0f, 3.0f, -6.0f}, Expected = 0.0f}
        };


        private static readonly object[] TestCaseInt32 =
        {
            new TestDataInt32 {Collection = new List<int> {1, 2, 3, 4, 5}, Expected = 15},
            new TestDataInt32 {Collection = new List<int> {-1, -2, -3, -4, -5}, Expected = -15},
            new TestDataInt32 {Collection = new List<int> {1, 2, 3, -6}, Expected = 0}
        };

        [Test, TestCaseSource("TestCaseSingle")]
        public void Test(TestDataSingle data)
        {
            Assert.AreEqual(data.Expected, data.Collection.ClonedSum(),
                String.Format("Failed with arguments c: {0}, exp {1}", data.Collection.PrintElements(), data.Expected));
        }

        [Test, TestCaseSource("TestCaseInt32")]
        public void Test(TestDataInt32 data)
        {
            Assert.AreEqual(data.Expected, data.Collection.ClonedSum(),
                String.Format("Failed with arguments collection: {0}, exp {1}", data.Collection.PrintElements(),
                    data.Expected));
        }

        public class TestDataSingle
        {
            public List<Single> Collection;
            public Single Expected;
        }

        public class TestDataInt32
        {
            public List<Int32> Collection;
            public Int32 Expected;
        }
    }
}