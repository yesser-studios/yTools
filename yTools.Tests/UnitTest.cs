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
        [DataRow(492764639)]
        public void IsPrimeFalse(int number)
        {
            bool isPrime = Integers.IsPrime(number);
            Assert.IsFalse(isPrime);
        }

        [TestMethod]
        [DataRow(0)]
        [DataRow(-526346.5)]
        [DataRow(double.MaxValue)]
        [DataRow(double.MinValue)]
        public void ConvertToString(double value)
        {
            string? converted = Strings.ToString(value);
            Assert.AreEqual(converted, value.ToString());
        }

        [TestMethod]
        public void CheckObjectsBinarySerialized()
        {
            TestSerializationObject testObject1 = new TestSerializationObject("Hi!", 5, 465.5);
            TestSerializationObject testObject2 = new TestSerializationObject("Good Morning.", -8485, -6498.948);

            BinarySerializer serializer = new();

            serializer.SetSerializationDirectoryInLocalAppData(@"yTools\Tests\Serialization");

            bool serialized = serializer.SerializeInDefault("testObject1", testObject1, out Exception? exception, out _);
            if (!serialized && exception != null) throw exception;
            serialized = serializer.SerializeInDefault("testObject2", testObject2, out exception, out _);
            if (!serialized && exception != null) throw exception;

            var deserialized1 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject1", out exception, out _);
            if (deserialized1 != null && exception != null) throw exception;
            var deserialized2 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject2", out exception, out _);
            if (deserialized2 != null && exception != null) throw exception;

            if (deserialized1 == null) throw new ArgumentNullException(nameof(deserialized1) + "was null.");
            if (deserialized2 == null) throw new ArgumentNullException(nameof(deserialized2) + "was null.");

            Assert.IsTrue(deserialized1.Equals(testObject1) && deserialized2.Equals(testObject2));
        }
    }
}