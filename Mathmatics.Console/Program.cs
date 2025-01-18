using System.Globalization;

namespace Mathmatics.Console;
using System;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            if (args.Length < 1)
            {
                throw new ArgumentException("Please specify the type of math function ('basic' or 'advanced').");
            }

            string mathType = args[0].ToLower();

            if (mathType == "basic")
            {
                HandleBasicMath(args);
            }
            else if (mathType == "advanced")
            {
                HandleAdvancedMath(args);
            }
            else
            {
                throw new ArgumentException("Invalid math");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"[ERROR] Something went wrong: {ex.Message.ToString()}");
        }

        static void HandleBasicMath(string[] args)
        {
            ValidateBasicMathArguments(args, out string operation, out int operand1, out int operand2);

            BasicMath basicMath = new BasicMath();
            int result;
            string operationDescription;
            
            switch (operation)
            {
                case "+":
                {
                    result = basicMath.Add(operand1, operand2);
                    operationDescription = "plus";
                    break;
                }
                case "-":
                {
                    result = basicMath.Subtract(operand1, operand1);
                    operationDescription = "minus";
                    break;
                }
                case "*":
                {
                    result = basicMath.Multiply(operand1, operand2);
                    operationDescription = "multiplied by";
                    break;
                }
                case "/":
                {
                    result = basicMath.Divide(operand1, operand2);
                    operationDescription = "divided by";
                    break;
                }
                default:
                {
                    throw new Exception("An unexpected error occured.");
                }
            }
            
            Console.WriteLine($"{operand1} {operationDescription} {operand2} is equal to {result}");
        }

        static void HandleAdvancedMath(string[] args)
        {
            if (args.Length < 2)
            {
                throw new ArgumentException("Not enough arguments were passed to perform the operation");
            }

            string function = args[1].ToLower();
            AdvMath advMath = new AdvMath();

            switch (function)
            {
                case "area":
                    if (args.Length < 4 || !int.TryParse(args[2], out int height ) || !int.TryParse(args[3], out int width))
                    {
                        throw new ArgumentException("Invalid parameters for 'area'.");
                    }

                    int area = advMath.CalculateArea(height, width);
                    Console.WriteLine($"The area of a rectangle with heigh {height} and width {width} is {area}.");
                    break;
                
                case "average":
                    if (args.Length < 3)
                    {
                        throw new ArgumentException("Invalid parameters for 'average'.");
                    }

                    string[] doubleStrings = args[2].Split(',');
                    List<double> doubles = new List<double>();
                    foreach (string str in doubleStrings)
                    {
                        if (double.TryParse(str, NumberStyles.Float, CultureInfo.InvariantCulture, out double value))
                        {
                            doubles.Add(value);
                        }
                        else
                        {
                            throw new ArgumentException($"Invalid number '{str}' in the list.");
                        }
                    }

                    double average = advMath.CalculateAverage(doubles);
                    Console.WriteLine($"The average of the provided numbers is {average:F2}.");
                    break;
                
                case "square":
                    if (args.Length < 3 || !double.TryParse(args[2], out double number))
                    {
                        throw new ArgumentException("Invalid parameter for 'square'.");
                    }

                    double square = advMath.CalculateSquare(number);
                    Console.WriteLine($"The square of {number} is {square}");
                    break;
                
                case "pythagorean":
                    if (args.Length < 4 || !double.TryParse(args[2], out double a) || !double.TryParse(args[3], out double b))
                    {
                        throw new ArgumentException("Invalid parameters for 'pythagorean'.");
                    }

                    double hypotenuse = advMath.PythagoreanTheorem(a, b);
                    Console.WriteLine($"The hypotenuse of a right triangle with sides {a} and {b} is {hypotenuse}");
                    break;
                
                default:
                    throw new ArgumentException("Invalid advanced math function. Use 'area', 'average', 'square', or 'pythagorean'.");
            }
        }
    }

    private static void ValidateBasicMathArguments(string[] args, out string operation, out int operand1, out int operand2)
    {
        if (args.Length < 3)
        {
            throw new ArgumentOutOfRangeException("Not enough arguments were passed to perform the operation");
        }
        
        if (args[0] != "+" && args[0] != "-" && args[0] != "*" && args[0] != "/")
        {
            throw new ArgumentException("First argument must be a math operator.");
        }
        
        if (!int.TryParse(args[1], out operand1))
        {
            throw new ArgumentException("Second argument must be a valid integer.");
        }
        
        if (!int.TryParse(args[2], out operand2))
        {
            throw new ArgumentException("Third argument must be a valid integer.");
        }

        operation = args[0];
    }
}