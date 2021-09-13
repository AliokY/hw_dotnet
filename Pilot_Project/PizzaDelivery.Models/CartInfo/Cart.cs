using PizzaDelivery.Models.Pizzas;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.CartInfo
{
    // Singleton Pattern Realized
    [DataContract]
    public class Cart
    {
        [DataMember]
        public List<PickedPizza> PickedPizza { get; private set; }

        private Cart()
        {
            PickedPizza = new List<PickedPizza>();
        }
        [DataMember]
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
        [DataMember]
        public List<CartItem> Items =>
            PickedPizza
            .GroupBy(t => new
            {
                t.Type,
                t.Size,
            })
            .Select(i => new CartItem(
               i.Key.Type,
               i.Key.Size,
               i.Count(),
               i.Sum(a => a.Price)))
            .ToList();
    }
    [DataContract]
    public class CartItem
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Size { get; set; }

        public CartItem(string name, string size, int count = 0, decimal lineSum = 0)
        {
            Name = name;
            Size = size;
            Count = count;
            LineSum = lineSum;
        }
        [DataMember]
        public int Count { get; set; }
        [DataMember]
        public decimal LineSum { get; set; }
    }
}
