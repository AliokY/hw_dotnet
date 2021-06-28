using System;

namespace HW03.Alphabet
{
    class Program
    {
        int decEncodingLowercaseA = 97;
        int decEncodingLowercaseZ = 122;

        static void Main(string[] args)
        {
            for (int i = decEncodingLowercaseZ; decEncodingLowercaseA <= i; i--)
            {
                Console.Write(Convert.ToChar(i) + " ");
            }
            Console.ReadKey();
        }
    }
}
