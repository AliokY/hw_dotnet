using HW15.Task1.Models;
using System;
using System.Reflection;

namespace HW15.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            string creditCardNumber1 = "0123 1256 7895 1111";
            string creditCardNumber2 = "5460 1234 5623 2233";
            string creditCardNumber3 = "1as2 1ad1 ewer 7ere";

            bool[] checkingResults = new bool[3]
            {
                CheckCreditCard(creditCardNumber1),
                CheckCreditCard(creditCardNumber2),
                CheckCreditCard(creditCardNumber3)
            };

            foreach (var result in checkingResults)
            {
                if (result)
                { Console.WriteLine("Credit card is accepted"); }
                else
                { Console.WriteLine("Credit card isn't accepted"); }
            }
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
    }
}
