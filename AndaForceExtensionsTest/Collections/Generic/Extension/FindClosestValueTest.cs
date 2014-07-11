using System;
using AndaForceUtils.Collections.Generic.Extension;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.Generic.Extension
{
    [TestFixture]
    public class FindClosestValueTest
    {
        [Test]
        public void TestThis()
        {
            for (int i = 0; i < 100; i++)
            {
                var arr = new[] { -3072, -1024, 1024, 3072 };
                Console.WriteLine(arr.FindFirstClosest(66) + "\n");
            }

            var a = 1;
        }
    }
}
