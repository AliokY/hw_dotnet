using PizzaDelivery.Models.Pizza.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Pizza
{
    public class PizzaWeight
    {
        public Guid Id { get; set; }
        public string PizzaName { get; set; }
        public Dictionary<PizzaSize, int> PizzaWeightToSize { get; set; }
        public PizzaWeight(){}
        public PizzaWeight(string pizzaName, Dictionary<PizzaSize, int> pizzaWeightToSize)
        {
            Id = Guid.NewGuid();

            PizzaWeightToSize = pizzaWeightToSize;
            PizzaName = pizzaName;
        }
    }
}
