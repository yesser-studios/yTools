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

    [TestMethod]
    public void Vector2Casts()
    {
        Vector2 vector = new(5, 6.5);
        var castedSystemVector = (System.Numerics.Vector2)vector;

        System.Numerics.Vector2 systemVector = new(4f, 8.5f);
        Vector2 castedVector = systemVector;
        
        Assert.AreEqual(vector.X, castedSystemVector.X);
        Assert.AreEqual(vector.Y, castedSystemVector.Y);
        
        Assert.AreEqual(systemVector.X, castedVector.X);
        Assert.AreEqual(systemVector.Y, castedVector.Y);
    }
    
    [TestMethod]
    public void Vector3Casts()
    {
        Vector3 vector = new(5, 6.5, 8);
        var castedSystemVector = (System.Numerics.Vector3)vector;

        System.Numerics.Vector3 systemVector = new(4.1f, 8.5f, 45f);
        Vector3 castedVector = systemVector;
        
        Assert.AreEqual(vector.X, castedSystemVector.X);
        Assert.AreEqual(vector.Y, castedSystemVector.Y);
        Assert.AreEqual(vector.Z, castedSystemVector.Z);
        
        Assert.AreEqual(systemVector.X, castedVector.X);
        Assert.AreEqual(systemVector.Y, castedVector.Y);
        Assert.AreEqual(systemVector.Z, castedVector.Z);
    }
}