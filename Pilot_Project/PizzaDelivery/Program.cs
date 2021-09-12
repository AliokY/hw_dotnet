using PizzaDelivery.Console.Controls;
using PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep;
using PizzaDelivery.Console.Repositories.UsersPeps;
using PizzaDelivery.Models.Cart;
using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Users;
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

            // service/repository registration
            CustomerRepositoryStatic customerRS = new CustomerRepositoryStatic();
            PizzaTypeStaticRepository pizzaTypeSR = new PizzaTypeStaticRepository();
            PizzaIngredientStaticRepository pizzaIngredientSR = new PizzaIngredientStaticRepository();
            PizzaPraceStaticRepository pizzaPraceSR = new PizzaPraceStaticRepository();
            PizzaWeightStaticRepository pizzaWeightSR = new PizzaWeightStaticRepository();

            // data initialization
            List<Customer> customers = customerRS.GetAll();
            List<PizzaType> pizzaTypes = pizzaTypeSR.GetAll();
            List<PizzaIngredient> pizzaIngredients = pizzaIngredientSR.GetAll();
            List<PizzaPrice> pizzaPrices = pizzaPraceSR.GetAll();
            List<PizzaWeight> pizzaWeights = pizzaWeightSR.GetAll();

            Customer customer = UserValidator.CustomerValidation(customers, customerRS);
            System.Console.Clear();
            Cart cart = Cart.Instance;


            System.Console.WriteLine($"Здравтсвуйте, {customer.Name}!");
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
