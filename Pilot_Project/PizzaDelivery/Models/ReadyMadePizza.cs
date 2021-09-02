using PizzaDelivery.Models.Enums;
using PizzaDelivery.Models.Models;
using System;
using System.Collections.Generic;

namespace PizzaDelivery.Models
{
    class ReadyMadePizza : BasePizza
    {
        public PizzaSizes PizzaSize { get; set; }
        public decimal PizzaPrise { get; set; }
        public int PizzaWeight { get; set; }
        public int PizzasNumber { get; set; }
        public ReadyMadePizza()
        {}
        public ReadyMadePizza(string pizzaType, PizzaSizes pizzaSize, 
            decimal pizzaPrize, int pizzaWeight, List<string> pizzaIngredients)  
            : base(pizzaType, pizzaIngredients)
        {
            PizzaSize = pizzaSize;
            PizzaPrise = pizzaPrize;
            PizzaWeight = pizzaWeight;
        }
    }
}
