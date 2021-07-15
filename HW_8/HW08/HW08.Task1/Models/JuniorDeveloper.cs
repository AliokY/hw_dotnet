using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW08.Task1
{
    class JuniorDeveloper : Engineer
    {
        private int _currentSalary;
        public override int CurrentSalary
        {
            get
            {
                return _currentSalary;
            }
            set
            {
                if (value == BaseSalary)
                {
                    _currentSalary = value;
                }
            }
        }
        public JuniorDeveloper(string name, string surname, int experience, string[] responsibilities, string[] technologies, string gitHubLink) : 
            base(name, surname, experience, responsibilities, technologies, gitHubLink)
        {
            CurrentSalary = BaseSalary;
        }

        public override void GetSalary()
        {
            Console.WriteLine($"Current salary - {CurrentSalary}$");
        }
    }
}
