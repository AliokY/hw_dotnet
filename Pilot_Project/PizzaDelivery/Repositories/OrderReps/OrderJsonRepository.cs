using PizzaDelivery.Models.Orders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep
{
    class OrderJsonRepository : IRepository<Order>
    {
        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<Order>));
        public void Add(Order order)
        {
            List<Order> orders = new();

            using (FileStream fs = new FileStream("Orders.json", FileMode.OpenOrCreate))
            {
                try
                {
                    orders = (List<Order>)jsonP.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            orders.Add(order);

            using (FileStream fs = new FileStream("Orders.json", FileMode.Open)) 
            {
                jsonP.WriteObject(fs, orders);
            }
        }

        public void Delete(Guid Id)
        {
            List<Order> orders = new();

            using (FileStream fs = new FileStream("Orders.json", FileMode.Open))
            {
                orders = (List<Order>)jsonP.ReadObject(fs);
                orders.RemoveAll(x => x.OrderId == Id);

                foreach (var pizza in orders)
                {
                    jsonP.WriteObject(fs, orders);
                }
            }
        }

        public List<Order> GetAll()
        {
            List<Order> orders = new();

            using (FileStream fs = new FileStream("Orders.json", FileMode.Open))
            {
                orders = (List<Order>)jsonP.ReadObject(fs);
            }

            return orders;
        }

        public Order GetById(Guid Id)
        {
            List<Order> orders = new();

            using (FileStream fs = new FileStream("Orders.json", FileMode.Open))
            {
                orders = (List<Order>)jsonP.ReadObject(fs);
            }
            return orders.Find(_ => _.OrderId.Equals(Id));
        }

        public void Update(Order order)
        {
            List<Order> orders = new();

            using (FileStream fs = new FileStream("Orders.json", FileMode.Open))
            {
                orders = (List<Order>)jsonP.ReadObject(fs);

                Order updateOrder = orders.Find(_ => _.OrderId.Equals(order.OrderId));

                if (updateOrder != null)
                {
                    updateOrder.DeliveryAddress = order.DeliveryAddress;
                    updateOrder.DeliveryTime = order.DeliveryTime;
                }
                else
                {
                    throw new Exception("Такого заказа не существует.");
                }
            }
            using (FileStream fs = new FileStream("Orders.json", FileMode.Open))
            {
                jsonP.WriteObject(fs, orders);
            }
        }
    }
}