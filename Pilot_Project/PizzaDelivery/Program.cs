using PizzaDelivery.Console.Controls;
using PizzaDelivery.Console.Repositories;
using PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep;
using PizzaDelivery.Models.Cart;
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

            PizzaTypeStaticRepository pizzaTypeSR = new PizzaTypeStaticRepository();
            PizzaIngredientStaticRepository pizzaIngredientSR = new PizzaIngredientStaticRepository();
            PizzaPraceStaticRepository pizzaPraceSR = new PizzaPraceStaticRepository();
            PizzaWeightStaticRepository pizzaWeightSR = new PizzaWeightStaticRepository();

            List<PizzaType> pizzaTypes = pizzaTypeSR.GetAll();
            List<PizzaIngredient> pizzaIngredients = pizzaIngredientSR.GetAll();
            List<PizzaPrice> pizzaPrices = pizzaPraceSR.GetAll();
            List<PizzaWeight> pizzaWeights = pizzaWeightSR.GetAll();

            Cart cart = Cart.Instance;


            PizzaPickerConsole.FillCart(cart, pizzaTypes, pizzaIngredients,
            pizzaPrices, pizzaWeights);




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
