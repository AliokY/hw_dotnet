using System;
using System.Collections.Generic;

namespace HW08.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // add (initialize) personnel to an array (database)
            Engineer[] mainStaff = DataStorage.InitializationStaff();

            // sort all employees by work experience (from more experienced to less experienced)
            DataStorage.SortStaffList(mainStaff);

            // display the salary of the specified engineer
            Console.WriteLine($"Current salary is {mainStaff[5].GetSalary()}");
            Console.WriteLine(new string('!', 120));

            Console.WriteLine("Please enter a number between zero to four to obtain the responsibilities of the respective engineer:" +
                 "JuniorDeveloper-0, MiddleDeveloper-1, SeniorDeveloper-2, TeamLeader-3, Architect-4");

            int position = int.Parse(Console.ReadLine());

            // display the responsibilities of the specified engineer
            List<string> responsibilities = DataStorage.GetResponsibilities(position);
            Console.WriteLine($"Responsibilities of a {((Position)position).ToString()} include:");
            foreach (var item in responsibilities)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(new string('!', 120));

            // display all engineers list
            Console.WriteLine("List of all current staff:");
            string engineerInfo;
            foreach (var engineer in mainStaff)
            {
                engineerInfo = DataStorage.GetEngineerInfo(engineer);
                Console.WriteLine(engineerInfo);
                Console.WriteLine(new string('-', 120));
            }

            Console.ReadKey();
        }
    }
}
