using PizzaDelivery.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Console.Repositories
{
    class BasePizzaRepositoryJson : IRepository<BasePizza>
    {
        DataContractJsonSerializer jsonP = new DataContractJsonSerializer(typeof(List<BasePizza>));

        public void Add(BasePizza pizza)
        {
            List<BasePizza> pizzaAssortment = new();

            using (FileStream fs = new FileStream("PizzaAssortment.json", FileMode.OpenOrCreate)) // need to add more settings?
            {
                try
                {
                    pizzaAssortment = (List<BasePizza>)jsonP.ReadObject(fs);
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
                pizzaAssortment.Add(pizza);

            using (FileStream fs = new FileStream("PizzaAssortment.json", FileMode.Open)) // need to add more settings?
            {
                jsonP.WriteObject(fs, pizzaAssortment);
            }
        }

        public void Delete(Guid Id)
        {
            List<BasePizza> pizzaAssortment = new();

            using (FileStream fs = new FileStream("PizzaAssortment.json", FileMode.Open))
            {
                pizzaAssortment = (List<BasePizza>)jsonP.ReadObject(fs);
                pizzaAssortment.RemoveAll(x => x.Id == Id);

                foreach (var pizza in pizzaAssortment)
                {
                    jsonP.WriteObject(fs, pizza);
                }
            }
        }

        public IList<BasePizza> GetAll()
        {
            List<BasePizza> pizzaAssortment = new();

            using (FileStream fs = new FileStream("PizzaAssortment.json", FileMode.Open))
            {
                pizzaAssortment = (List<BasePizza>)jsonP.ReadObject(fs);
            }

            return pizzaAssortment;
        }

        public BasePizza GetById(Guid Id)
        {
            List<BasePizza> pizzaAssortment = new();

            using (FileStream fs = new FileStream("PizzaAssortment.json", FileMode.Open))
            {
                pizzaAssortment = (List<BasePizza>)jsonP.ReadObject(fs);
            }

            return pizzaAssortment.Find(_ => _.Id.Equals(Id));
        }

        public void Update(BasePizza pizza)
        {
            List<BasePizza> pizzaAssortment = new();

            using (FileStream fs = new FileStream("PizzaAssortment.json", FileMode.Open))
            {
                pizzaAssortment = (List<BasePizza>)jsonP.ReadObject(fs);

                BasePizza updatedPizza = pizzaAssortment.Find(_ => _.Id.Equals(pizza.Id));

                if (updatedPizza != null)
                {
                    updatedPizza.PizzaIngredients = pizza.PizzaIngredients;
                    updatedPizza.PizzaPriceToSize = pizza.PizzaPriceToSize;
                    updatedPizza.PizzaWeightToSize = pizza.PizzaWeightToSize;
                }
                else
                {
                    throw new Exception("Такой пиццы не существует!");
                }
            }
        }

    }
}
