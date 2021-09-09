using PizzaDelivery.Models.Cart;
using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Pizza.Enums;
using PizzaDelivery.Models.Pizzas;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.Console.Controls
{
    static class PizzaPickerConsole
    {
        private static PickedPizza _pickedPizza;

        internal static void FillCart(Cart cart, List<PizzaType> pizzaTypes, List<PizzaIngredient> pizzaIngredients,
            List<PizzaPrice> pizzaPrices, List<PizzaWeight> pizzaWeights)
        {
            while (true)
            {
                PickPizza(pizzaTypes, pizzaIngredients, pizzaPrices, pizzaWeights);
                cart.PickedPizza.Add(_pickedPizza);

                bool orderStatus = ContinueOrder("Перейти к корзине");
                if (orderStatus)
                {
                    ShowCart(cart);
                    CartStatus cartStatus = ProceedToCheckout();
                    if (cartStatus == CartStatus.Checkout)
                    {
                        break;
                    }
                    else if (cartStatus == CartStatus.EmptyCart)
                    {
                        cart.EmptyCart();
                        System.Console.Clear();

                        continue;
                    }
                }
                else
                {
                    continue;
                }
            }
        }

        internal static void PickPizza(List<PizzaType> pizzaTypes, List<PizzaIngredient> pizzaIngredients,
                   List<PizzaPrice> pizzaPrices, List<PizzaWeight> pizzaWeights)
        {
            string pickedPizzaType;
            string pickedPizzaSize;
            decimal pickedPizzaPrice;
            int pickedPizzaWeight;

            while (true)
            {
                pickedPizzaType = PizzaTypeChoose(pizzaTypes);
                ShowPizzaIngredients(pickedPizzaType, pizzaIngredients);

                bool pizzaStatus = ContinueOrder("Продолжить");
                if (!pizzaStatus)
                {
                    System.Console.Clear();
                    continue;
                }
                PizzaSizeChoose(out string stringSize, out PizzaSize chosenSize);
                pickedPizzaSize = stringSize;

                pickedPizzaPrice = GetPizzaPrice(pickedPizzaType, chosenSize, pizzaPrices);
                pickedPizzaWeight = GetPizzaWeight(pickedPizzaType, chosenSize, pizzaWeights);

                System.Console.WriteLine($"Вес пиццы: {pickedPizzaWeight} г, цена: {pickedPizzaPrice} руб.");

                pizzaStatus = ContinueOrder("Добавить пиццу в корзину");

                if (pizzaStatus) break;

                System.Console.Clear();
            }
            _pickedPizza = new PickedPizza(pickedPizzaType, pickedPizzaSize,
                pickedPizzaPrice, pickedPizzaWeight);
        }

        internal static string PizzaTypeChoose(List<PizzaType> pizzaTypes)
        {
            var pizzaType = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                  .Title("Выберете пиццу")
                  .PageSize(pizzaTypes.Count)
                  .MoreChoicesText("[grey](Перемещение с помощью стрелок, выбор - Enter)[/]")
                  .AddChoices(pizzaTypes.Select(_ => _.Name).ToList()));
            return pizzaType;
        }

        internal static void ShowPizzaIngredients(string pizzaType, List<PizzaIngredient> pizzaIngredients)
        {
            List<PizzaIngredient> pickedPizzaIngredients = pizzaIngredients.Where(_ => _.PizzaTypesList.Contains(pizzaType)).ToList();

            System.Console.WriteLine($"Пицца-{pizzaType}. Ингредиенты:");
            foreach (var item in pickedPizzaIngredients)
            {
                System.Console.WriteLine(item.Name);
            }
            System.Console.WriteLine();
        }

        internal static bool ContinueOrder(string nextStep)
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

        internal static void PizzaSizeChoose(out string stringSize, out PizzaSize chosenSize)
        {
            chosenSize = PizzaSize.Medium;
            stringSize = AnsiConsole.Prompt(
                     new SelectionPrompt<string>()
                     .Title("Выберете желаемый [green]размер пиццы[/]:")
                     .PageSize(3)
                     .MoreChoicesText("[grey](Перемещение с помощью стрелок, выбор - Enter)[/]")
                     .AddChoices(new[] { "Маленькая", "Средняя", "Большая" }
                     ));

            switch (stringSize)
            {
                case "Маленькая":
                    chosenSize = PizzaSize.Small;
                    break;
                case "Средняя":
                    break;
                case "Большая":
                    chosenSize = PizzaSize.Large;
                    break;
            }
        }

        internal static decimal GetPizzaPrice(string pizzaType, PizzaSize chosenSize,
             List<PizzaPrice> pizzaPrices)
        {
            PizzaPrice basePrice = pizzaPrices.Find(_ => _.PizzaName.Equals(pizzaType));
            decimal pizzaPrice = basePrice.PizzaPriceToSize[chosenSize];
            return pizzaPrice;
        }

        internal static int GetPizzaWeight(string pizzaType, PizzaSize chosenSize,
            List<PizzaWeight> pizzaWeights)
        {
            PizzaWeight baseWeight = pizzaWeights.Find(_ => _.PizzaName.Equals(pizzaType));
            int pizzaWeight = baseWeight.PizzaWeightToSize[chosenSize];
            return pizzaWeight;
        }

        internal static void ShowCart(Cart cart)
        {
            if (cart.PickedPizza.Count != 0)
            {
                foreach (var item in cart.Items)
                {
                    System.Console.WriteLine($"{item.Name} - {item.Count} шт, {item.LineSum} руб.");
                }
                System.Console.WriteLine();
            }
            else { System.Console.WriteLine("Корзина пуста."); }
        }

        internal static CartStatus ProceedToCheckout()
        {
            CartStatus cartStatus = CartStatus.Checkout;
            var cartStatusStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(3)
                .AddChoices(new[]
                {
                   "Перейти к оформлению заказа",
                   "Очистить корзину",
                    "Вернуться к выбору"
                }));

            if (Equals(cartStatusStr, "Очистить корзину"))
            {
                cartStatus = CartStatus.EmptyCart;
            }
            else if (Equals(cartStatusStr, "Вернуться к выбору"))
            {
                cartStatus = CartStatus.ReturnToPick;
            }
            return cartStatus;
        }
    }
}
