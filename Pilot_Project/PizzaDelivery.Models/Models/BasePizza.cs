using PizzaDelivery.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Models
{
    [DataContract]
    public class BasePizza
    {
        [DataMember]
        public Guid Id { get; private set; }
        [DataMember]
        public string PizzaType { get; set; }
        [DataMember]
        public List<string> PizzaIngredients { get; set; }
        [DataMember]
        public Dictionary<PizzaSizes, decimal> PizzaPriceToSize { get; set; }
        [DataMember]
        public Dictionary<PizzaSizes, int> PizzaWeightToSize { get; set; }
        public BasePizza()
        {}
        public BasePizza(string pizzaType, List<string> pizzaIngredients)
        {
            Id = Guid.NewGuid();
            PizzaType = pizzaType;
            PizzaIngredients = pizzaIngredients;
        }
        public BasePizza(string pizzaType, List<string> pizzaIngredients,
            Dictionary<PizzaSizes, decimal> pizzaPriceToSize,
            Dictionary<PizzaSizes, int> pizzaWeightToSize) : this(pizzaType, pizzaIngredients)
        {
            PizzaPriceToSize = pizzaPriceToSize;
            PizzaWeightToSize = pizzaWeightToSize;
        }

    }
}
