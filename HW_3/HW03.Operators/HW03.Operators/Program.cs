using System;

namespace HW03.Operators
{
    class Program
    {
        private static int Sum1()
        {
            int num1, num2;

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
            int sum = num1 + num2;

            return sum;
        }

        private static void Sum2(out int sumInput, out int sum)
        {
            sum = Sum1();

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

            string answer = sum == sumInput ? right : wrong;

            Console.WriteLine(answer);
            Console.WriteLine("Press any key to see more information or exit");
            Console.ReadLine();
        }

        private static void Sum3()
        {
            Sum2(out int sumInput, out int sum);

            if (sumInput != sum)
            {
                string more = "The result must be greater!";
                string less = "The result must be less";

                string wrongAnswer = sumInput > sum ? less : more;

                Console.WriteLine(wrongAnswer);
                Console.ReadLine();
            }
        }

        static void Main(string[] args)
        {
            // Calling the first method
            //int sum = Sum1();
            //Console.Write("The sum is ");
            //Console.WriteLine(sum);
            //Console.ReadKey();

            // Calling the second method
            //Sum2(out int sumInput, out int sum);

            // Calling the third method
            Sum3();
        }
    }
}
