using System;

namespace HW08.Task3.Contracts
{
    interface IEngineer
    {
        Guid Id { get; }
        static string Company { get; } = "Microsoft";
        Position CurrentPositioin { get; set; }
        string Name { get; set; }
        string Surname { get; set; }
        int Experience { get; set; }
        string[] Responsibilities { get; set; }
        string[] Technologies { get; set; }
        EnglishLevel englishLevel { get; set; }
        string GitHubLink { get; set; }
        static int BaseSalary { get; set; } = 500;
        int SalaryCoeff { get; set; }
        int CurrentPremium { get; set; }
        int CurrentSalary { get; set; }

        int GetSalary();
    }
}

