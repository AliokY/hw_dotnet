using System;

namespace HW03.Operators
{
    class Program
    {
        private static void GetTwoIntegers(out int num1, out int num2)
        {
            while (true)
            {
                Console.WriteLine("Please, enter the first integer");
                string strNum1 = Console.ReadLine();
                Console.WriteLine("Please, enter the second integer");
                string strNum2 = Console.ReadLine();

                bool res1 = int.TryParse(strNum1, out num1);
                bool res2 = int.TryParse(strNum2, out num2);

                if (res1 && res2)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input. Please, try again!");
                    continue;
                }
            }
        }

        private static void CheckTheAnswer(int operationResult, out int sumInput)
        {
            bool res3;

            do
            {
                Console.WriteLine("Please, enter the sum of these integers");
                string strSum = Console.ReadLine();

                res3 = int.TryParse(strSum, out sumInput);

                if (res3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect input (You must enter an integer). Please, try again!");
                }
            } while (!res3);

            string right = "Your answer is correct!";
            string wrong = "Your answer is wrong!";

            string answer = operationResult == sumInput ? right : wrong;

            Console.WriteLine(answer);
            Console.WriteLine("Press any key to get more information or exit");
            Console.ReadLine();
        }

        private static void CompareTheAnswer(int sumInput, int operationResult)
        {
            if (sumInput != operationResult)
            {
                string more = "The result must be greater!";
                string less = "The result must be less";

                string wrongAnswer = sumInput > operationResult ? less : more;

                Console.WriteLine(wrongAnswer);
                Console.ReadLine();
            }
        }

        private static int GetOperationResult(int num1, int num2, char operation)
        {
            int operationResult = operation == '+' ? (num1 + num2) : (num1 - num2);

            return operationResult;
        }

        private static char DefineThetypeOfOperation()
        {
            Console.WriteLine("Please, input \"-\" or \"+\" to define the type of operation:");

            char operation;

            string operationInput;

            while (true)
            {
                operationInput = Console.ReadLine();

                bool result = char.TryParse(operationInput, out operation);

                if (!result)
                {
                    Console.WriteLine("Incorerrest input! Enter one symbol!");
                    continue;
                }
                if (operation != '+' && operation != '-')
                {
                    Console.WriteLine("Incorerrest input! Enter \"-\" or \"+\"!");
                    continue;
                }
                else
                {
                    break;
                }
            }
            return operation;
        }

        private static void Task1()
        {
            GetTwoIntegers(out int num1, out int num2);
            char operation = '+';
            int operationResult = GetOperationResult(num1, num2, operation);

            Console.Write("The sum is ");
            Console.WriteLine(operationResult);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }

        private static void Task2()
        {
            GetTwoIntegers(out int num1, out int num2);

            char operation = '+';

            int operationResult = GetOperationResult(num1, num2, operation);

            CheckTheAnswer(operationResult, out int sumInput);
        }

        private static void Task3()
        {
            GetTwoIntegers(out int num1, out int num2);

            char operation = '+';

            int operationResult = GetOperationResult(num1, num2, operation);

            CheckTheAnswer(operationResult, out int sumInput);

            CompareTheAnswer(sumInput, operationResult);
        }

        private static void Task4()
        {
            GetTwoIntegers(out int num1, out int num2);

            char operation = DefineThetypeOfOperation();

            int operationResult = GetOperationResult(num1, num2, operation);

            CheckTheAnswer(operationResult, out int sumInput);

            CompareTheAnswer(sumInput, operationResult);
        }

        static void Main(string[] args)
        {
            // To complete each task, you need to remove the comment from the corresponding method, and comment out the rest

            //Task1();

            //Task2();

            //Task3();

            Task4();
        }
    }
}
