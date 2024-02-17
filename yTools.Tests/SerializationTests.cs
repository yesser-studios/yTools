namespace yTools.Tests
{
    [TestClass]
	public class SerializationTests
	{
        [TestCleanup]
        public void Cleanup()
        {
            const string testDirectory = @"yTools";

            var fullDir = $"{Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData
            )}\\{testDirectory}";
            if (Directory.Exists(fullDir))
                Directory.Delete(fullDir, true);
        }
        
        [TestMethod]
        public void CheckObjectsBinarySerialized()
        {
            TestSerializationObject testObject1 = new("Hi!", 5, 465.5);
            TestSerializationObject testObject2 = new("Good Morning.", -8485, -6498.948);

            BinarySerializer serializer = new();

            const string directory = @"yTools\Tests\Serialization";
            serializer.SetSerializationDirectoryInLocalAppData(directory);
            
            Assert.IsTrue(Directory.Exists(
                $"{Environment.GetFolderPath(
                        Environment.SpecialFolder.LocalApplicationData
                    )}\\{directory}"));

            var serialized = serializer.SerializeInDefault("testObject1.bin", testObject1, out Exception? exception, out _);
            if (!serialized && exception != null) throw exception;
            serialized = serializer.SerializeInDefault("testObject2.bin", testObject2, out exception, out _);
            if (!serialized && exception != null) throw exception;

            var deserialized1 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject1.bin", out exception, out _);
            if (deserialized1 == null && exception != null) throw exception;
            var deserialized2 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject2.bin", out exception, out _);
            if (deserialized2 == null && exception != null) throw exception;

            if (deserialized1 == null) throw new ArgumentNullException(nameof(deserialized1) + "was null.");
            if (deserialized2 == null) throw new ArgumentNullException(nameof(deserialized2) + "was null.");

            Assert.IsTrue(deserialized1.Equals(testObject1) && deserialized2.Equals(testObject2));
        }

        [TestMethod]
        public void CheckObjectsJsonSerialized()
        {
            TestSerializationObject testObject1 = new("Hi!", 5, 465.5);
            TestSerializationObject testObject2 = new("Good Morning.", -8485, -6498.948);

            JsonSerializer serializer = new();

            const string directory = @"yTools\Tests\Serialization";
            serializer.SetSerializationDirectoryInLocalAppData(directory);
            
            Assert.IsTrue(Directory.Exists(
                $"{Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                )}\\{directory}"));

            bool serialized = serializer.SerializeInDefault("testObject1.json", testObject1, out Exception? exception, out _);
            if (!serialized && exception != null) throw exception;
            serialized = serializer.SerializeInDefault("testObject2.json", testObject2, out exception, out _);
            if (!serialized && exception != null) throw exception;

            var deserialized1 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject1.json", out exception, out _);
            if (deserialized1 == null && exception != null) throw exception;
            var deserialized2 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject2.json", out exception, out _);
            if (deserialized2 == null && exception != null) throw exception;

            if (deserialized1 == null) throw new ArgumentNullException(nameof(deserialized1) + "was null.");
            if (deserialized2 == null) throw new ArgumentNullException(nameof(deserialized2) + "was null.");

            Assert.IsTrue(deserialized1.Equals(testObject1) && deserialized2.Equals(testObject2));
        }

        [TestMethod]
        public void CheckObjectsXmlSerialized()
        {
            TestSerializationObject testObject1 = new("Hi!", 5, 465.5);
            TestSerializationObject testObject2 = new("Good Morning.", -8485, -6498.948);

            XmlSerializer serializer = new();

            const string directory = @"yTools\Tests\Serialization";
            serializer.SetSerializationDirectoryInLocalAppData(directory);
            
            Assert.IsTrue(Directory.Exists(
                $"{Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                )}\\{directory}"));

            bool serialized = serializer.SerializeInDefault("testObject1.xml", testObject1, out Exception? exception, out _);
            if (!serialized && exception != null) throw exception;
            serialized = serializer.SerializeInDefault("testObject2.xml", testObject2, out exception, out _);
            if (!serialized && exception != null) throw exception;

            var deserialized1 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject1.xml", out exception, out _);
            if (deserialized1 == null && exception != null) throw exception;
            var deserialized2 = serializer.DeserializeFromDefault<TestSerializationObject>("testObject2.xml", out exception, out _);
            if (deserialized2 == null && exception != null) throw exception;

            if (deserialized1 == null) throw new ArgumentNullException(nameof(deserialized1) + "was null.");
            if (deserialized2 == null) throw new ArgumentNullException(nameof(deserialized2) + "was null.");

            Assert.IsTrue(deserialized1.Equals(testObject1) && deserialized2.Equals(testObject2));
        }
    }
}