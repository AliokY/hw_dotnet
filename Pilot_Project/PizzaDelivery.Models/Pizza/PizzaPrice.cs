using PizzaDelivery.Models.Pizza.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Pizza
{
    public class PizzaPrice
    {
        public Guid Id { get; set; }
        public string PizzaName { get; set; }
        public Dictionary<PizzaSize, decimal> PizzaPriceToSize { get; set; }
        public PizzaPrice(){}
        public PizzaPrice(string pizzaName, Dictionary<PizzaSize, decimal> pizzaPriceToSize)
        {
            Id = Guid.NewGuid();

            PizzaPriceToSize = pizzaPriceToSize;
            PizzaName = pizzaName;
        }

    }
}
