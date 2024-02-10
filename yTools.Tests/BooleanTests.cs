namespace yTools.Tests;

[TestClass]
public class BooleanTests
{
    [TestMethod]
    [DataRow(true)]
    [DataRow(false)]
    public void Invert(bool boolean)
    {
        Assert.AreEqual(!boolean, Booleans.Invert(boolean));
    }
}