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

        public override int GetHashCode() => HashCode.Combine(testString, testInt, testDouble, testVersion);
    }
}
