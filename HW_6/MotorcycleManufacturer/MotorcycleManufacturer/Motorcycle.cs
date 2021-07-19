using System;

namespace MotorcycleManufacturer
{
    internal class Motorcycle
    {
        public Motorcycle(string model, string manufacturer, int mileage)
        {
            id = Guid.NewGuid();

            Model = model;

            Manufacturer = manufacturer;

            Mileage = mileage;
        }

        private Guid id;
        public Guid Id
        {
            get
            {
                return id;
            }
        }

        private string model;
        public string Model
        {
            set
            {
                while (true)
                {
                    if (value == null)
                    {
                        Console.WriteLine("Please, indicate the motorcycle model");
                        continue;
                    }
                    else
                    {
                        model = value;
                        break;
                    }
                }
            }
            get
            {
                return model;
            }
        }

        string manufacturer;
        public string Manufacturer
        {
            set
            {
                while (true)
                {
                    if (value == null)
                    {
                        Console.WriteLine("Please, indicate the motorcycle manufacturer");
                        continue;
                    }
                    else
                    {
                        manufacturer = value;
                        break;
                    }
                }
            }
            get
            {
                return manufacturer;
            }
        }

        internal int yearOfIssue = DateTime.Now.Year;

        private int mileage;
        public int Mileage
        {
            set
            {
                while (true)
                {
                    if (value > 100)
                    {
                        Console.WriteLine("Mileage should not exceed 100 km. Please, try input again.");
                    }
                    else
                    {
                        mileage = value;
                        break;
                    }
                }
            }
            get
            {
                return mileage;
            }
        }

        private void FactoryReset()
        {
            Console.WriteLine("Settings reseted");
        }
        
        internal class Engine
        {
            public Engine(int engineVolume, int enginePower, EngineType engineType)
            {
                EngineVolume = engineVolume;

                EnginePower = enginePower;

                _engineType = engineType;
            }

            private int engineVolume;

            public int EngineVolume
            {
                set
                {
                    int minEngineVolume = 125;
                    int maxEngineVolume = 3200;

                    while (true)
                    {
                        if (minEngineVolume <= value && value <= maxEngineVolume)
                        {
                            engineVolume = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please, enter the volume from 125 to 3200 cubic centimeters.");
                            continue;
                        }
                    }
                }
                get
                {
                    return engineVolume;
                }
            }

            private int enginePower;
            public int EnginePower
            {
                set
                {
                    int minEnginePower = 50;
                    int maxEnginePower = 300;

                    while (true)
                    {
                        if (minEnginePower <= value && value <= maxEnginePower)
                        {
                            enginePower = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please, enter the power from 50 to 300 horsepower.");
                            continue;
                        }
                    }
                }
                get
                {
                    return enginePower;
                }
            }

            private EngineType engineType;

            public EngineType _engineType
            {
                set
                {
                    int gasType = 1;
                    int electricalType = 2;
                    int hybrideType = 3;

                    while (true)
                    {
                        if (gasType == ((int)value) || ((int)value) == electricalType || ((int)value) == hybrideType)
                        {
                            engineType = value;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Please, enter a number to identify the type of engine (1- gas, 2- electric, 3-hybrid)");
                            continue;
                        }
                    }
                }
                get
                {
                    return engineType;
                }
            }
            public enum EngineType
            {
                Gas = 1,

                Electrical = 2,

                Hybride = 3
            }
        }
    }
}
