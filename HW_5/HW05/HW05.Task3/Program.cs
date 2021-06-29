using System;
using System.Collections.Generic;

namespace HW05.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] subArray = new string[3] { "arp", "live", "strong" };
            string[] mainArray = new string[5] { "lively", "alive", "harp", "sharp", "armstrong" };

            List<string> answer = new List<string>();

            for (int i = 0; i < mainArray.Length; i++)
            {
                for (int j = 0; j < subArray.Length; j++)
                {
                    if (mainArray[i].Contains(subArray[j], StringComparison.Ordinal) && !answer.Contains(subArray[j]))
                    {
                        answer.Add(subArray[j]);
                    }
                }
            }
            string[] answerArray = answer.ToArray();
            Array.Sort(answerArray);

            foreach (string item in answerArray)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
