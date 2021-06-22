using System;

namespace HW03.Calculator
{
    class Calculator
    {
        internal int AddNumbers(int num1, int num2)
        {
            int result = num1 + num2;

            return result;
        }
        internal int SubtractNumber(int num1, int num2)
        {
            int result = num1 - num2;

            return result;
        }
        internal int MultiplyNumber(int num1, int num2)
        {
            int result = num1 * num2;

            return result;
        }
        internal int DivideByNumber(int num1, int num2)
        {
            int result = num1 / num2;

            return result;
        }
        internal int CalculateRemainderOfDivision(int num1, int num2)
        {
            int result = num1 % num2;

            return result;
        }
        internal double CalculateCircleArea(double rad)
        {
            double circleArea = Math.PI * Math.Pow(rad, 2);

            return circleArea;
        }
    }
}
