using System;

namespace HW03.Birthday
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the date of birth in the format: yyyy-mm-dd");
            string bornDateInp = Console.ReadLine();

            Console.WriteLine("Please, enter current date in the format: yyyy-mm-dd");
            string currentDateInp = Console.ReadLine();

            DateTime bornDate = DateTime.Parse(bornDateInp);
            DateTime currentDate = DateTime.Parse(currentDateInp);

            DateTime span = new DateTime((currentDate - bornDate).Ticks);

            int age = bornDate.Month == currentDate.Month ? (span.Year) : (span.Year - 1);

            Console.WriteLine(age);
            Console.ReadKey();
        }
    }
}
