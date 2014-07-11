using NUnit.Framework;

namespace AndaForceExtensionsTest.DateTime.FluentDateTime
{
    public class DateAssert
    {
        public static void AreEqual(System.DateTime expected, System.DateTime actual, string message)
        {
            Assert.That(actual == expected && actual.Kind == expected.Kind, Is.True, message, null);
        }
        public static void AreEqual(System.DateTime expected, System.DateTime actual)
        {
            AreEqual(expected, actual, null);
        }
    }
}