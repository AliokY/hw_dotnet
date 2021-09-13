using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Pizzas
{
    [DataContract]
    public class PickedPizza
    {
        [DataMember]
        public string Type { get; set; }
        [DataMember]
        public string Size { get; set; }
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public int Weight { get; set; }

        public PickedPizza(string type, string size, decimal price, int weight)
        {
            Type = type;
            Size = size;
            Price = price;
            Weight = weight;
        }
    }
}

