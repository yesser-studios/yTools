using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace yTools.Tests
{
    [Serializable]
    public class TestSerializationObject
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

        public override bool Equals(object? obj)
        {
            if (obj is not TestSerializationObject testCacheObject) return false;

            return testCacheObject.testString == testString
                && testCacheObject.testInt == testInt
                && testCacheObject.testDouble == testDouble
                && testCacheObject.testVersion == testVersion;
        }

        public override int GetHashCode()
        {
            // Implement a custom hash code calculation based on the values of the fields/properties
            int hash = 17;
            hash = (hash * 31) + testString.GetHashCode();
            hash = (hash * 31) + testInt.GetHashCode();
            hash = (hash * 31) + testDouble.GetHashCode();
            hash = (hash * 31) + (testVersion != null ? testVersion.GetHashCode() : 0);
            return hash;
        }
    }
}
