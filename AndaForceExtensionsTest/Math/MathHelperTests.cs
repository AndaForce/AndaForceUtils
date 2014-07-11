using AndaForceUtils.Math;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Math
{
    [TestFixture]
    public class MathHelperTests
    {
        private static readonly object[] TestCaseSourceFloat =
        {
            new TestDataFloat {A = 5.0f, Min = 0.0f, Max = 10.0f, Expected = 5.0f},
            new TestDataFloat {A = 10.0f, Min = 0.0f, Max = 10.0f, Expected = 10.0f},
            new TestDataFloat {A = 0.0f, Min = 0.0f, Max = 10.0f, Expected = 0.0f},
            new TestDataFloat {A = 99.0f, Min = 0.0f, Max = 11.0f, Expected = 11.0f},
            new TestDataFloat {A = -99.0f, Min = 0.0f, Max = 11.0f, Expected = 0.0f}
        };

        private static readonly object[] TestCaseSourceInt =
        {
            new TestDataInt {A = 5, Min = 0, Max = 10, Expected = 5},
            new TestDataInt {A = 10, Min = 0, Max = 10, Expected = 10},
            new TestDataInt {A = 0, Min = 0, Max = 10, Expected = 0},
            new TestDataInt {A = 99, Min = 0, Max = 11, Expected = 11},
            new TestDataInt {A = -99, Min = 0, Max = 11, Expected = 0}
        };

        [Test, TestCaseSource("TestCaseSourceFloat")]
        public void TestClampFloat(TestDataFloat v)
        {
            Assert.AreEqual(v.Expected, MathHelper.Clamp(v.A, v.Min, v.Max));
        }

        [Test, TestCaseSource("TestCaseSourceInt")]
        public void TestClampInt(TestDataInt v)
        {
            Assert.AreEqual(v.Expected, MathHelper.Clamp(v.A, v.Min, v.Max));
        }

        public class TestDataFloat
        {
            public float A;
            public float Min;
            public float Max;
            public float Expected;
        }

        public class TestDataInt
        {
            public int A;
            public int Min;
            public int Max;
            public int Expected;
        }
    }
}