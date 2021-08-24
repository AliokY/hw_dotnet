﻿using HW08.Task3.Contracts;
using System;

namespace HW08.Task3
{
    class SeniorDeveloper : IEngineer
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public string[] Responsibilities { get; set; }
        public string[] Technologies { get; set; }
        public string GitHubLink { get; set; }
        public Position CurrentPositioin { get; set; } = Position.SeniorDeveloper;
        static int BaseSalary { get; set; } = 500;
        public int SalaryCoeff { get; set; } = 5;
        public int CurrentPremium { get; set; } = 300;

        private int _currentSalary;
        public int CurrentSalary
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
        public EnglishLevel englishLevel
        {
            get
            {
                return _englishLevel;
            }
            set
            {
                if (Task3.EnglishLevel.B2 <= value)
                {
                    _englishLevel = value;
                }
            }
        }

        public SeniorDeveloper(string name, string surname, int experience, string[] responsibilities, string[] technologies, EnglishLevel englishLevel, string gitHubLink)
        {
            Id = Guid.NewGuid();

            Name = name;
            Surname = surname;
            Experience = experience;
            Responsibilities = responsibilities;
            Technologies = technologies;
            this.englishLevel = englishLevel;
            GitHubLink = gitHubLink;
            CurrentSalary = BaseSalary * SalaryCoeff + CurrentPremium;
        }

        public int GetSalary()
        {
            return CurrentSalary;
        }
    }
}
