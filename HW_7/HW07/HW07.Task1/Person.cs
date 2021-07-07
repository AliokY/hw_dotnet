using System;

namespace HW07.Task1
{
    class Person
    {
        private int personAge;

        internal int PersonAge
        {
            get
            {
                return personAge;
            }
            set
            {
                while (true)
                {
                    if (value < 60 && value > 15)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Incorrect input!");
                        break;
                    }
                }
                personAge = value;
            }
        }

        internal void SayHello()
        {
            Console.WriteLine("Hello, guys!");
            Console.ReadKey();
        }

        internal void SetAge(int age)
        {
            PersonAge = age;
            Console.WriteLine($"I'm {PersonAge} years old.");
        }
    }
}
