using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep
{
    class PizzaIngredientJsonRepository : IRepository<PizzaIngredient>
    {
        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<PizzaIngredient>));
        public void Add(PizzaIngredient ingredient)
        {
            List<PizzaIngredient> pizzaIngredients = new();

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.OpenOrCreate))
            {
                try
                {
                    pizzaIngredients = (List<PizzaIngredient>)jsonP.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
            pizzaIngredients.Add(ingredient);

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.Open)) 
            {
                jsonP.WriteObject(fs, pizzaIngredients);
            }
        }

        public void Delete(Guid Id)
        {
            List<PizzaIngredient> pizzaIngredients = new();

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.Open))
            {
                pizzaIngredients = (List<PizzaIngredient>)jsonP.ReadObject(fs);
                pizzaIngredients.RemoveAll(x => x.Id == Id);

                foreach (var pizza in pizzaIngredients)
                {
                    jsonP.WriteObject(fs, pizzaIngredients);
                }
            }
        }

        public List<PizzaIngredient> GetAll()
        {
            List<PizzaIngredient> pizzaIngredients = new();

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.Open))
            {
                pizzaIngredients = (List<PizzaIngredient>)jsonP.ReadObject(fs);
            }
            return pizzaIngredients;
        }

        public PizzaIngredient GetById(Guid Id)
        {
            List<PizzaIngredient> pizzaIngredients = new();

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.Open))
            {
                pizzaIngredients = (List<PizzaIngredient>)jsonP.ReadObject(fs);
            }
            return pizzaIngredients.Find(_ => _.Id.Equals(Id));
        }

        public void Update(PizzaIngredient ingredient)
        {
            List<PizzaIngredient> pizzaIngredients = new();

            using (FileStream fs = new FileStream("PizzaIngredients.json", FileMode.Open))
            {
                pizzaIngredients = (List<PizzaIngredient>)jsonP.ReadObject(fs);

                PizzaIngredient updateIngredients = pizzaIngredients.Find(_ => _.Id.Equals(ingredient.Id));

                if (updateIngredients != null)
                {
                    updateIngredients.PizzaTypesList = ingredient.PizzaTypesList;
                }
                else
                {
                    throw new Exception("Такого ингредиента не существует.");
                }
                jsonP.WriteObject(fs, pizzaIngredients);
            }
        }
    }
}