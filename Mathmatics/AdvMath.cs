using System.Globalization;

namespace Mathmatics;

public class AdvMath
{
    public int CalculateArea(int height, int width)
    {
        return height * width;
    }

    public double CalculateAverage(List<double> listOfDoubles)
    {
        double sum = 0;
        foreach (double d in listOfDoubles)
        {
            sum += d;
        }

        return sum / listOfDoubles.Count;
    }

    public double CalculateSquare(double number)
    {
        return number * number;
    }

    public double PythagoreanTheorem(double a, double b)
    {
        double c2 = CalculateSquare(a) + CalculateSquare(b);
        return Math.Sqrt(c2);
    }
}