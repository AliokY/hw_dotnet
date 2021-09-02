using PizzaDelivery.Models;
using PizzaDelivery.Models.Models;
using System;
using System.Collections.Generic;

namespace PizzaDelivery.Console.Repositories
{
    class BasePizzaRepositoryStatic :IRepository<BasePizza>
    {
        public static List<BasePizza> _pizzaAssortment = new()
        {
            new BasePizza(PizzaTypes.pizzaTypes[0], PizzaTypes.ingredients["Карбонара"],
                PizzaTypes.pizzaPrice["Карбонара"], PizzaTypes.pizzaWeight["Карбонара"]),
            new BasePizza(PizzaTypes.pizzaTypes[1], PizzaTypes.ingredients["Маргарита"],
                PizzaTypes.pizzaPrice["Маргарита"], PizzaTypes.pizzaWeight["Маргарита"]),
            new BasePizza(PizzaTypes.pizzaTypes[2], PizzaTypes.ingredients["Двойной цыплёнок"],
                PizzaTypes.pizzaPrice["Двойной цыплёнок"], PizzaTypes.pizzaWeight["Двойной цыплёнок"]),
            new BasePizza(PizzaTypes.pizzaTypes[3], PizzaTypes.ingredients["Колбаски барбекю"],
                PizzaTypes.pizzaPrice["Колбаски барбекю"], PizzaTypes.pizzaWeight["Колбаски барбекю"]),
            new BasePizza(PizzaTypes.pizzaTypes[4], PizzaTypes.ingredients["Нежный лосось"],
                PizzaTypes.pizzaPrice["Нежный лосось"], PizzaTypes.pizzaWeight["Нежный лосось"]),
            new BasePizza(PizzaTypes.pizzaTypes[5], PizzaTypes.ingredients["Сырная"],
                PizzaTypes.pizzaPrice["Сырная"], PizzaTypes.pizzaWeight["Сырная"]),
            new BasePizza(PizzaTypes.pizzaTypes[6], PizzaTypes.ingredients["Ветчина и сыр"],
                PizzaTypes.pizzaPrice["Ветчина и сыр"], PizzaTypes.pizzaWeight["Ветчина и сыр"])
        };

        public void Add(BasePizza pizza)
        {
            _pizzaAssortment.Add(pizza);
        }

        public void Delete(Guid Id)
        {
            _pizzaAssortment.RemoveAll(x => x.Id == Id); // or "foreach with break" use better?
        }

        public IList<BasePizza> GetAll()
        {
            return _pizzaAssortment;
        }

        public BasePizza GetById(Guid Id)
        {
            return _pizzaAssortment.Find(_ => _.Id.Equals(Id));
        }

        public void Update(BasePizza pizza)
        {
            BasePizza updatedPizza = GetById(pizza.Id);

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
