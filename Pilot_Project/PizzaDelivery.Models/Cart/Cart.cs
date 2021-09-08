using PizzaDelivery.Models.Pizzas;
using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.Console.Controls
{
    public class Cart
    {
        private static List<(PickedPizza, int)> ChosenPizzas { get; set; } = new();

        private decimal _totalPrice;
        public decimal TotalPrice
        {
            get
            {
                return _totalPrice;
            }
            set
            {
                foreach (var pizza in ChosenPizzas)
                {
                    _totalPrice += pizza.Item1.PizzaPrise * pizza.Item2;
                }
            }
        }

        public void ShowCart(bool status)
        {
            if (status)
            {
                foreach (var item in ChosenPizzas)
                {
                    System.Console.WriteLine();
                    System.Console.WriteLine($"{item.Item1.PizzaType}, вес {item.Item1.PizzaWeight} г," +
                        $"количество {item.Item2} шт.");
                }
            }
        }

        public void ChangePizzasNumber()
        {
        
        
        }


    }


    public class Cart2 
    {
        public Cart2()
        {
            PickedPizza = new List<PickedPizza>();
        }

        public List<PickedPizza> PickedPizza { get; }

        public decimal TotalSum => PickedPizza.Sum(p => p.PizzaPrice);

        public List<CartItem> Items =>
            PickedPizza
            .GroupBy(p => p.PizzaType)
            .Select(i => new CartItem(i.Key, i.Count(), i.Sum(a => a.PizzaPrice)))
            .ToList();
    }

    public class CartItem
    {
        public string Name { get; }

        public CartItem(string name, int count = 0, decimal lineSum = 0)
        {
            Name = name;
            Count = count;
            LineSum = lineSum;
        }

        public int Count { get; }
        public decimal LineSum { get; }
    }
}
