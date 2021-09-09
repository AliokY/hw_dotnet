//using PizzaDelivery.Models;
//using PizzaDelivery.Models.Pizzas;
//using System;
//using System.Collections.Generic;

//namespace PizzaDelivery.Console.Repositories
//{
//    class BasePizzaRepositoryStatic : IRepository<BasePizza>
//    {
//        public static List<BasePizza> _pizzaAssortment = new()
//        {
//            new BasePizza(PizzaTypes.Pizza_Types[0], PizzaTypes.Ingredients["Карбонара"],
//                PizzaTypes.PizzaPrice["Карбонара"], PizzaTypes.PizzaWeight["Карбонара"]),
//            new BasePizza(PizzaTypes.Pizza_Types[1], PizzaTypes.Ingredients["Маргарита"],
//                PizzaTypes.PizzaPrice["Маргарита"], PizzaTypes.PizzaWeight["Маргарита"]),
//            new BasePizza(PizzaTypes.Pizza_Types[2], PizzaTypes.Ingredients["Двойной цыплёнок"],
//                PizzaTypes.PizzaPrice["Двойной цыплёнок"], PizzaTypes.PizzaWeight["Двойной цыплёнок"]),
//            new BasePizza(PizzaTypes.Pizza_Types[3], PizzaTypes.Ingredients["Колбаски барбекю"],
//                PizzaTypes.PizzaPrice["Колбаски барбекю"], PizzaTypes.PizzaWeight["Колбаски барбекю"]),
//            new BasePizza(PizzaTypes.Pizza_Types[4], PizzaTypes.Ingredients["Нежный лосось"],
//                PizzaTypes.PizzaPrice["Нежный лосось"], PizzaTypes.PizzaWeight["Нежный лосось"]),
//            new BasePizza(PizzaTypes.Pizza_Types[5], PizzaTypes.Ingredients["Сырная"],
//                PizzaTypes.PizzaPrice["Сырная"], PizzaTypes.PizzaWeight["Сырная"]),
//            new BasePizza(PizzaTypes.Pizza_Types[6], PizzaTypes.Ingredients["Ветчина и сыр"],
//                PizzaTypes.PizzaPrice["Ветчина и сыр"], PizzaTypes.PizzaWeight["Ветчина и сыр"])
//        };

//        public void Add(BasePizza pizza)
//        {
//            _pizzaAssortment.Add(pizza);
//        }

//        public void Delete(Guid Id)
//        {
//            _pizzaAssortment.RemoveAll(_ => _.Id == Id); // or "foreach with break" use better?
//        }

//        public List<BasePizza> GetAll()
//        {
//            return _pizzaAssortment;
//        }

//        public BasePizza GetById(Guid Id)
//        {
//            return _pizzaAssortment.Find(_ => _.Id.Equals(Id));
//        }

//        public void Update(BasePizza pizza)
//        {
//            BasePizza updatedPizza = GetById(pizza.Id);

//            if (updatedPizza != null)
//            {
//                updatedPizza.PizzaIngredients = pizza.PizzaIngredients;
//                updatedPizza.PizzaPriceToSize = pizza.PizzaPriceToSize;
//                updatedPizza.PizzaWeightToSize = pizza.PizzaWeightToSize;
//            }
//            else
//            {
//                throw new Exception("Такой пиццы не существует!");
//            }    

//        }
//    }
//}
