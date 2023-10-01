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

        [TestMethod]
        [DataRow("hello", "there")]
        [DataRow("ey", "o")]
        [DataRow("br","uh")]
        [DataRow("Hi, ", "I'm ", "yesseruser")]
        public void JoinStrings(params string[] strings)
        {
            string joined = Strings.JoinStrings(strings);
            string correct = "";
            foreach (var str in strings)
            {
                correct += str;
            }
            Assert.AreEqual(joined, correct);
        }
    }
}

