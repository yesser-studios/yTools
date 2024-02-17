namespace yTools.Tests;

[TestClass]
public class GeneralTests
{
    [TestMethod]
    [DataRow(50)]
    [DataRow("FooBar")]
    [DataRow(24f)]
    [DataRow(32L)]
    [DataRow(new[] { 6, 7, 8, 9 })]
    public void GetInput(object expected)
    {
        var actual = General.GetInput(expected);
        
        Assert.AreSame(expected, actual);
    }
}