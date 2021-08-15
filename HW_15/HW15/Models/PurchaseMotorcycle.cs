using System;

namespace HW15.Task1.Models
{
    class PurchaseMotorcycle 
    {
        public string Model { get; set; }
        public int Odometer { get; set; }
        public int Price { get; set; }
        [CreditCard]
        public string CreditCardNumber { get; set; }

        public PurchaseMotorcycle(string model, int odometer, int price, string creditCardNumber)
        {
            Model = model;
            Odometer = odometer;
            Price = price;
            CreditCardNumber = creditCardNumber;
        }
    }
}
