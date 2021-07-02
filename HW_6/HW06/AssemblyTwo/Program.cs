// подключаем простанство имён AssemblyOne соответствующей сборки для доступа к её(сборки) классам
using AssemblyOne;
using System;

namespace AssemblyTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            // создаём экземпляр класса Motorcycle
            Motorcycle moto1 = new Motorcycle();

            // метод имеет модификатор доступа protected internal (доступ ограничен текущей сборкой-проектом или производным классом)
            // попытка вызова из другой сборки - ошибка компиляции
            //moto1.DriveAroundCity();

            // публичное свойство (доступ из любой сборки и любого места в коде) приватного поля price, свойсто имеет только блок set,
            // позволяющий присваивать значение
            moto1.Price = 15000;

            // вышеописанное свойство не имеет блока get, позволяющего получить значение поля, соответственно компилятор авдаёт ошибку
            //Console.WriteLine(moto1.Price);

            // попытка обращение к полю с модификатором доступа private (доступ только из класса-объявителя), компилятор выдаёт ошибку
            //Console.WriteLine(moto1.registrationNumber);

            // обращение к вышеуказанному полю через public свойство, имеющее блок get(позволяет получить значение приватного поля)
            Console.WriteLine(moto1.RegistrationNumber);
            Console.ReadKey();
            Console.WriteLine();

            // установка нового значения полю registrationNumber через public(открытый доступ) свойство с блоком set
            moto1.RegistrationNumber = "2348-NA3";
            // вывод значения поля после перезаписи (ддоступен благодаря блоку get свойства)
            Console.WriteLine(moto1.RegistrationNumber);
            Console.ReadKey();

            // поле имеет модификатор доступа private protected, доступно в классе-объявителе свойства и в его
            // производных классах (в рамках одной сборки), код не компилируется
            //Console.WriteLine(moto1.Model);

            // константы, вызываются только через название класса, вызов с объекта - ошибка
            // поле EngineVolume - модификатор доступа public
            Console.WriteLine(Motorcycle.EngineVolume);
            // поле EnginePower - модификатор доступа internal (доступ только в рамках одной сборки!) код ниже не компилируется
            //Console.WriteLine(Motorcycle.EnginePower);

            // модификатор доступа метода protected, доступ из класса-объявителя либо производных классов не зависимо от
            // сборки(в случае ниже - ошибка)
            //moto1.PreparingForRide();

            // доступ из класса-объявителя либо производных классов в рамках одной сборки, модификатор - private protected
            //moto1.DriveOnHighway();

            // класс с модификатором доступа internal, доступ в рамках одной сборки, 4 строки кода ниже - ошибка компиляции
            //Cruiser moto2 = new Cruiser();
            //moto2.DriveAroundCity();
            //moto2.Model = "Multistrada 950 S";
            //Console.WriteLine(moto2.RegistrationNumber);

            // создаём экземпляр класса Touring (наследник от  Motorcycle)
            Motorcycle moto3 = new Touring();
            // установка нового значения полю registrationNumber через public(открытый доступ) свойство с блоком set
            moto3.RegistrationNumber = "A-258-HT5";
        }
    }
}
