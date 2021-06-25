using System;

namespace HW04.Task1
{
    class Program
    {
        private static void PrintArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.WriteLine(item);
            }
        }

        static void Main(string[] args)
        {
            int[] randomArray = new int[10];
            Random random = new Random();
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(100);
            }

            int[] inputArray = new int[10];
            int inputNumber;
            bool checkRes;
            for (int i = 0; i < inputArray.Length; i++)
            {
                do
                {
                    Console.WriteLine("Please, enter the integer from 0 to 100");
                    string inpStr = Console.ReadLine();
                    checkRes = int.TryParse(inpStr, out inputNumber);
                    if (inputNumber > 100 || 0 > inputNumber || !checkRes)
                    {
                        Console.WriteLine("Incorrect input! Try again, please.");

                        continue;
                    }
                } while (!checkRes);

                inputArray[i] = inputNumber;
            }

            int[] resultArray = new int[10];
            for (int i = 0; i < resultArray.Length; i++)
            {
                resultArray[i] = inputArray[i] + randomArray[i];
            }

            Console.WriteLine("Output randomArray");
            PrintArray(randomArray);

            Console.WriteLine("Output inputArray");
            PrintArray(inputArray);

            Console.WriteLine("Output resultArray");
            PrintArray(resultArray);

            Console.ReadKey();
        }
    }
}
