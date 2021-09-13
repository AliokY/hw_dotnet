using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Pizza.Exceptions
{
    public class PizzaCountException : Exception
    {
        public PizzaCountException(string message) : base(message)
        {
        }
    }
}
