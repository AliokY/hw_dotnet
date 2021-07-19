using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW07.Task2
{
    class House
    {
        private int _area;

        internal int area
        {
            set
            {
                _area = value;
            }
            get
            {
                return _area;
            }
        }
        internal House(int area)
        {
            this.area = area;
        }

        internal void ShowData()
        {
            Console.WriteLine($"I'm a house, my area is {_area} m2.");
        }

        internal void GetDoor(Door newDoor)
        {
            Console.WriteLine($"I'm a dooor, my color is {newDoor.color} m2.");
        }

        internal class Door
        {
            internal string color { get; set; }

            internal void ShowData()
            {
                Console.WriteLine($"I'm a dooor, my color is {color} m2.");
            }
        }
    }
}
