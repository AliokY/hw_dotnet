using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep
{
    class PizzaPriceJsonRepository : IRepository<PizzaPrice>
    {
        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<PizzaPrice>));
        public void Add(PizzaPrice price)
        {
            List<PizzaPrice> pizzaPrises = new();

            using (FileStream fs = new FileStream("PizzaPrice.json", FileMode.OpenOrCreate))
            {
                try
                {
                    pizzaPrises = (List<PizzaPrice>)jsonP.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            pizzaPrises.Add(price);

            using (FileStream fs = new FileStream("PizzaPrice.json", FileMode.Open)) 
            {
                jsonP.WriteObject(fs, pizzaPrises);
            }
        }

        public void Delete(Guid id)
        {
            List<PizzaPrice> pizzaPrises = new();

            using (FileStream fs = new FileStream("PizzaPrice.json", FileMode.Open))
            {
                pizzaPrises = (List<PizzaPrice>)jsonP.ReadObject(fs);
                pizzaPrises.RemoveAll(x => x.Id == id);

                foreach (var pizza in pizzaPrises)
                {
                    jsonP.WriteObject(fs, pizzaPrises);
                }
            }
        }

        public List<PizzaPrice> GetAll()
        {
            List<PizzaPrice> pizzaPrises = new();

            using (FileStream fs = new FileStream("PizzaPrice.json", FileMode.Open))
            {
                pizzaPrises = (List<PizzaPrice>)jsonP.ReadObject(fs);
            }

            return pizzaPrises;
        }

        public PizzaPrice GetById(Guid id)
        {
            List<PizzaPrice> pizzaPrises = new();

            using (FileStream fs = new FileStream("PizzaPrice.json", FileMode.Open))
            {
                pizzaPrises = (List<PizzaPrice>)jsonP.ReadObject(fs);
            }

            return pizzaPrises.Find(_ => _.Id.Equals(id));
        }

        public void Update(PizzaPrice weight)
        {
            List<PizzaPrice> pizzaPrises = new();

            using (FileStream fs = new FileStream("PizzaPrice.json", FileMode.Open))
            {
                pizzaPrises = (List<PizzaPrice>)jsonP.ReadObject(fs);

                PizzaPrice updatePrice = pizzaPrises.Find(_ => _.Id.Equals(weight.Id));

                if (updatePrice != null)
                {
                    updatePrice.PizzaPriceToSize = weight.PizzaPriceToSize;
                }
                else
                {
                    throw new Exception("Такого позиции не существует.");
                }
                jsonP.WriteObject(fs, pizzaPrises);
            }
        }
    }
}