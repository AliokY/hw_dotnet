﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW08.Task1
{
    class Arhitect : Engineer
    {
        private const int SalaryCoeff = 12;
        private const int CurrentPremium = 1000;

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

        public Arhitect(string name, string surname, int experience, string[] responsibilities, string[] technologies, string gitHubLink) :
            base(name, surname, experience, responsibilities, technologies, gitHubLink)
        {
            CurrentSalary = BaseSalary * SalaryCoeff + CurrentPremium;
        }

        public override void GetSalary()
        {
            Console.WriteLine($"Current salary - {CurrentSalary}$");
        }
    }
}

