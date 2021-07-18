using System;

namespace HW08.Task1
{
    class Engineer
    {
        public Guid Id { get; }
        public string Company { get; } = "Microsoft";
        public virtual Position CurrentPositioin { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public string[] Responsibilities { get; set; }
        public string[] Technologies { get; set; }
        public virtual EnglishLevel englishLevel { get; set; }
        public string GitHubLink { get; set; }
        public int BaseSalary { get; set; } = 500;
        public virtual int SalaryCoeff { get; set; }
        public virtual int CurrentPremium { get; set; }
        public virtual int CurrentSalary { get; set; }
        public static object EnglishLevel { get; internal set; }

        public virtual int GetSalary() 
        {
            return CurrentSalary;
        }

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
