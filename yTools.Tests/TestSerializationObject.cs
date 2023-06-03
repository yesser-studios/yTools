using System.Globalization;
using System.Reflection;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace yTools.Tests
{
    [Serializable]
    public class TestSerializationObject : IXmlSerializable
    {
        public string testString;
        public int testInt;
        public double testDouble;
        public Version? testVersion;

        public TestSerializationObject(string testString, int testInt, double testDouble)
        {
            this.testString = testString;
            this.testInt = testInt;
            this.testDouble = testDouble;
            testVersion = Assembly.GetExecutingAssembly().GetName().Version;
        }

        public TestSerializationObject()
        {
            testString = string.Empty;
        }

        public override bool Equals(object? obj)
        {
            if (obj is not TestSerializationObject testCacheObject) return false;

            return testCacheObject.testString == testString
                && testCacheObject.testInt == testInt
                && testCacheObject.testDouble == testDouble
                && testCacheObject.testVersion == testVersion;
        }

        public override int GetHashCode() => HashCode.Combine(testString, testInt, testDouble, testVersion);

        public XmlSchema? GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            reader.ReadStartElement();

            testString = reader.ReadElementContentAsString("testString", "");
            testInt = reader.ReadElementContentAsInt("testInt", "");
            testDouble = reader.ReadElementContentAsDouble("testDouble", "");
            string? testVersionString = reader.ReadElementContentAsString("testVersion", "");

            if (testVersionString == null) testVersion = null;
            else testVersion = new Version(testVersionString);
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteElementString("testString", testString);
            writer.WriteElementString("testInt", testInt.ToString());
            writer.WriteElementString("testDouble", testDouble.ToString(CultureInfo.InvariantCulture));
            
            if (testVersion != null) writer.WriteElementString("testVersion", testVersion.ToString());
            else writer.WriteElementString("testVersion", string.Empty);
        }
    }
}
