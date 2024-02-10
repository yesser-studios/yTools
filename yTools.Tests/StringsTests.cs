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
            
            Assert.AreEqual(correct, joined);
        }

        [TestMethod]
        [DataRow('h', 'e', 'l', 'l', 'o')]
        [DataRow('h', 'r', 'u')]
        [DataRow('i', 'd', 'k')]
        public void JoinChars(params char[] chars)
        {
            string joined = Strings.JoinChars(chars);
            
            string correct = "";
            foreach (var c in chars)
            {
                correct += c;
            }
            
            Assert.AreEqual(correct, joined);
        }

        [TestMethod]
        [DataRow("YO", "yo")]
        [DataRow("hello", "hello")]
        [DataRow("iDk", "idk")]
        [DataRow("69", "69")]
        [DataRow(".,'!", ".,'!")]
        [DataRow("Mhm.", "mhm.")]
        public void Lower(string str, string expected)
        {
            Assert.AreEqual(expected, Strings.Lower(str));
        }
        
        [TestMethod]
        [DataRow("YO", "YO")]
        [DataRow("hello", "HELLO")]
        [DataRow("iDk", "IDK")]
        [DataRow("69", "69")]
        [DataRow(".,'!", ".,'!")]
        [DataRow("Mhm.", "MHM.")]
        public void Upper(string str, string expected)
        {
            Assert.AreEqual(expected, Strings.Upper(str));
        }

        [TestMethod]
        [DataRow("Hello")]
        public void IsNullOrWhitespace(string str)
        {
            var expected = string.IsNullOrWhiteSpace(str);

            var actual = Strings.IsNullOrWhitespace(str);
            
            Assert.AreEqual(expected, actual);
        }
    }
}