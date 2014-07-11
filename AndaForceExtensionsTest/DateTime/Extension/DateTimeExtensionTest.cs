using System;
using AndaForceUtils.DateTime.Extension;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Tests.DateTime.Extension
{
    [TestFixture]
    public class DateTimeExtensionTest
    {
        private static readonly object[] TomorrowData =
        {
            new TestData {A = new System.DateTime(2000, 1, 1), B = new System.DateTime(2000, 1, 2), Expected = true},
            new TestData {A = new System.DateTime(2000, 1, 1), B = new System.DateTime(2000, 1, 3), Expected = false},
            new TestData {A = new System.DateTime(2000, 1, 3), B = new System.DateTime(2000, 1, 1), Expected = false}
        };

        private static readonly object[] HumanData =
        {
            new TestData {A = new System.DateTime(2000, 1, 2), B = new System.DateTime(2000, 1, 2), Expected = "Сегодня"},
            new TestData {A = new System.DateTime(2000, 1, 1), B = new System.DateTime(2000, 1, 2), Expected = "Вчера"},
            new TestData
            {
                A = new System.DateTime(2000, 1, 1),
                B = new System.DateTime(2000, 1, 3),
                Expected = GetSimpleDateString(new System.DateTime(2000, 1, 1))
            },
            new TestData
            {
                A = new System.DateTime(2000, 1, 20),
                B = new System.DateTime(2000, 1, 1),
                Expected = GetSimpleDateString(new System.DateTime(2000, 1, 20))
            }
        };

        [Test, TestCaseSource("TomorrowData")]
        public void IsTomorrowOfDateTest(TestData v)
        {
            Assert.AreEqual(v.Expected, v.A.IsTomorrowOfDate(v.B), CreateErrorMessage(v));
        }

        [Test, TestCaseSource("HumanData")]
        public void GetHumanDateString(TestData v)
        {
            Assert.AreEqual(v.Expected, v.A.GetHumanDateString(v.B), CreateErrorMessage(v));
        }

        private static String CreateErrorMessage(TestData v)
        {
            return String.Format("Failed with arguments {0} and {1}", v.A, v.B);
        }

        private static String GetSimpleDateString(System.DateTime date)
        {
            return String.Format("{0} {1}", date.Day, date.GetRussianMonthName().ToLower());
        }

        public class TestData
        {
            public System.DateTime A;
            public System.DateTime B;
            public object Expected;
        }
    }
}