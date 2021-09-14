using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep
{
    class PizzaWeightJsonRepository : IRepository<PizzaWeight>
    {
        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<PizzaWeight>));
        public void Add(PizzaWeight ingredient)
        {
            List<PizzaWeight> pizzaWeights = new();

            using (FileStream fs = new FileStream("PizzaWeights.json", FileMode.OpenOrCreate))
            {
                try
                {
                    pizzaWeights = (List<PizzaWeight>)jsonP.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            pizzaWeights.Add(ingredient);

            using (FileStream fs = new FileStream("PizzaWeights.json", FileMode.Open)) 
            {
                jsonP.WriteObject(fs, pizzaWeights);
            }
        }

        public void Delete(Guid id)
        {
            List<PizzaWeight> pizzaWeights = new();

            using (FileStream fs = new FileStream("PizzaWeights.json", FileMode.Open))
            {
                pizzaWeights = (List<PizzaWeight>)jsonP.ReadObject(fs);
                pizzaWeights.RemoveAll(x => x.Id == id);

                foreach (var pizza in pizzaWeights)
                {
                    jsonP.WriteObject(fs, pizzaWeights);
                }
            }
        }

        public List<PizzaWeight> GetAll()
        {
            List<PizzaWeight> pizzaWeights = new();

            using (FileStream fs = new FileStream("PizzaWeights.json", FileMode.Open))
            {
                pizzaWeights = (List<PizzaWeight>)jsonP.ReadObject(fs);
            }

            return pizzaWeights;
        }

        public PizzaWeight GetById(Guid id)
        {
            List<PizzaWeight> pizzaWeights = new();

            using (FileStream fs = new FileStream("PizzaWeights.json", FileMode.Open))
            {
                pizzaWeights = (List<PizzaWeight>)jsonP.ReadObject(fs);
            }
            return pizzaWeights.Find(_ => _.Id.Equals(id));
        }

        public void Update(PizzaWeight weight)
        {
            List<PizzaWeight> pizzaWeights = new();

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.Open))
            {
                pizzaWeights = (List<PizzaWeight>)jsonP.ReadObject(fs);

                PizzaWeight updateWeight = pizzaWeights.Find(_ => _.Id.Equals(weight.Id));

                if (updateWeight != null)
                {
                    updateWeight.PizzaWeightToSize = weight.PizzaWeightToSize;
                }
                else
                {
                    throw new Exception("Такого позиции не существует.");
                }
                jsonP.WriteObject(fs, pizzaWeights);
            }
        }
    }
}