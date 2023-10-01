using System;
namespace yTools.Tests
{
	[TestClass]
	public class StringsTests
	{
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
    }
}

