using System;

namespace HW03.Calculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator calculator = new();

            Console.WriteLine("Enter two numbers (through enter button) for addition");
            int num1 = Convert.ToInt32(Console.ReadLine());
            int num2 = Convert.ToInt32(Console.ReadLine());
            int addResult = calculator.AddNumbers(num1, num2);
            Console.WriteLine($"Addition result is {addResult}");

            Console.WriteLine("Enter two numbers (through enter button) for substraction");
            int num3 = Convert.ToInt32(Console.ReadLine());
            int num4 = Convert.ToInt32(Console.ReadLine());
            int subctractResult = calculator.SubtractNumber(num3, num4);
            Console.WriteLine($"Substraction result is {subctractResult}");

            Console.WriteLine("Enter two numbers (through enter button) for multiply");
            int num5 = Convert.ToInt32(Console.ReadLine());
            int num6 = Convert.ToInt32(Console.ReadLine());
            int multiplyResult = calculator.MultiplyNumber(num5, num6);
            Console.WriteLine($"Multiplication result is {multiplyResult}");

            Console.WriteLine("Enter two numbers (through enter button) for division");
            int num7 = int.Parse(Console.ReadLine());
            int num8 = int.Parse(Console.ReadLine());
            int divisionResult = calculator.DivideByNumber(num7, num8);
            Console.WriteLine($"Division result is {divisionResult}");

            Console.WriteLine("Enter two numbers (through enter button) for calculate remainder of division");
            int num9 = int.Parse(Console.ReadLine());
            int num10 = int.Parse(Console.ReadLine());
            int remainderOfDivision = calculator.CalculateRemainderOfDivision(num9, num10);
            Console.WriteLine($"Division result is {remainderOfDivision}");

            Console.WriteLine("Enter number for calculate circle area");
            double rad = double.Parse(Console.ReadLine());
            double circleArea = calculator.CalculateCircleArea(rad);
            Console.WriteLine($"Division result is {circleArea}");

            Console.ReadLine();
        }
    }
}
