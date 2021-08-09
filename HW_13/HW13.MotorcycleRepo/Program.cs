using HW02.MotorcycleRepo.Models;
using System;
using System.Collections.Generic;

namespace HW02.MotorcycleRepo
{
    class Program
    {
        static void Main(string[] args)
        {
            var staticRepo = new GenericRepository<Motorcycle>();

            Console.WriteLine("Implement Create method");
            staticRepo.Create(new Motorcycle("Suzuki", "SV1000", 2003, 46_000));
            staticRepo.Create(new Motorcycle("YCF", "Bigy 125MX", 2020, 120));
            staticRepo.Create(new Motorcycle("Yamaha", "XV1700", 2006, 59_546));
            staticRepo.Create(new Motorcycle("Honda", "CB650R", 2019, 900));
            staticRepo.Create(new Motorcycle("Honda", "CMX", 2019, 166));
            staticRepo.Create(new Motorcycle("BMW", "F800S", 2009, 34_208));

            Motorcycle testMoto = staticRepo.GetAll()[1];

            Console.WriteLine("Implement GetAll method");
            IList<Motorcycle> motorcyclesList = staticRepo.GetAll();
            ShowMotorcyclesInfo(motorcyclesList);
            Console.WriteLine(new string('#', 100));

            Console.WriteLine("implrmrnt GetById method");
            Motorcycle currentMoto = staticRepo.GetById(testMoto.Id);
            Console.WriteLine(currentMoto.ToString());
            Console.WriteLine(new string('#', 100));

            Console.WriteLine("Implement Delete method");
            staticRepo.Delete(testMoto.Id);
            motorcyclesList = staticRepo.GetAll();
            ShowMotorcyclesInfo(motorcyclesList);
            Console.WriteLine(new string('#', 100));

            currentMoto = staticRepo.GetAll()[0];
            currentMoto.Odometer = 64_212;
            Console.WriteLine("Implement Update method");
            staticRepo.Update(currentMoto);

            motorcyclesList = staticRepo.GetAll();
            ShowMotorcyclesInfo(motorcyclesList);

            Console.ReadLine();
        }

        private static void ShowMotorcyclesInfo(IList<Motorcycle> motorcyclesList)
        {
            foreach (var motorcycle in motorcyclesList)
            {
                Console.WriteLine(motorcycle.ToString());
            }
        }
    }
}
