using System;

namespace HW._05.Quadratic.Formula
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input coefficient a:");
            double a = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input coefficient b:");
            double b = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Input coefficient c:");
            double c = Convert.ToDouble(Console.ReadLine());

            double D = ((Math.Pow(b, 2)) - 4 * a * c);

            if (D < 0)
            {
                Console.WriteLine("The discriminant is less than zero. No solutions");
            }
            else if (D == 0)
            {
                double x = ((-b / 2 * a));
                Console.WriteLine($"The discriminant is zero. The equation has one solution. Quadratic root is: x = {x}");
                Console.ReadKey();
            }
            else if (D > 0)
            {
                double x_1 = (((-b + Math.Sqrt(D)) / 2 * a));
                double x_2 = (((-b - Math.Sqrt(D)) / 2 * a));
                Console.WriteLine($"The discriminant is greater than zero. The equation has two roots: x_1 = {x_1}, x_2 = {x_2}");
                Console.ReadKey();
            }
        }
    }
}
