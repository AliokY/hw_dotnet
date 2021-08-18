using System;

namespace HW15.Task3.Models
{
    class PurchaseMotorcycle
    {
        public string Model { get; set; }
        public int Odometer { get; set; }
        public int Price { get; set; }
        [CreditCard]
        public string CreditCardNumber { get; set; }

        public const int numberOfWheel = 2;

        public PurchaseMotorcycle(string model, int odometer, int price, string creditCardNumber)
        {
            Model = model;
            Odometer = odometer;
            Price = price;
            CreditCardNumber = creditCardNumber;
        }

        [Obsolete("Soon this method will be removed!")]
        private int GetMileage()
        {
            return Odometer;
        }
    }
}
