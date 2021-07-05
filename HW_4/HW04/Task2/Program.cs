using System;

namespace Task2
{
    class Program
    {
        private static void PrintArray(int[] Array)
        {
            foreach (int item in Array)
            {
                Console.WriteLine(item);
            }
        }

        private static int CheckInput()
        {
            int inputNumber;
            bool checkRes;

            do
            {
                Console.WriteLine("Please, enter integer");

                string strNumber = Console.ReadLine();

                checkRes = int.TryParse(strNumber, out inputNumber);

                if (!checkRes)
                {
                    Console.WriteLine("Incorrect input! Try again.");

                    continue;
                }
            } while (!checkRes);

            return inputNumber;
        }

        static void Main(string[] args)
        {
            int[] inputArray = new int[10];
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                inputArray[i] = CheckInput();
            }

            Console.WriteLine("Output partially filled array.");
            PrintArray(inputArray);

            Console.WriteLine("Please, enter the index where you want to input a new item (dob't forget that indexing in " +
                "CSharp begins from 0)");

            int index;

            while (true)
            {
                index = CheckInput();

                if (index > inputArray.Length - 1)
                {
                    Console.WriteLine("Incorecct input! Index mustn't be greater than array length. Try again.");

                    continue;
                }

                break;
            }
            Console.WriteLine("Please, enter a new item.");

            int item = CheckInput();

            for (int i = inputArray.Length - 1; i > index; i--)
            {
                inputArray[i] = inputArray[i - 1];
            }
            inputArray[index] = item;

            Console.WriteLine("Output altered array.");
            PrintArray(inputArray);

            Console.ReadKey();
        }
    }
}
