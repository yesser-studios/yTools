namespace yTools.Tests;

[TestClass]
public class DoublesTests
{
    [TestMethod]
    [DataRow(5, 0)]
    [DataRow(5.69, 47.9)]
    [DataRow(57979.46, 4798.689, 78.967)]
    public void Sum(params double[] nums)
    {
        var expected = nums.Sum();

        var summed = Doubles.Sum(nums);

        Assert.AreEqual(expected, summed);
    }

    [TestMethod]
    [DataRow(5, 0)]
    [DataRow(5.69, 47.9)]
    [DataRow(57979.46, 4798.689, 78.967)]
    public void Average(params double[] nums)
    {
        var expected = nums.Average();

        var average = Doubles.Average(nums);

        Assert.AreEqual(expected, average);
    }

    [TestMethod]
    [DataRow(5, 0)]
    [DataRow(5.69, 47.9)]
    [DataRow(57979.46, 4798.689, 78.967)]
    public void Max(params double[] nums)
    {
        var expected = nums.Max();

        var max = Doubles.Max(nums);

        Assert.AreEqual(expected, max);
    }

    [TestMethod]
    [DataRow(5, 0)]
    [DataRow(5.69, 47.9)]
    [DataRow(57979.46, 4798.689, 78.967)]
    public void Min(params double[] nums)
    {
        var expected = nums.Min();

        var min = Doubles.Min(nums);

        Assert.AreEqual(expected, min);
    }

    [TestMethod]
    [DataRow(5, 4)]
    [DataRow(5.69, 47.9)]
    public void Power(double a, double b)
    {
        var expected = Math.Pow(a, b);

        var actual = Doubles.Power(a, b);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(69)]
    [DataRow(4.5)]
    [DataRow(47.9)]
    public void SquareRoot(double num)
    {
        var expected = Math.Sqrt(num);

        var actual = Doubles.SquareRoot(num);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(69)]
    [DataRow(4.5)]
    [DataRow(47.9)]
    public void CubeRoot(double num)
    {
        var expected = Math.Cbrt(num);

        var actual = Doubles.CubeRoot(num);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(5, 4)]
    [DataRow(5.69, 47.9)]
    public void Add(double a, double b)
    {
        var expected = a + b;

        var actual = Doubles.Add(a, b);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(5, 4)]
    [DataRow(5.69, 47.9)]
    public void Subtract(double a, double b)
    {
        var expected = a - b;

        var actual = Doubles.Substract(a, b);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(5, 4)]
    [DataRow(5.69, 47.9)]
    public void Multiply(double a, double b)
    {
        var expected = a * b;

        var actual = Doubles.Multiply(a, b);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(5, 4)]
    [DataRow(5.69, 47.9)]
    public void Divide(double a, double b)
    {
        var expected = a / b;

        var actual = Doubles.Divide(a, b);

        Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow(5, 4)]
    [DataRow(5.69, 47.9)]
    public void Remainder(double a, double b)
    {
        var expected = a % b;

        var actual = Doubles.Remainder(a, b);

        Assert.AreEqual(expected, actual);
    }
}