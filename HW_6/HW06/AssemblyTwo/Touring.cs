using AssemblyOne;

namespace AssemblyTwo
{
    class Touring : Motorcycle
    {
        static void Main()
        {
            var moto4 = new Touring();
            // модификатор доступа метода protected, доступ из класса-объявителя либо производных классов не зависимо от
            // сборки(в случае ниже - вызов из иной сборки)
            moto4.PreparingForRide();
        }
    }
}
