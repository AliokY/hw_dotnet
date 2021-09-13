using PizzaDelivery.Models.Orders;
using System;
using System.Collections.Generic;

namespace PizzaDelivery.Console.Repositories.OrderReps
{
    class OrderStaticRepository : IRepository<Order>
    {
        private static List<Order> _orders = new();

        public void Add(Order order)
        {
            _orders.Add(order);
        }

        public void Delete(Guid id)
        {
           _orders.RemoveAll(_ => _.OrderId == id);
        }

        public List<Order> GetAll()
        {
            return _orders;
        }

        public Order GetById(Guid id)
        {
            return _orders.Find(_ => _.OrderId.Equals(id));

        }

        public void Update(Order order)
        {
            Order updateOrder = GetById(order.OrderId);

            if (updateOrder != null)
            {
                updateOrder.OrderTime = order.OrderTime;
                updateOrder.CurrentCart = order.CurrentCart;
                updateOrder.DeliveryAddress = updateOrder.DeliveryAddress;
            }
            else
            {
                throw new Exception("Такого заказа не существует!");
            }
        }
    }
}
