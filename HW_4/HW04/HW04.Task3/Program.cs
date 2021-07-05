using System;
using System.Diagnostics;

namespace HW04.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            long[] randomArray = new long[100_000_000];
            for (int i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next();
            }

            Stopwatch sw = new Stopwatch();
            sw.Start();
            int k = 1;
            long temp;
            for (int i = 0; i < randomArray.Length / 2; i++)
            {
                {
                    temp = randomArray[i];

                    randomArray[i] = randomArray[randomArray.Length - k];

                    randomArray[randomArray.Length - k] = temp;

                    k++;
                }
            }

            sw.Stop();
            Console.Write("Runtime of my reverse method: ");
            Console.WriteLine(sw.Elapsed.TotalMilliseconds + " ms");

            sw.Start();
            Array.Reverse(randomArray);
            sw.Stop();
            Console.Write("Runtime of Array.Reverse method: ");
            Console.WriteLine(sw.Elapsed.TotalMilliseconds + " ms");

            Console.ReadKey();
        }
    }
}
