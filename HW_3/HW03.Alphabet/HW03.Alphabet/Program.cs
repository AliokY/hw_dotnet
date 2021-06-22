using System;

namespace HW03.Alphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            for (int i = 122; 97 <= i; i--)
            {
                Console.Write(Convert.ToChar(i) + " ");
            }
            Console.ReadKey();
        }
    }
}
