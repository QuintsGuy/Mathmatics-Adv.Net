namespace Mathmatics.Test;

public class BasicMathTest
{
    [Fact]
    public void TestAddTwoNumbers()
    {
        BasicMath basicMath = new BasicMath();
        int result = basicMath.Add(5, 3);
        Assert.Equal(8, result);
    }
    
    [Fact]
    public void TestSubtractTwoNumbers()
    {
        BasicMath basicMath = new BasicMath();
        int result = basicMath.Subtract(5, 3);
        Assert.Equal(2, result);
    }
    
    [Fact]
    public void TestMultiplyTwoNumbers()
    {
        BasicMath basicMath = new BasicMath();
        int result = basicMath.Multiply(5, 3);
        Assert.Equal(15, result);
    }
    
    [Fact]
    public void TestDivideTwoNumbers()
    {
        BasicMath basicMath = new BasicMath();
        int result = basicMath.Divide(6, 3);
        Assert.Equal(2, result);
    }
}