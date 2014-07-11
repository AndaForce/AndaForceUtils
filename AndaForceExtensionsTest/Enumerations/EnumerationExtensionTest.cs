using System;
using System.Collections;
using System.Linq;
using AndaForceUtils.Collections.Generic.Extension;
using AndaForceUtils.Enumerations;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Enumerations
{
    [TestFixture]
    public class EnumerationExtensionTest
    {
        private enum TestStringEnum
        {
            [EnumerationExtension.StringValue("First")] FirstValue = 0,
            [EnumerationExtension.StringValue("Second")] SecondValue = 1,
            [EnumerationExtension.StringValue("Third")] ThirdValue = 2
        }

        private enum TestObjectEnum
        {
            [EnumerationExtension.ObjectValue(1)] A = 0,
            [EnumerationExtension.ObjectValue(2.0f)] B = 1,
            [EnumerationExtension.ObjectValue("String")] C = 2,
            [EnumerationExtension.ObjectValue(new[] {1, 2, 3, 4, 5})] D = 3,
            [EnumerationExtension.ObjectValue(TestObjectEnum.A)] E = 4,
        }

        [Test]
        public void TestStringEnumeration()
        {
            var a = TestStringEnum.FirstValue;
            var b = TestStringEnum.SecondValue;
            var c = TestStringEnum.ThirdValue;

            const string message = "Wrong string attribute";

            Assert.AreEqual("First", a.GetStringValue(), message);
            Assert.AreEqual("Second", b.GetStringValue(), message);
            Assert.AreEqual("Third", c.GetStringValue(), message);
        }

        [Test]
        public void TestObjectEnumeration()
        {
            Assert.AreEqual(1, TestObjectEnum.A.GetObjectValue<int>(), "Wrong int value at \"A\" parameter!");
            Assert.AreEqual(2.0f, TestObjectEnum.B.GetObjectValue<float>(), "Wrong float value at \"B\" parameter!");
            Assert.AreEqual("String", TestObjectEnum.C.GetObjectValue<String>(),
                "Wrong string value at \"C\" parameter!");

            var array = new[] {1, 2, 3, 4, 5};
            var attributeArray = TestObjectEnum.D.GetObjectValue<IEnumerable>();
            var result = array.All(a => attributeArray.OfType<int>().Contains(a));
            Assert.AreEqual(true, result,
                "Wrong items in attribute array! " + attributeArray.OfType<int>().PrintElements());

            Assert.AreEqual(TestObjectEnum.A, TestObjectEnum.E.GetObjectValue<TestObjectEnum>(),
                "Wrong enum value at \"E\"");
        }
    }
}