using System;

namespace HW03.Movement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter W, S, A, D to move to the corresponding side");
            string button = Console.ReadLine().ToUpper();
            switch (button)
            {
                case "W":
                    Console.WriteLine("Move up");
                    break;
                case "S":
                    Console.WriteLine("Move down");
                    break;
                case "A":
                    Console.WriteLine("Move left");
                    break;
                case "D":
                    Console.WriteLine("Move right");
                    break;
                default:
                    Console.WriteLine("Movement is not required!");
                    break;
            }
            Console.ReadKey();
        }
    }
}
