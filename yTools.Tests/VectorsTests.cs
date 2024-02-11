using yTools.Vectors;

namespace yTools.Tests;

[TestClass]
public class VectorsTests
{
    [TestMethod]
    public void Vector2ToString()
    {
        Vector2 vector = new(49.5, 50);

        var expected = $"{vector.X},{vector.Y}";
        var actual = vector.ToString();
        
        Assert.AreEqual(expected, actual);
    }
    
    [TestMethod]
    public void Vector3ToString()
    {
        Vector3 vector = new(49, 50.1, 51);

        var expected = $"{vector.X},{vector.Y},{vector.Z}";
        var actual = vector.ToString();
        
        Assert.AreEqual(expected, actual);
    }
}