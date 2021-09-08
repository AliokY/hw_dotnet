using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Pizza.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Pizzas
{

    public class PickedPizza
    {
        public string Type { get; }
        public string Size { get; }
        public decimal Price { get; }
        public int Weight { get; }

        public PickedPizza(string type, string size, decimal price, int weight)
        {
            Type = type;
            Size = size;
            Price = price;
            Weight = weight;
        }
    }

    //[DataContract]
    //public class BasePizza
    //{
    //    [DataMember]
    //    public Guid Id { get; private set; }
    //    [DataMember]
    //    public string PizzaType { get; set; }
    //    [DataMember]
    //    public List<string> PizzaIngredients { get; set; }
    //    [DataMember]
    //    public Dictionary<PizzaSizes, decimal> PizzaPriceToSize { get; set; }
    //    [DataMember]
    //    public Dictionary<PizzaSizes, int> PizzaWeightToSize { get; set; }
    //    public BasePizza()
    //    {}
    //    public BasePizza(string pizzaType)
    //    {
    //        Id = Guid.NewGuid();
    //        PizzaType = pizzaType;

    //    }
    //    public BasePizza(string pizzaType, List<string> pizzaIngredients,
    //        Dictionary<PizzaSizes, decimal> pizzaPriceToSize,
    //        Dictionary<PizzaSizes, int> pizzaWeightToSize) : this(pizzaType)
    //    {
    //        PizzaPriceToSize = pizzaPriceToSize;
    //        PizzaWeightToSize = pizzaWeightToSize;
    //        PizzaIngredients = pizzaIngredients;
}

