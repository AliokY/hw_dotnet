﻿using PizzaDelivery.Console.Controls;
using PizzaDelivery.Console.Repositories.OrderReps;
using PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep;
using PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep;
using PizzaDelivery.Console.Repositories.UsersPeps;
using PizzaDelivery.Models.CartInfo;
using PizzaDelivery.Models.Orders;
using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Users;
using System.Collections.Generic;

namespace PizzaDelivery.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            //service / repository static registration
            CustomerRepositoryStatic customerRep1 = new CustomerRepositoryStatic();
            PizzaTypeStaticRepository pizzaTypeRep1 = new PizzaTypeStaticRepository();
            PizzaIngredientStaticRepository pizzaIngredientRep1 = new PizzaIngredientStaticRepository();
            PizzaPraceStaticRepository pizzaPriceRep1 = new PizzaPraceStaticRepository();
            PizzaWeightStaticRepository pizzaWeightRep1 = new PizzaWeightStaticRepository();
            OrderStaticRepository orderRep1 = new OrderStaticRepository();

            // service/repository json registration
            CustomerJsonRepository customerRep = new CustomerJsonRepository();
            PizzaTypeJsonRepository pizzaTypeRep = new PizzaTypeJsonRepository();
            PizzaIngredientJsonRepository pizzaIngredientRep = new PizzaIngredientJsonRepository();
            PizzaPriceJsonRepository pizzaPriceRep = new PizzaPriceJsonRepository();
            PizzaWeightJsonRepository pizzaWeightRep = new PizzaWeightJsonRepository();
            OrderJsonRepository orderRep = new OrderJsonRepository();

            // data initialization 
            //List<Customer> customers = customerRep.GetAll();
            //List<PizzaType> pizzaTypes = pizzaTypeRep.GetAll();
            //List<PizzaIngredient> pizzaIngredients = pizzaIngredientRep.GetAll();
            //List<PizzaPrice> pizzaPrices = pizzaPriceRep.GetAll();
            //List<PizzaWeight> pizzaWeights = pizzaWeightRep.GetAll();



            // app launch 
            FillJsonFile(//customerRep,
             pizzaTypeRep,
             pizzaIngredientRep,
             pizzaPriceRep,
             pizzaWeightRep,
            // CustomerRepositoryStatic._userList,
             PizzaTypeStaticRepository._pizzaTypes,
             PizzaIngredientStaticRepository._pizzaIngredients,
             PizzaPraceStaticRepository._pizzaPricesToSize,
             PizzaWeightStaticRepository._pizzaWeight);


           //Customer customer = UserValidatorConsole.CustomerValidation(customers, customerRep);
           //System.Console.Clear();
           //Cart cart = Cart.Instance;

           //System.Console.WriteLine($"Здравтсвуйте, {customer.Name}!");
           //PizzaPickerConsole.FillCart(cart, pizzaTypes, pizzaIngredients,
           //pizzaPrices, pizzaWeights);

           //string streetName = UserValidatorConsole.ChooseDeliverAdress(customer, customerRep);
           //Order order = new Order(customer.Id, cart, streetName);
           //OrderPerformerConsole.Checkout(orderRep, order);

           System.Console.ReadLine();
        }



        static void FillJsonFile(
            // CustomerJsonRepository customerRep,
             PizzaTypeJsonRepository pizzaTypeRep,
             PizzaIngredientJsonRepository pizzaIngredientRep,
             PizzaPriceJsonRepository pizzaPriceRep,
             PizzaWeightJsonRepository pizzaWeightRep,

            // List<Customer> _userList,
             List<PizzaType> _pizzaTypes,
             List<PizzaIngredient> _pizzaIngredients,
             List<PizzaPrice> _pizzaPricesToSize,
             List<PizzaWeight> _pizzaWeight)
        {
            //foreach (var item in _userList)
            //{
            //    customerRep.Add(item);
            //}

            foreach (var item in _pizzaTypes)
            {
                pizzaTypeRep.Add(item);
            }

            foreach (var item in _pizzaIngredients)
            {
                pizzaIngredientRep.Add(item);
            }
            foreach (var item in _pizzaPricesToSize)
            {
                pizzaPriceRep.Add(item);
            }

            foreach (var item in _pizzaWeight)
            {
                pizzaWeightRep.Add(item);
            }
        }

    }
}
