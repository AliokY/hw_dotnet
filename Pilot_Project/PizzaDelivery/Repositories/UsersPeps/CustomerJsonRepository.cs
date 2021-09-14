using PizzaDelivery.Models.Users;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep
{
    class CustomerJsonRepository : IRepository<Customer>
    {
        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<Customer>));
        public void Add(Customer customer)
        {
            List<Customer> customers = new();

            using (FileStream fs = new FileStream("Customers.json", FileMode.OpenOrCreate))
            {
                try
                {
                    customers = (List<Customer>)jsonP.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            customers.Add(customer);

            using (FileStream fs = new FileStream("Customers.json", FileMode.Open)) 
            {
                jsonP.WriteObject(fs, customers);
            }
        }

        public void Delete(Guid Id)
        {
            List<Customer> customers = new();

            using (FileStream fs = new FileStream("Customers.json", FileMode.Open))
            {
                customers = (List<Customer>)jsonP.ReadObject(fs);
                customers.RemoveAll(x => x.Id == Id);

                foreach (var pizza in customers)
                {
                    jsonP.WriteObject(fs, customers);
                }
            }
        }

        public List<Customer> GetAll()
        {
            List<Customer> customers = new();

            using (FileStream fs = new FileStream("Customers.json", FileMode.Open))
            {
                customers = (List<Customer>)jsonP.ReadObject(fs);
            }
            return customers;
        }

        public Customer GetById(Guid Id)
        {
            List<Customer> customers = new();

            using (FileStream fs = new FileStream("Customers.json", FileMode.Open))
            {
                customers = (List<Customer>)jsonP.ReadObject(fs);
            }
            return customers.Find(_ => _.Id.Equals(Id));
        }

        public void Update(Customer customer)
        {
            List<Customer> customers = new();

            using (FileStream fs = new FileStream("Customers.json", FileMode.Open))
            {
                customers = (List<Customer>)jsonP.ReadObject(fs);

                Customer updateCustomer = customers.Find(_ => _.Id.Equals(customer.Id));

                if (updateCustomer != null)
                {
                    updateCustomer.Name = customer.Name;
                    updateCustomer.Login = customer.Login;
                    updateCustomer.Password = customer.Password;
                    updateCustomer.Email = customer.Email;
                    updateCustomer.CustomerAdress = customer.CustomerAdress;
                }
                else
                {
                    throw new Exception("Такого клиента не существует.");
                }
            }
        }
    }
}