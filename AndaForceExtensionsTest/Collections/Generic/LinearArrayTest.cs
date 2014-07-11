using System;
using AndaForceUtils.Collections.Generic;
using NUnit.Framework;

namespace AndaForceExtensionsTest.Collections.Generic
{
    [TestFixture]
    public class LinearArrayTest
    {
        private Random _rnd;

        [SetUp]
        public void SetUp()
        {
            _rnd = new Random();
        }

        [Test]
        public void TestBasicMethods()
        {
            const int dimension = 100;
            var linearArray = new LinearArray<int>(dimension, dimension);

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    var rndValue = _rnd.Next();
                    linearArray.SetItem(rndValue, i, j);
                    Assert.AreEqual(rndValue, linearArray.GetItem(i, j), "Wrong item received");
                }
            }
        }

        [Test]
        public void TestConversionToLinear()
        {
            const int dimension = 100;
            var twoDimArray = new int[dimension, dimension];
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    twoDimArray[x, y] = _rnd.Next();
                }
            }

            var linearArray = LinearArray<int>.FromTwoDimensional(twoDimArray, dimension, dimension);
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    Assert.AreEqual(twoDimArray[x, y], linearArray.GetItem(x, y), "Wrong item received");
                }
            }
        }

        [Test]
        public void TestConversionToTwoDimensional()
        {
            const int dimension = 100;
            var linearArray = new LinearArray<int>(dimension, dimension);
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    linearArray.SetItem(_rnd.Next(), x, y);
                }
            }

            var twoDimensional = linearArray.ToTwoDimensional();
            for (int y = 0; y < dimension; y++)
            {
                for (int x = 0; x < dimension; x++)
                {
                    Assert.AreEqual(linearArray.GetItem(x, y), twoDimensional[x, y], "Wrong item received");
                }
            }
        }

        [Test, ExpectedException]
        public void TestCausesException()
        {
            var linear = new LinearArray<int>(3, 3);
            linear.SetItem(999, 999, 999);
        }
    }
}