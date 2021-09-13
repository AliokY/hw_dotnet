using PizzaDelivery.Models.Pizza.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Pizza
{
    [DataContract]
    public class PizzaPrice
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string PizzaName { get; set; }
        [DataMember]
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
