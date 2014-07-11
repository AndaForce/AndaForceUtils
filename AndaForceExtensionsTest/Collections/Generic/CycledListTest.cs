using System;
using System.Linq;
using AndaForceUtils.Collections.Generic;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.Generic
{
    [TestFixture]
    public class CycledListTest
    {
        private Random _rnd;

        [SetUp]
        public void SetUp()
        {
            _rnd = new Random();
        }

        [Test, ExpectedException(typeof (IndexOutOfRangeException))]
        public void TestBorderRestrictions()
        {
            var emptyList = new CycledList<int>();
            var a = emptyList.GetCurrent();
            var b = emptyList.GetNext();
            var c = emptyList.GetPrev();
        }

        [Test]
        public void TestGetCurrentElement()
        {
            const int myValue = 1;

            var simpleList = new CycledList<int>();
            simpleList.Add(1);

            var getMyValueBack = simpleList.GetCurrent();

            Assert.AreEqual(myValue, getMyValueBack, "Wrong value is returned");
        }

        [Test]
        public void TestGetCycleForward()
        {
            var cycledList = new CycledList<int>(new[] {1, 2, 3, 4});
            var summ = 0;
            for (int i = 0; i < cycledList.Lenght * 2; i++)
            {
                summ += cycledList.GetNext();
            }

            var allSummX2 = cycledList.ListSource.Sum(a => a) * 2;

            Assert.AreEqual(allSummX2, summ, "Wrong cycle summ result");
        }

        [Test]
        public void TestGetCycleBackward()
        {
            var cycledList = new CycledList<int>(new[] {1, 2, 3, 4});
            var summ = 0;
            for (int i = 0; i < cycledList.Lenght * 2; i++)
            {
                summ += cycledList.GetPrev();
            }

            var allSummX2 = cycledList.ListSource.Sum(a => a) * 2;

            Assert.AreEqual(allSummX2, summ, "Wrong cycle summ result");
        }

        [Test]
        public void TestMovings()
        {
            var cycledList = new CycledList<int>(new[] {1, 2, 3, 4, 5, 6, 7, 8, 9});

            var firstValue = cycledList.GetCurrent();
            Assert.AreEqual(1, firstValue, "Wrong first value");

            cycledList.SwithPositionToEnd();
            Assert.AreEqual(9, cycledList.GetCurrent(), "Wrong last value");

            cycledList.SwitchPositionToStart();
            Assert.AreEqual(1, cycledList.GetCurrent(), "Wrong start value again");

            // 3 forward, we are at 4 (3 from zero) now?
            cycledList.GetNext();
            cycledList.GetNext();
            cycledList.GetNext();
            Assert.AreEqual(3, cycledList.CurrentPosition, "Wrong position");

            // 4 backward to move to last item?
            cycledList.GetPrev();
            cycledList.GetPrev();
            cycledList.GetPrev();
            var lastOrNot = cycledList.GetPrev();
            Assert.AreEqual(9, lastOrNot, "Wrong value");
        }
    }
}