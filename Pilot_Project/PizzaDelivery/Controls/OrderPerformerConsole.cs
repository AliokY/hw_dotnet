using PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep;
using PizzaDelivery.Models.Orders;
using Spectre.Console;

namespace PizzaDelivery.Console.Controls
{
    static class OrderPerformerConsole
    {
        // confirmation of an order. Displaying complete information about the order
        public static void Checkout(OrderJsonRepository orderRep, Order order)
        {
            ShowOrder(order);

            bool userChoice = Confirm();
            if (userChoice)
            {
                orderRep.Add(order);
                System.Console.WriteLine("Заказ принят!");
                System.Console.WriteLine($"Вашу пиццу доставят до: {order.DeliveryTime}!");
            }
        }
         
        private static void ShowOrder(Order order)
        {
            PizzaPickerConsole.ShowCart(order.CurrentCart);
            System.Console.WriteLine($"Время заказа: {order.OrderTime}");
            System.Console.WriteLine();
            System.Console.WriteLine($"Адрес доставки: {order.DeliveryAddress}");
            System.Console.WriteLine();
        }

        // confirm or cancel the order
        private static bool Confirm() 
        {
            string checkout = "Оформить заказ";
            string leaveApp = "Выйти без оформления";

            string userChoiseStr = AnsiConsole.Prompt(
                           new SelectionPrompt<string>()
                           .PageSize(3)
                           .AddChoices(new[] { checkout, leaveApp }
                           ));

            bool userChoice = userChoiseStr.Equals(checkout);
            return userChoice;
        }
    }
}
