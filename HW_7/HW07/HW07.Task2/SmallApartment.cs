using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW07.Task2
{
    class SmallApartment : House
    {
        public Door firstDoor { get; set; }
        internal SmallApartment(int area) : base(area)
        {
            this.area = 50;

            firstDoor = new();

            Console.WriteLine("Enter the color of the door:");
            firstDoor.color = Console.ReadLine();
        }
    }
}
