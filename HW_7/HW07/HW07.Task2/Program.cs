using System;

namespace HW07.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            int area = 0;

            SmallApartment myFirtApartment = new(area);

            Person firstPerson = new("Andrew", myFirtApartment);

            firstPerson.ShowData();
        }
    }
}
