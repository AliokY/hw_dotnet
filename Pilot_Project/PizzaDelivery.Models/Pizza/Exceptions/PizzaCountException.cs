using System;

namespace PizzaDelivery.Models.Pizza.Exceptions
{
    public class PizzaCountException : Exception
    {
        public PizzaCountException(string message) : base(message)
        {
        }
    }
}
