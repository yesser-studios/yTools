using System;
using yTools;

namespace yTools.Tests
{
    [TestClass]
    public class IntegersTests
    {
        [TestMethod]
        [TestCategory("UnitTest")]
        [DataRow(2)]
        [DataRow(3)]
        [DataRow(5)]
        [DataRow(7)]
        [DataRow(11)]
        [DataRow(281)]
        public void IsPrimeTrue(int number)
        {
            bool isPrime = Integers.IsPrime(number);
            Assert.IsTrue(isPrime);
        }

        [TestMethod]
        [TestCategory("UnitTest")]
        [DataRow(-1)]
        [DataRow(0)]
        [DataRow(1)]
        [DataRow(4)]
        [DataRow(9)]
        [DataRow(371)]
        [DataRow(492764639)]
        public void IsPrimeFalse(int number)
        {
            bool isPrime = Integers.IsPrime(number);
            Assert.IsFalse(isPrime);
        }

        [TestMethod]
        [DataRow(new object[]
        {
            0,
            2,
            69
        })]
        [DataRow(new object[]
        {
            "Hello",
            "It's me"
        })]
        public void ArrayLenght(object[] array)
        {
            int count = Integers.Count(array);
            Assert.AreEqual(count, array.Length);
        }
	}
}