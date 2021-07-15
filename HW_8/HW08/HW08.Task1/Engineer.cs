using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW08.Task1
{
    class Engineer
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Experience { get; set; }
        public string[] Responsibilities { get; set; }
        public string[] Technologies { get; set; }
        public string GitHubLink { get; set; }
        public int BaseSalary { get; set; }
        public virtual int CurrentSalary { get; set; }

        public virtual void GetSalary() { }

        public Engineer(string name, string surname, int experience, string[] responsibilities, string[] technologies, string gitHubLink)
        {
            Id = Guid.NewGuid();

            BaseSalary = 500;

            Name = name;
            Surname = surname;
            Experience = experience;
            Responsibilities = responsibilities;
            Technologies = technologies;
            GitHubLink = gitHubLink;
        }
    }
}
