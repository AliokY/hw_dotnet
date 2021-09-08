using PizzaDelivery.Console.Controls;
using PizzaDelivery.Console.Repositories;
using PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep;
using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Pizza.Enums;
using PizzaDelivery.Models.Pizzas;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.Console
{
    // todo: 
    // make cart as a singleton



    class Program
    {
        static void Main(string[] args)
        {
            // -- 
            //- PizzaDelivery.Console - console app
            //- PizzaDelivery.Models - class library
            //- PizzaDelivery.Logger - class library

            // todo: remove
            //var cart2 = new Cart2();
            //cart2.PickedPizza.Add(new PickedPizza(PizzaSizes.Large, "Карбонара"));
            //cart2.PickedPizza.Add(new PickedPizza(PizzaSizes.Medium, "Карбонара"));
            //cart2.PickedPizza.Add(new PickedPizza(PizzaSizes.Large, "Карбонара"));
            //cart2.PickedPizza.Add(new PickedPizza(PizzaSizes.Small, "Карбонара"));
            //cart2.PickedPizza.Add(new PickedPizza(PizzaSizes.Small, "Сырная"));



            //foreach (var i in cart2.Items)
            //{
            //    System.Console.WriteLine($"{i.Name} ({i.Count}) - ${i.LineSum}");
            //}
            //System.Console.WriteLine($"Total: ${cart2.TotalSum}");

            //System.Console.Read();

            PizzaTypeStaticRepository pizzaTypeSR = new PizzaTypeStaticRepository();
            PizzaIngredientStaticRepository pizzaIngredientSR = new PizzaIngredientStaticRepository();
            PizzaPraceStaticRepository pizzaPraceSR = new PizzaPraceStaticRepository();
            PizzaWeightStaticRepository pizzaWeightSR = new PizzaWeightStaticRepository();

            List<PizzaType> pizzaTypes = pizzaTypeSR.GetAll();
            List<PizzaIngredient> pizzaIngredients = pizzaIngredientSR.GetAll();
            List<PizzaPrice> pizzaPrices = pizzaPraceSR.GetAll();
            List<PizzaWeight> pizzaWeights = pizzaWeightSR.GetAll();

            BasePizzaRepositoryJson jsonRep = new();

            List<BasePizza> pizzaAssortment = jsonRep.GetAll();

            Cart cart = new();

            ConstructPizza(out string pizzaType, out PizzaSizes pizzaSize, out int pizzaWeight,
            out decimal pizzaPrice, pizzaAssortment);

            ReadyMadePizza rmPizza = new ReadyMadePizza(pizzaType, pizzaSize,
                pizzaPrice, pizzaWeight);

           // cart.AddPizzaToCart(rmPizza);
           
            bool status = ContinueChoice("Перейти в корзину");

            

        }

        static PickedPizza ConstructPizza(List<PizzaType> pizzaTypes, List<PizzaIngredient> pizzaIngredients,
            List<PizzaPrice> pizzaPrices, List<PizzaWeight> pizzaWeights)
        {
            string pickedPizzaType;
            string pickedPizzaSize;
            decimal pickedPizzaPrice;
            int pickedPizzaWeight;

            while (true)
            {
                pickedPizzaType = PizzaConstructorConsole.PizzaTypeChoose(pizzaTypes);
                ShowPizzaIngredients(pickedPizzaType, pizzaIngredients);

                bool pizzaStatus = ContinueChoice("Продолжить");
                if (!pizzaStatus)
                {
                    System.Console.Clear();
                    continue;
                }
                PizzaConstructorConsole.PizzaSizeChoose(out string stringSize, out PizzaSize chosenSize);
                pickedPizzaSize = stringSize;

                pickedPizzaWeight = PizzaConstructorConsole.GetPizzaWeight(pickedPizzaType, chosenSize, pizzaWeights);
                pickedPizzaPrice = PizzaConstructorConsole.GetPizzaPrice(pickedPizzaType, chosenSize, pizzaPrices);
                System.Console.WriteLine($"Вес пиццы: {pickedPizzaWeight} г, цена: {pickedPizzaPrice} руб.");

                pizzaStatus = ContinueChoice("Добавить пиццу в корзину");

                if (pizzaStatus) break;

                System.Console.Clear();
            }

            PickedPizza pickedPizza = new PickedPizza(pickedPizzaType, pickedPizzaSize,
                pickedPizzaPrice, pickedPizzaWeight);
            return pickedPizza;
        }

        static void ShowPizzaIngredients(string pizzaType, List<PizzaIngredient> pizzaIngredients)
        {
            List<PizzaIngredient> pickedPizzaIngredients = pizzaIngredients.Where(_ => _.PizzaTypesList.Contains(pizzaType)).ToList();

            System.Console.WriteLine($"Пицца-{pizzaType}. Ингредиенты:");
            foreach (var item in pickedPizzaIngredients)
            {
                System.Console.WriteLine(item.Name);
            }
            System.Console.WriteLine();
        }

        static bool ContinueChoice(string nextStep)
        {
            bool pizzaStatus = false;
            var pizzaStatusStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(3)
                .AddChoices(new[] { nextStep, "Вернуться к выбору" }));

            if (pizzaStatusStr == nextStep)
                pizzaStatus = true;

            return pizzaStatus;
        }

        //static void FillJsonFile(BasePizzaRepositoryJson jsonRep, List<BasePizza> _pizzaAssortment)
        //{
        //    foreach (var item in _pizzaAssortment)
        //    {
        //        jsonRep.Add(item);
        //    }
        //}

    }
}
