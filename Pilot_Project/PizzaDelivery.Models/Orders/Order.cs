using PizzaDelivery.Models.CartInfo;
using System;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Orders
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public Guid OrderId { get; set; }
        [DataMember]
        public Guid CustomerId { get; set; }
        [DataMember]
        public Cart CurrentCart { get; set; }
        [DataMember]
        public string DeliveryAddress { get; set; }
        [DataMember]
        public string OrderTime { get; set; }
        [DataMember]
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

