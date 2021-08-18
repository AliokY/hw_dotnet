using HW15.Task3.Models;
using System;
using System.Reflection;

namespace HW15.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            //string creditCardNumber1 = "0123 1256 7895 1111";
            //string creditCardNumber2 = "5460 1234 5623 2233";
            //string creditCardNumber3 = "1as2 1ad1 ewer 7ere";

            //bool[] checkingResults = new bool[3]
            //{
            //    CheckCreditCard(creditCardNumber1),
            //    CheckCreditCard(creditCardNumber2),
            //    CheckCreditCard(creditCardNumber3)
            //};

            //foreach (var result in checkingResults)
            //{
            //    if (result)
            //    { Console.WriteLine("Credit card is accepted"); }
            //    else
            //    { Console.WriteLine("Credit card isn't accepted"); }
            //}

            ChangeConst();

            Console.ReadKey();
        }
        static bool CheckCreditCard(string creditCardNumber)
        {
            PurchaseMotorcycle moto = new PurchaseMotorcycle("Yamaha", 12_300, 7500, creditCardNumber);

            Type motoType = moto.GetType();

            foreach (PropertyInfo pi in motoType.GetProperties())
            {
                foreach (Attribute attribute in pi.GetCustomAttributes())
                {
                    CreditCardAttribute creditCardAttribute = attribute as CreditCardAttribute;

                    if (creditCardAttribute != null)
                    {
                        if (!creditCardAttribute.IsValid(moto.CreditCardNumber))
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        //static void ChangeAttribute()
        //{
        //    PurchaseMotorcycle moto = new PurchaseMotorcycle("Minsk X250", 12_300, 7500, "5460 1234 5623 2233");

        //    Type motoType = moto.GetType();

        //    var methods = motoType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

        //    foreach (MethodInfo mi in methods)
        //    {
        //        foreach (Attribute attribute in mi.GetCustomAttributes())
        //        {
        //            ObsoleteAttribute obsoleteAttribute = attribute as ObsoleteAttribute;

        //            if (obsoleteAttribute != null)
        //            {
        //                //obsoleteAttribute.Message = "Soon this method will NOT be removed!";
        //            }
        //        }
        //    }
        //}

        static void ChangeConst()
        {
            PurchaseMotorcycle moto = new PurchaseMotorcycle("Minsk X250", 12_300, 7500, "5460 1234 5623 2233");

            Type motoType = moto.GetType();

            var fields = motoType.GetFields();

            foreach (FieldInfo fieldInfo in fields)
            {
                if (fieldInfo.Name == "numberOfWheel")
                {
                    var value = fieldInfo.GetValue(moto);
                    Console.WriteLine($"Before: {value}");

                    fieldInfo.SetValue(moto, 3);

                    value = fieldInfo.GetValue(moto);
                    Console.WriteLine($"After: {value}");
                }
            }
        }
    }
}
