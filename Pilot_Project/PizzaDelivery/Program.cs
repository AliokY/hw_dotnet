using PizzaDelivery.Console.Controls;
using PizzaDelivery.Console.Repositories;
using PizzaDelivery.Models;
using PizzaDelivery.Models.Enums;
using PizzaDelivery.Models.Models;
using Spectre.Console;
using System;
using System.Collections.Generic;

namespace PizzaDelivery.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            // -- 
            //- PizzaDelivery.Console - console app
            //- PizzaDelivery.Models - class library
            //- PizzaDelivery.Logger - class library

            BasePizzaRepositoryJson jsonRep = new();


            

            ConstructPizza(out string pizzaType, out PizzaSizes pizzaSize);

            ReadyMadePizza pizza_1 = new ReadyMadePizza(pizzaType, pizzaSize);

        }

        static void ConstructPizza(out string pizzaType, out PizzaSizes pizzaSize)
        {













            while (true)
            {

                pizzaType = PizzaConstructorConsole.PizzaTypeChoose(PizzaTypes.pizzaTypes);
                ShowPizzaIngredients(pizzaType);

                pizzaSize = PizzaConstructorConsole.PizzaSizeChoose();

                int pizzaWeight = PizzaConstructorConsole.GetPizzaWeight(pizzaType, pizzaSize);
                decimal pizzaPrice = PizzaConstructorConsole.GetPizzaPrice(pizzaType, pizzaSize);
                System.Console.WriteLine($"Вес пиццы: {pizzaWeight} г, цена: {pizzaPrice} руб.");

                bool pizzaStatus = AddPizzaToCart();

                if (pizzaStatus) break;

                System.Console.Clear();
            }
        }

        static void ShowPizzaIngredients(string pizzaType)
        {
            System.Console.WriteLine("Ингредиенты:");
            foreach (var item in PizzaTypes.ingredients[pizzaType])
            {
                System.Console.WriteLine(item);
            }
            System.Console.WriteLine();
        }

        static bool AddPizzaToCart()
        {
            bool pizzaStatus = false;
            var pizzaStatusStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(3)
                .AddChoices(new[] { "Добавить в корзину", "Вернуться к выбору" }));

            if (pizzaStatusStr == "Добавить в корзину")
                pizzaStatus = true;

            return pizzaStatus;
        }

        static void FillJsonFile(BasePizzaRepositoryJson jsonRep, List<BasePizza> _pizzaAssortment)
        {
            foreach (var item in _pizzaAssortment)
            {
                jsonRep.Add(item);
            }
        }
    }
}
