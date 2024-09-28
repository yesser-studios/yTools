namespace yTools.Tests
{
    [TestClass]
	public class SerializationTests
    {
        private readonly char _sep = General.PathSeparator;
        
        [TestCleanup]
        public void Cleanup()
        {
            const string testDirectory = "yTools";

            var fullDir = $"{Environment.GetFolderPath(
                Environment.SpecialFolder.LocalApplicationData
            )}{_sep}{testDirectory}";
            if (Directory.Exists(fullDir))
                Directory.Delete(fullDir, true);
        }

        [TestMethod]
        public void CheckObjectsJsonSerialized()
        {
            TestSerializationObject testObject1 = new("Hi!", 5, 465.5);
            TestSerializationObject testObject2 = new("Good Morning.", -8485, -6498.948);

            JsonSerializer serializer = new();

            var directory = $"yTools{_sep}Tests{_sep}Serialization";
            serializer.SetSerializationDirectoryInLocalAppData(directory);
            
            Assert.IsTrue(Directory.Exists(
                $"{Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                )}{_sep}{directory}"));

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

            var directory = $"yTools{_sep}Tests{_sep}Serialization";
            serializer.SetSerializationDirectoryInLocalAppData(directory);
            
            Assert.IsTrue(Directory.Exists(
                $"{Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData
                )}{_sep}{directory}"));

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

        [TestMethod]
        public void CheckSerializationDirCreated()
        {
            var baseDir = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{_sep}yTools";
            var testObj = new TestSerializationObject("FooBar", 0, 0.5);

            var jsonSerializer = new JsonSerializer();
            var xmlSerializer = new XmlSerializer();

            jsonSerializer.Serialize(testObj, "json.json", $@"{baseDir}{_sep}json", out _, out _);
            Assert.IsTrue(Directory.Exists($"{baseDir}{_sep}json"));
            
            xmlSerializer.Serialize(testObj, "xml.xml", $@"{baseDir}{_sep}xml", out _, out _);
            Assert.IsTrue(Directory.Exists($"{baseDir}{_sep}xml"));
        }

        [TestMethod]
        public void CheckDeserializeException()
        {
            var jsonSerializer = new JsonSerializer();
            var xmlSerializer = new XmlSerializer();

            jsonSerializer.Deserialize<TestSerializationObject>("hello", @"C:\whatever", out var jsonEx, out _);
            xmlSerializer.Deserialize<TestSerializationObject>("hello", @"C:\whatever", out var xmlEx, out _);

            Assert.IsNotNull(jsonEx);
            Assert.IsNotNull(xmlEx);
        }

        [TestMethod]
        public void CheckSerializeException()
        {
            TestSerializationObject testObj = new("69", 48, 5.2);
            var jsonSerializer = new JsonSerializer();
            var xmlSerializer = new XmlSerializer();
            var path = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}{_sep}yTools{_sep}\0{_sep}whatever.ser"; // Invalid path

            var jsonSerialized = jsonSerializer.Serialize(
                path, testObj, out var ex, out _);
            Assert.IsFalse(jsonSerialized);
            Assert.IsNotNull(ex);
            Console.WriteLine($"Type of Json exception: {ex.GetType()}");

            var xmlSerialized = xmlSerializer.Serialize(
                path, testObj, out ex, out _);
            Assert.IsFalse(xmlSerialized);
            Assert.IsNotNull(ex);
            Console.WriteLine($"Type of XML exception: {ex.GetType()}");
        }
    }
}