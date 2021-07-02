using System;

namespace AssemblyOne
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём экземпляр класса Motorcycle
            Motorcycle moto1 = new Motorcycle();

            // метод имеет модификатор доступа protected internal (доступ ограничен текущей сборкой-проектом или производным классом)
            moto1.DriveAroundCity();

            // публичное свойство приватного поля price, свойсто имеет только блок set, позволяющий присваивать значение
            moto1.Price = 15000;

            // вышеописанное свойство не имеет блока get, позволяющего получить значение поля, соответственно компилятор авдаёт ошибку
            //Console.WriteLine(moto1.Price);

            // попытка обращение к полю с модификатором доступа private, компилятор выдаёт ошибку
            //Console.WriteLine(moto1.registrationNumber);

            // обращение к вышеуказанному полю через свойство, имеющее блок get(позволяет получить значение приватного поля)
            Console.WriteLine(moto1.RegistrationNumber);
            Console.ReadKey();
            Console.WriteLine();

            // установка нового значения полю registrationNumber через свойство с блоком set
            moto1.RegistrationNumber = "2348-NA3";
            Console.WriteLine(moto1.RegistrationNumber);
            Console.ReadKey();

            // поле имеет модификатор доступа private protected, доступно в классе-объявителе свойства и в его
            // производных классах (в рамках одной сборки), код не компилируется
            //Console.WriteLine(moto1.Model);

            // константы, вызываются только через название класса, вызов с объекта - ошибка
            Console.WriteLine(Motorcycle.EngineVolume);
            Console.WriteLine(Motorcycle.EnginePower);

            // модификатор доступа метода protected, доступ из класса-объявителя либо производных классов не зависимо от сборки(в случае ниже - ошибка) 
            //moto1.PreparingForRide();

            // доступ из класса-объявителя либо производных классов в рамках одной сборки, модификатор - private protected 
            //moto1.DriveOnHighway();

            // создание эклемпляра класса Cruiser
            Cruiser moto2 = new Cruiser();

            // класс - производный от класса-объявителя метода, модификатор - protected internal, код компилируется
            moto2.DriveAroundCity();

            // поле private protected, доступ только из класса-объявителя и наследников в одной сборке, ошибка
            //moto2.Model = "Multistrada 950 S";

            // обращение к полю через свойство, имеющее блок get
            Console.WriteLine(moto2.RegistrationNumber);
        }
    }
}
