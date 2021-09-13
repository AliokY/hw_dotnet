using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep
{
    class PizzaTypeJsonRepository : IRepository<PizzaType>
    {
        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<PizzaType>));
        public void Add(PizzaType type)
        {
            List<PizzaType> pizzaTypes = new();

            using (FileStream fs = new FileStream("PizzaTypes.json", FileMode.OpenOrCreate))
            {
                try
                {
                    pizzaTypes = (List<PizzaType>)jsonP.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            pizzaTypes.Add(type);

            using (FileStream fs = new FileStream("PizzaTypes.json", FileMode.Open)) // need to add more settings?
            {
                jsonP.WriteObject(fs, pizzaTypes);
            }
        }

        public void Delete(Guid Id)
        {
            List<PizzaType> pizzaTypes = new();

            using (FileStream fs = new FileStream("PizzaTypes.json", FileMode.Open))
            {
                pizzaTypes = (List<PizzaType>)jsonP.ReadObject(fs);
                pizzaTypes.RemoveAll(x => x.Id == Id);

                foreach (var pizza in pizzaTypes)
                {
                    jsonP.WriteObject(fs, pizzaTypes);
                }
            }
        }

        public List<PizzaType> GetAll()
        {
            List<PizzaType> pizzaTypes = new();

            using (FileStream fs = new FileStream("PizzaTypes.json", FileMode.Open))
            {
                pizzaTypes = (List<PizzaType>)jsonP.ReadObject(fs);
            }

            return pizzaTypes;
        }

        public PizzaType GetById(Guid Id)
        {
            List<PizzaType> pizzaTypes = new();

            using (FileStream fs = new FileStream("PizzaTypes.json", FileMode.Open))
            {
                pizzaTypes = (List<PizzaType>)jsonP.ReadObject(fs);
            }

            return pizzaTypes.Find(_ => _.Id.Equals(Id));
        }

        public void Update(PizzaType type)
        {
            List<PizzaType> pizzaTypes = new();

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.Open))
            {
                pizzaTypes = (List<PizzaType>)jsonP.ReadObject(fs);

                PizzaType updateType = pizzaTypes.Find(_ => _.Id.Equals(type.Id));

                if (updateType != null)
                {
                    updateType.Name = type.Name;
                }
                else
                {
                    throw new Exception("Такой пиццы не существет.");
                }
            }
        }
    }
}