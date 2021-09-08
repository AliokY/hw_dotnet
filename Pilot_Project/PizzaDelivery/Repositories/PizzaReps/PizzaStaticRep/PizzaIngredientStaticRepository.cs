using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep
{
    class PizzaIngredientStaticRepository : IRepository<PizzaIngredient>
    {
        private static List<PizzaIngredient> _pizzaIngredients = new()
        {
            new PizzaIngredient("бекон", new List<string>() { "Карбонара" }),
            new PizzaIngredient("сыры чеддер и пармезан", new List<string>()
            {
                "Карбонара",
                "Сырная"
            }),
            new PizzaIngredient("моцарелла", new List<string>()
            {
                "Карбонара",
                "Маргарита",
                "Двойной цыплёнок",
                "Колбаски барбекю",
                "Нежный лосось",
                "Сырная",
                "Ветчина и сыр"
            }),
            new PizzaIngredient("томаты", new List<string>()
            {
                "Карбонара",
                "Маргарита",
                "Колбаски барбекю",
                "Нежный лосось"
            }),
            new PizzaIngredient("соус альфреддо", new List<string>()
            {
                "Карбонара",
                "Двойной цыплёнок",
                "Нежный лосось",
                "Сырная",
                "Ветчина и сыр"
            }),
            new PizzaIngredient("красный лук", new List<string>()
            {
                "Карбонара ",
                "Колбаски барбекю",
            }),
            new PizzaIngredient("чеснок", new List<string>() { "Карбонара" }),
            new PizzaIngredient("итальянские травы", new List<string>()
            {
                "Карбонара",
                "Маргарита",
            }),
            new PizzaIngredient("томатный соус", new List<string>()
            {
                "Маргарита",
                "Колбаски барбекю"
            }),
            new PizzaIngredient("цыплёнок", new List<string>() { "Двойной цыплёнок" }),
            new PizzaIngredient("острые колбаски чоризо", new List<string>() { "Колбаски барбекю" }),
            new PizzaIngredient("соус барбекю", new List<string>() { "Колбаски барбекю" }),
            new PizzaIngredient("лосось", new List<string>() { "Нежный лосось" }),
            new PizzaIngredient("соус песто", new List<string>() {"Нежный лосось"}),
            new PizzaIngredient("ветчина", new List<string>() { "Ветчина и сыр" })
        };

        public void Add(PizzaIngredient ingredient)
        {
            _pizzaIngredients.Add(ingredient);
        }

        public void Delete(Guid Id)
        {
            _pizzaIngredients.RemoveAll(_ => _.Id == Id);
        }

        public List<PizzaIngredient> GetAll()
        {
            return _pizzaIngredients;
        }

        public PizzaIngredient GetById(Guid Id)
        {
            return _pizzaIngredients.Find(_ => _.Id.Equals(Id));
        }

        public void Update(PizzaIngredient ingredient)
        {
            PizzaIngredient updateIngredient = GetById(ingredient.Id);

            if (updateIngredient != null)
            {
                updateIngredient.PizzaTypesList = ingredient.PizzaTypesList;
            }
            else 
            {
                throw new Exception("Такого ингредиента нет!");
            }
        }
    }
}
