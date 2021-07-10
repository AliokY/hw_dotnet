using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW07.Task2
{
    class Person
    {
        public string name { set; get; }

        public SmallApartment myApartment { get; set; }

        public Person(string name, SmallApartment newAppartment)
        {
            this.name = name;

            myApartment = newAppartment;
        }

        internal void ShowData()
        {
            Console.WriteLine($"Person name is {name}, area of his apartment is {myApartment.area}," +
                $"the door is {myApartment.firstDoor.color} ");
            Console.ReadKey();
        }
    }
}
