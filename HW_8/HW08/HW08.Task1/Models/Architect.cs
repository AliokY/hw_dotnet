﻿namespace HW08.Task1
{
    class Architect : Engineer
    {
        public override Position CurrentPositioin { get; set; } = Position.Architect;

        public override int SalaryCoeff { get; set; } = 12;

        public override int CurrentPremium { get; set; } = 1000;

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
        private EnglishLevel _englishLevel;
        public override EnglishLevel englishLevel
        {
            get
            {
                return _englishLevel;
            }
            set
            {
                if (Task1.EnglishLevel.C1 == value)
                {
                    _englishLevel = value;
                }
            }
        }

        public Architect(string name, string surname, int experience, string[] responsibilities, string[] technologies, EnglishLevel englishLevel, string gitHubLink) :
            base(name, surname, experience, responsibilities, technologies, englishLevel, gitHubLink)
        {
            CurrentSalary = BaseSalary * SalaryCoeff + CurrentPremium;
        }

        public override int GetSalary()
        {
            return CurrentSalary;
        }
    }
}
