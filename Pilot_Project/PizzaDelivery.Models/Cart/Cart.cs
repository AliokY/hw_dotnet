using PizzaDelivery.Models.Pizzas;
using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.Models.Cart
{   
    // Singleton Pattern Realized
    public class Cart
    {
        public List<PickedPizza> PickedPizza { get; private set; }

        private Cart()
        {
            PickedPizza = new List<PickedPizza>();
        }
        static Cart uniqueInstance;
        public static Cart Instance
        {
            get
            {
                if (uniqueInstance == null)
                    uniqueInstance = new Cart();
                return uniqueInstance;
            }
        }
        public decimal TotalSum => PickedPizza.Sum(p => p.Price);
        public void EmptyCart()
        {
            PickedPizza = new List<PickedPizza>();
        }

        public List<CartItem> Items =>
            PickedPizza
            .GroupBy(p => p.Type)
            .Select(i => new CartItem(i.Key, i.Count(), i.Sum(a => a.Price)))
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
