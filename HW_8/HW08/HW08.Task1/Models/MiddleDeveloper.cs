using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW08.Task1
{
    class MiddleDeveloper : Engineer
    {
        private const int SalaryCoeff = 3;

        private int _currentSalary;
        public override int CurrentSalary
        {
            get
            {
                return _currentSalary;
            }
            set
            {
                if (BaseSalary * SalaryCoeff <= value)
                {
                    _currentSalary = value;
                }
            }
        }
        
        public MiddleDeveloper(string name, string surname, int experience, string[] responsibilities, string[] technologies, string gitHubLink) : 
            base(name, surname, experience, responsibilities, technologies, gitHubLink)
        {
            CurrentSalary = BaseSalary * SalaryCoeff;
        }

        public override void GetSalary()
        {
            Console.WriteLine($"Current salary - {CurrentSalary}$");
        }
    }
}
