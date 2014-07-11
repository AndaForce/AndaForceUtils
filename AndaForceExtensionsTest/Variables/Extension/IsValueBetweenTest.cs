using System;
using AndaForceUtils.Variables.Extension;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Variables.Extension
{
    [TestFixture]
    public class IsValueBetweenTest
    {
        private static readonly object[] DataII =
        {
            new TestData {Value = 5, Min = 0, Max = 9, ExpectedResult = true},
            new TestData {Value = 5, Min = 5, Max = 6, ExpectedResult = true},
            new TestData {Value = 5, Min = 4, Max = 5, ExpectedResult = true},
            new TestData {Value = 5, Min = 5, Max = 5, ExpectedResult = true},
            new TestData {Value = "A", Min = "A", Max = "B", ExpectedResult = true},
            new TestData {Value = "B", Min = "A", Max = "C", ExpectedResult = true},
            new TestData {Value = "B", Min = "B", Max = "B", ExpectedResult = true}
        };

        private static readonly object[] DataEE =
        {
            new TestData {Value = 5, Min = 0, Max = 9, ExpectedResult = true},
            new TestData {Value = 5, Min = 5, Max = 6, ExpectedResult = false},
            new TestData {Value = 5, Min = 4, Max = 5, ExpectedResult = false},
            new TestData {Value = 5, Min = 5, Max = 5, ExpectedResult = false},
            new TestData {Value = "A", Min = "A", Max = "B", ExpectedResult = false},
            new TestData {Value = "B", Min = "A", Max = "C", ExpectedResult = true},
            new TestData {Value = "B", Min = "B", Max = "B", ExpectedResult = false}
        };

        private static readonly object[] DataIE =
        {
            new TestData {Min = 0, Value = 5, Max = 9, ExpectedResult = true},
            new TestData {Min = 5, Value = 5, Max = 6, ExpectedResult = true},
            new TestData {Min = 4, Value = 5, Max = 5, ExpectedResult = false},
            new TestData {Min = 5, Value = 5, Max = 5, ExpectedResult = false},
            new TestData {Min = 6, Value = 5, Max = 5, ExpectedResult = false},
            new TestData {Value = "A", Min = "A", Max = "B", ExpectedResult = true},
            new TestData {Value = "B", Min = "A", Max = "C", ExpectedResult = true},
            new TestData {Value = "B", Min = "B", Max = "B", ExpectedResult = false}
        };

        private static readonly object[] DataEI =
        {
            new TestData {Min = 0, Value = 5, Max = 9, ExpectedResult = true},
            new TestData {Min = 5, Value = 5, Max = 6, ExpectedResult = false},
            new TestData {Min = 4, Value = 5, Max = 5, ExpectedResult = true},
            new TestData {Min = 5, Value = 5, Max = 5, ExpectedResult = false},
            new TestData {Min = 6, Value = 5, Max = 5, ExpectedResult = false},
            new TestData {Value = "A", Min = "A", Max = "B", ExpectedResult = false},
            new TestData {Value = "B", Min = "A", Max = "C", ExpectedResult = true},
            new TestData {Value = "B", Min = "B", Max = "B", ExpectedResult = false}
        };

        private string ErrorMessage(TestData v)
        {
            return String.Format("Failed with arguments  min={0}, v={1}, max={2}", v.Min, v.Value, v.Max);
        }

        [Test, TestCaseSource("DataII")]
        public void TestII(TestData v)
        {
            Assert.AreEqual(v.ExpectedResult, v.Value.BetweenII(v.Min, v.Max), ErrorMessage(v));
        }

        [Test, TestCaseSource("DataEE")]
        public void TestEE(TestData v)
        {
            Assert.AreEqual(v.ExpectedResult, v.Value.BetweenEE(v.Min, v.Max), ErrorMessage(v));
        }

        [Test, TestCaseSource("DataEI")]
        public void TestEI(TestData v)
        {
            Assert.AreEqual(v.ExpectedResult, v.Value.BetweenEI(v.Min, v.Max), ErrorMessage(v));
        }

        [Test, TestCaseSource("DataIE")]
        public void TestIE(TestData v)
        {
            Assert.AreEqual(v.ExpectedResult, v.Value.BetweenIE(v.Min, v.Max), ErrorMessage(v));
        }

        public class TestData
        {
            public IComparable Value;
            public IComparable Min;
            public IComparable Max;
            public bool ExpectedResult;
        }
    }
}