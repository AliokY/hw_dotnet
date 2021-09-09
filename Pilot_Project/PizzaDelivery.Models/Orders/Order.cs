using PizzaDelivery.Models.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Orders
{
    class Order
    {
        public Guid OrderId { get; set; }
        public Guid UserId { get; set; }
        public List<(PickedPizza, int)> PizzasInOreder { get; set; }
        public string DeliveryAddress { get; set; }
        public DateTime OrderTime { get; set; }
        public DateTime OrderDeliveryTime { get; set; }
        public OrderStatus CurrentStatus { get; set; }
        public decimal TotalPrice { get; set; }
    }
}

