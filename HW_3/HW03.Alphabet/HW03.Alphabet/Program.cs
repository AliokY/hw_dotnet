using System;

namespace HW03.Alphabet
{
    class Program
    {
        static void Main(string[] args)
        {
            int decEncodingLowercaseA = 97;
            int decEncodingLowercaseZ = 122;

            for (int i = decEncodingLowercaseZ; decEncodingLowercaseA <= i; i--)
            {
                Console.Write(Convert.ToChar(i) + " ");
            }
            Console.ReadKey();
        }
    }
}
