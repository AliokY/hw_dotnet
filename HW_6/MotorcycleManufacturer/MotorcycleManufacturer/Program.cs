using System;

namespace MotorcycleManufacturer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please, enter the characteristics of the first motorcycle model");

            string[] motoCharacteristics = IndicateMotoCharacteristics();

            string model = motoCharacteristics[0];
            string manufacturer = motoCharacteristics[1];
            int mileage = int.Parse(motoCharacteristics[2]);
            int engineVolume = int.Parse(motoCharacteristics[3]);
            int enginePower = int.Parse(motoCharacteristics[4]);

            Motorcycle model1 = new(model, manufacturer, mileage);
            Motorcycle.Engine engineModel1 = new(engineVolume, enginePower, Motorcycle.Engine.EngineType.Gas);

            Console.WriteLine("Please, enter the characteristics of the second motorcycle model");
            motoCharacteristics = IndicateMotoCharacteristics();

            Motorcycle model2 = new(model, manufacturer, mileage);
            Motorcycle.Engine engineModel2 = new(engineVolume, enginePower, Motorcycle.Engine.EngineType.Electrical);

            Console.WriteLine("Please, enter the characteristics of the third motorcycle model");
            motoCharacteristics = IndicateMotoCharacteristics();

            Motorcycle model3 = new(model, manufacturer, mileage);
            Motorcycle.Engine engineModel3 = new(engineVolume, enginePower, Motorcycle.Engine.EngineType.Hybride);

            Motorcycle[] motoModelRange = new Motorcycle[3];
            motoModelRange[0] = model1;
            motoModelRange[1] = model2;
            motoModelRange[2] = model3;

            Motorcycle.Engine[] motoEngineModelRange = new Motorcycle.Engine[3];
            motoEngineModelRange[0] = engineModel1;
            motoEngineModelRange[1] = engineModel2;
            motoEngineModelRange[2] = engineModel3;

            string motoModelCharacteristics;

            for (int i = 0; i < motoModelRange.Length; i++)
            {
                motoModelCharacteristics = $"Motorcycle(manufacturer):{motoModelRange[i].Manufacturer}. Model:" +
                    $"{motoModelRange[i].Model}.Vin Number(id):{motoModelRange[i].Id}. Year of issue:{motoModelRange[0].yearOfIssue}." +
                    $"Engine: volume - {motoEngineModelRange[i].EngineVolume} cm3, power - {motoEngineModelRange[i].EnginePower} hp," +
                    $"type - {motoEngineModelRange[i]._engineType}.";

                Console.WriteLine($"Main characteristics of model{i + 1}");

                Console.WriteLine(motoModelCharacteristics);
            }

            Console.ReadKey();
        }
        internal static string[] IndicateMotoCharacteristics()
        {
            string[] motoCharacteristics = new string[5];

            Console.WriteLine("Please, enter the motorcycle model");
            motoCharacteristics[0] = Console.ReadLine();

            Console.WriteLine("Please, enter the motorcycle manufacturer");
            motoCharacteristics[1] = Console.ReadLine();

            Console.WriteLine("Please, enter the motorcycle mileage");
            motoCharacteristics[2] = Console.ReadLine();

            Console.WriteLine("Please, enter the motorcycle engine volume");
            motoCharacteristics[3] = Console.ReadLine();

            Console.WriteLine("Please, enter the motorcycle engine power");
            motoCharacteristics[4] = Console.ReadLine();

            return motoCharacteristics;
        }
    }
}
