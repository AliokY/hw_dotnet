using System;

namespace HW05.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string symbols = Console.ReadLine();

            int operationIndex = 0;

            string firstNumber = null;
            string secondNumber = null;

            for (int i = 0; i < symbols.Length; i++)
            {
                if (symbols[i] == '+' || symbols[i] == '-' || symbols[i] == '*' || symbols[i] == '/')
                {
                    operationIndex = i;
                }

                if (Char.IsNumber(symbols[i]))
                {
                    if (operationIndex == 0 || i < operationIndex)
                    {
                        firstNumber += symbols[i];
                    }
                    else
                    {
                        secondNumber += symbols[i];
                    }
                }
            }

            int number1 = int.Parse(firstNumber);
            int number2 = int.Parse(secondNumber);

            int operationResult = 0;

            switch (symbols[operationIndex])
            {
                case '+':
                    operationResult = number1 + number2;
                    break;

                case '-':
                    operationResult = number1 - number2;
                    break;

                case '*':
                    operationResult = number1 * number2;
                    break;

                case '/':
                    operationResult = number1 / number2;
                    break;
            }
            Console.WriteLine(operationResult);

            Console.ReadKey();
        }
    }
}

