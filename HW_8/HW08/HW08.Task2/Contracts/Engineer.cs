using System;

namespace HW08.Task2
{
    abstract class Engineer
    {
        public Guid Id { get; }
        public string Company { get; } = "Microsoft";
        public abstract Position CurrentPositioin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public string[] Responsibilities { get; set; }
        public string[] Technologies { get; set; }
        public abstract EnglishLevel englishLevel { get; set; }
        public string GitHubLink { get; set; }
        public int BaseSalary { get; set; } = 500;
        public abstract int SalaryCoeff { get; set; }
        public abstract int CurrentPremium { get; set; }
        public abstract int CurrentSalary { get; set; }
        public static object EnglishLevel { get; internal set; }

        public abstract int GetSalary();

        public Engineer(string name, string surname, int experience, string[] responsibilities, string[] technologies,
            EnglishLevel englishLevel, string gitHubLink)
        {
            Id = Guid.NewGuid();

            Name = name;
            Surname = surname;
            Experience = experience;
            Responsibilities = responsibilities;
            Technologies = technologies;
            this.englishLevel = englishLevel;
            GitHubLink = gitHubLink;
        }
    }
}
