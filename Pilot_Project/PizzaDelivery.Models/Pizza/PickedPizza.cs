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
}

