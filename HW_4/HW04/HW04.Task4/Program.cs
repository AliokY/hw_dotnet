using System;

namespace HW04.Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стихотворение в одну строку, разделяя строки точкой с запятой");

            string verse = Console.ReadLine();

            string[] linesVerse = verse.Split(new char[] { ';' });

            for (int i = 0; i < linesVerse.Length; i++)
            {
                linesVerse[i] = linesVerse[i].Replace("о", "а");
                linesVerse[i] = linesVerse[i].Replace("О", "А");
            }
            foreach (string line in linesVerse)
            {
                Console.WriteLine(line);
            }
            Console.ReadKey();
        }
    }
}
