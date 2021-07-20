using System;
using System.Collections.Generic;
using System.Linq;

namespace HW08.Task2
{
    static class DataStorage
    {
        internal static Engineer[] mainStaff { get; private set; }

        internal static string[] juniorResponsibilities = new string[5]
            {
                "Participate in expert code and design reviews",
                "Perform unit and integration testing",
                "Participate in assessment and planning sessions",
                "Participate in the development of design and technical and user documentation",
                "Code, debug, document, and maintain pieces of software"
            };

        internal static string[] juniorTechnologies = new string[5]
            {
                "HTML, CSS",
                "C#",
                "Algorithms, data structures",
                "ASP.NET MVC",
                "MS SQL, Entity Framework"
            };

        internal static string[] middleResponsibilities = new string[6]
             {
                 "Creation of API modules. Support for existing API modules",
                 "Maintaining existing and creating processing modules / services",
                "Participation in the improvement of corporate frameworks for internal development",
                 "Checking the code of the work done by the team", "Creation and support of functions, triggers",
                "Building and maintaining unit tests"
             };

        internal static string[] middleTechnologies = new string[6]
            {
                "HTML, CSS",
                "JS, jQuery",
                "C#",
                "Algorithms, data structures",
                "ASP.NET MVC", "MS SQL, Entity Framework"
            };

        internal static string[] seniorResponsibilities = new string[5]
            {
                "Design and development of software applications",
                "Analysis of requirements, collaboration with team members to create thoughtful software projects",
                "Provide accurate estimates for work items",
                "Comply with coding standards and participate in peer code reviews",
                "Evaluate the architecture of the solution in terms of vulnerabilities and potential improvements"
            };

        internal static string[] seniorTechnologies = new string[7]
            {
                "HTML, CSS",
                "JS, jQuery",
                "C#",
                "Algorithms, data structures",
                "ASP.NET MVC", "MS SQL, Entity Framework",
                "Angular / React / Vue.js/ Ember.js"
            };

        internal static string[] teamLeadResponsibilities = new string[6]
            {
                "Participation in writing technical documentation",
                "Selection of technologies for the project, development of architecture",
                "code review",
                "Mentoring for juniors",
            "Conducting technical interviews",
                "Responsibility for the technical part of the project"
            };

        internal static string[] teamLeadTechnologies = new string[8]
            {
                "HTML, CSS",
                "JS, jQuery",
                "C#",
                "Algorithms, data structures",
                "ASP.NET MVC",
                "MS SQL, Entity Framework",
                " Docker", "TypeScript, Razor"
            };

        internal static string[] architectResponsibilities = new string[6]
            {
                "Participation in the assessment of the complexity of projects and the development of a prototype of an architectural solution",
                "Requirements analysis and application architecture design",
            "Development of key functionality",
                "Code Review, Code Refactoring",
                "Engineering Practices Support: Unit Tests, CI",
                "Development and updating of architectural documents"
            };

        internal static string[] architectTechnologies = new string[8]
            {
                "Design Patterns, DI/IoC, SOLID",
                "AJAX, HTML/JavaScript/CSS, JavaScript-Frameworks, React",
                "Micro-services oriented Architecture",
                "Algorithms, data structures",
                "ASP.NET MVC",
                "MS SQL, Entity Framework",
                "Docker", "TypeScript, Razor"
            };

        internal static Engineer[] InitializationStaff()
        {
            mainStaff = new Engineer[13];

            mainStaff[0] = new JuniorDeveloper("Joseph", "Evans", 1, juniorResponsibilities, juniorTechnologies, EnglishLevel.A2, "https://github.com/JosephEvans");
            mainStaff[1] = new JuniorDeveloper("Danny", "Adamson", 1, juniorResponsibilities, juniorTechnologies, EnglishLevel.A2, "https://github.com/DannyAdamson");
            mainStaff[2] = new JuniorDeveloper("Bertie", "Flatcher", 2, juniorResponsibilities, juniorTechnologies, EnglishLevel.B1, "https://github.com/BertieFlatcher");

            mainStaff[3] = new MiddleDeveloper("Dave", "Parson", 2, middleResponsibilities, middleTechnologies, EnglishLevel.B1, "https://github.com/DaveParson");
            mainStaff[4] = new MiddleDeveloper("Samuel", "Walker", 1, middleResponsibilities, middleTechnologies, EnglishLevel.B2, "https://github.com/SamuelWalker");
            mainStaff[5] = new MiddleDeveloper("Jenny", "Brown", 2, middleResponsibilities, middleTechnologies, EnglishLevel.B2, "https://github.com/JennyBrown");

            mainStaff[6] = new SeniorDeveloper("Rosy", "Smith", 3, seniorResponsibilities, seniorTechnologies, EnglishLevel.B2, "https://github.com/RosySmith");
            mainStaff[7] = new SeniorDeveloper("Tom", "Davies", 7, seniorResponsibilities, seniorTechnologies, EnglishLevel.B2, "https://github.com/TomDavies");
            mainStaff[8] = new SeniorDeveloper("Edgar", "Taylor", 4, seniorResponsibilities, seniorTechnologies, EnglishLevel.C1, "https://github.com/EdgarTaylor");

            mainStaff[9] = new TeamLeader("Andrew", "Ellingtonr", 12, teamLeadResponsibilities, teamLeadTechnologies, EnglishLevel.C1, "https://github.com/AndrewEllingtonr");
            mainStaff[10] = new TeamLeader("Barbie ", "Moore", 6, teamLeadResponsibilities, teamLeadTechnologies, EnglishLevel.C1, "https://github.com/BarbieMoore");

            mainStaff[11] = new Architect("Michael", "Jones", 10, architectResponsibilities, architectTechnologies, EnglishLevel.C1, "https://github.com/MichaelJones");
            mainStaff[12] = new Architect("Bill", "White", 7, architectResponsibilities, architectTechnologies, EnglishLevel.C1, "https://github.com/BillWhite");

            return mainStaff;
        }

        internal static List<string> GetResponsibilities(int position)
        {
            List<string> responsibilities = new List<string>();

            switch (position)
            {
                case 1:
                    responsibilities = juniorResponsibilities.ToList();
                    break;
                case 2:
                    responsibilities = middleResponsibilities.ToList();
                    break;
                case 3:
                    responsibilities = seniorResponsibilities.ToList();
                    break;
                case 4:
                    responsibilities = teamLeadResponsibilities.ToList();
                    break;
                case 5:
                    responsibilities = architectResponsibilities.ToList();
                    break;
            }
            return responsibilities;
        }

        internal static void SortStaffList(Engineer[] mainStaff)
        {
            Array.Sort(mainStaff, new ExperienceComparer());
            Array.Reverse(mainStaff);
        }

        internal static string GetEngineerInfo(Engineer engineer)
        {
            string engineerInfo = $"Company: {engineer.Company}," +
                $"full name: {engineer.Name} {engineer.Surname}," +
                $"experience {engineer.Experience}, " +
                $"title {engineer.CurrentPositioin}," +
                $"current salary: {engineer.CurrentSalary}," +
                $"GitHub: {engineer.GitHubLink}";

            return engineerInfo;
        }
    }
}
