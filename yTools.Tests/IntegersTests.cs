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
            bool isPrimeNoSave = Integers.IsPrimeWithoutSaving(number);
            Assert.IsTrue(isPrime);
            Assert.IsTrue(isPrimeNoSave);
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
            bool isPrimeNoSave = Integers.IsPrimeWithoutSaving(number);
            Assert.IsFalse(isPrime);
            Assert.IsFalse(isPrimeNoSave);
        }

        [TestMethod]
        [DataRow(11)]
        public void IsPrimeTrueCache(int number)
        {
            bool isPrime = Integers.IsPrime(number);
            Assert.IsTrue(isPrime);
            Assert.IsTrue(Integers.PrimeNumbersProp.Contains(number));
        }
        
        [TestMethod]
        [DataRow(9)]
        public void IsPrimeFalseCache(int number)
        {
            bool isPrime = Integers.IsPrime(number);
            Assert.IsFalse(isPrime);
            Assert.IsTrue(Integers.NotPrimeNumbersProp.Contains(number));
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