using PizzaDelivery.Console.Controls;
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
            CustomerRepositoryStatic customerRep = new CustomerRepositoryStatic();
            PizzaTypeStaticRepository pizzaTypeRep = new PizzaTypeStaticRepository();
            PizzaIngredientStaticRepository pizzaIngredientRep = new PizzaIngredientStaticRepository();
            PizzaPraceStaticRepository pizzaPriceRep = new PizzaPraceStaticRepository();
            PizzaWeightStaticRepository pizzaWeightRep = new PizzaWeightStaticRepository();
            OrderStaticRepository orderRep = new OrderStaticRepository();

            // service/repository json registration
           // CustomerJsonRepository customerRep = new CustomerJsonRepository();
           // PizzaTypeJsonRepository pizzaTypeRep = new PizzaTypeJsonRepository();
           // PizzaIngredientJsonRepository pizzaIngredientRep = new PizzaIngredientJsonRepository();
           // PizzaPriceJsonRepository pizzaPriceRep = new PizzaPriceJsonRepository();
           // PizzaWeightJsonRepository pizzaWeightRep = new PizzaWeightJsonRepository();
           // OrderJsonRepository orderRep = new OrderJsonRepository();

            // data initialization 
            List<Customer> customers = customerRep.GetAll();
            List<PizzaType> pizzaTypes = pizzaTypeRep.GetAll();
            List<PizzaIngredient> pizzaIngredients = pizzaIngredientRep.GetAll();
            List<PizzaPrice> pizzaPrices = pizzaPriceRep.GetAll();
            List<PizzaWeight> pizzaWeights = pizzaWeightRep.GetAll();



            // app launch 
            Customer customer = UserValidatorConsole.CustomerValidation(customers, customerRep);
            System.Console.Clear();
            Cart cart = Cart.Instance;

            System.Console.WriteLine($"Здравтсвуйте, {customer.Name}!");
            PizzaPickerConsole.FillCart(cart, pizzaTypes, pizzaIngredients,
            pizzaPrices, pizzaWeights);

            string streetName = UserValidatorConsole.ChooseDeliverAdress(customer, customerRep);
            Order order = new Order(customer.Id, cart, streetName);
            OrderPerformerConsole.Checkout(orderRep, order);

            System.Console.ReadLine();
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
