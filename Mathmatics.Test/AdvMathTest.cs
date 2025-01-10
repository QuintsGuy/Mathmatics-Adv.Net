namespace Mathmatics.Test;

public class AdvMathTest : IClassFixture<AdvMathTestFixture>
{
    private AdvMathTestFixture _fixture;

    public AdvMathTest(AdvMathTestFixture fixture)
    {
        _fixture = fixture;
    }

    [Theory]
    [InlineData(2, 5, 10)]
    [InlineData(30, 10, 300)]
    [InlineData(12, 5, 60)]
    public void TestCalculateArea(int height, int width, int expectedResult)
    {
        int result = _fixture.TestObject.CalculateArea(height, width);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(new double[] { 12.3, 14.6, 15.2, 9.8, 10.8, 16.7 }, 13.233333333333333)]
    [InlineData(new double[] { 1.0, 2.0, 3.0, 4.0, 5.0 }, 3.0)]
    [InlineData(new double[] { 10.0 }, 10.0)]
    public void TestCalculateAverage(double[] doublesArray, double expectedResult)
    {
        List<double> doublesList = new List<double>(doublesArray);
        double average = _fixture.TestObject.CalculateAverage(doublesList);
        Assert.Equal(expectedResult, average);
    }

    [Fact]
    public void TestCalculateSquare()
    {
        double result = _fixture.TestObject.CalculateSquare(5);
        Assert.Equal(25, result);
    }

    [Theory]
    [InlineData(3.0, 4.0, 5.0)]
    [InlineData(5, 12, 13)]
    [InlineData(8, 15, 17)]
    public void TestPythagoreanTheorem(double a, double b, double expectedResult)
    {
        double result = _fixture.TestObject.PythagoreanTheorem(a, b);
        Assert.Equal(expectedResult, result);
    }
}