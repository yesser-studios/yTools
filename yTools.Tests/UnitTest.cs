using yTools;

namespace yTools.Tests
{
    [TestClass]
    public class UnitTest
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
        public void IsPrimeFalse(int number)
        {
            bool isPrime = Integers.IsPrime(number);
            Assert.IsFalse(isPrime);
        }
    }
}