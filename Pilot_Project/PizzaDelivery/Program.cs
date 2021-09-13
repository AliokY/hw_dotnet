using PizzaDelivery.Console.Controls;
using PizzaDelivery.Console.Repositories.OrderReps;
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
            // service/repository static registration
            CustomerRepositoryStatic customerRS = new CustomerRepositoryStatic();
            PizzaTypeStaticRepository pizzaTypeSR = new PizzaTypeStaticRepository();
            PizzaIngredientStaticRepository pizzaIngredientSR = new PizzaIngredientStaticRepository();
            PizzaPraceStaticRepository pizzaPraceSR = new PizzaPraceStaticRepository();
            PizzaWeightStaticRepository pizzaWeightSR = new PizzaWeightStaticRepository();
            OrderStaticRepository orderSR = new OrderStaticRepository();

            // data initialization (static)
            List<Customer> customers = customerRS.GetAll();
            List<PizzaType> pizzaTypes = pizzaTypeSR.GetAll();
            List<PizzaIngredient> pizzaIngredients = pizzaIngredientSR.GetAll();
            List<PizzaPrice> pizzaPrices = pizzaPraceSR.GetAll();
            List<PizzaWeight> pizzaWeights = pizzaWeightSR.GetAll();




            Customer customer = UserValidatorConsole.CustomerValidation(customers, customerRS);
            System.Console.Clear();
            Cart cart = Cart.Instance;

            System.Console.WriteLine($"Здравтсвуйте, {customer.Name}!");
            PizzaPickerConsole.FillCart(cart, pizzaTypes, pizzaIngredients,
            pizzaPrices, pizzaWeights);

            string streetName = UserValidatorConsole.ChooseDeliverAdress(customer, customerRS);
            Order order = new Order(customer.Id, cart, streetName);
            OrderPerformerConsole.Checkout(orderSR, order);

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
