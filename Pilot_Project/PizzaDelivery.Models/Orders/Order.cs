using PizzaDelivery.Models.CartInfo;
using System;

namespace PizzaDelivery.Models.Orders
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public Guid CustomerId { get; set; }
        public Cart CurrentCart { get; set; }
        public string DeliveryAddress { get; set; }
        public string OrderTime { get; set; }
        public string DeliveryTime { get; set; }

        public Order(Guid customerId, Cart currentCart, string deliveryAddress)
        {
            OrderId = Guid.NewGuid();

            CustomerId = customerId;
            CurrentCart = currentCart;
            DeliveryAddress = deliveryAddress;

            OrderTime = DateTime.Now.ToString("HH:mm");
            DeliveryTime = DateTime.Now.AddHours(1).ToString("HH:mm");
        }
    }
}

