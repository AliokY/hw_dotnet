using PizzaDelivery.Models.CartInfo;
using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Pizza.Enums;
using PizzaDelivery.Models.Pizza.Exceptions;
using PizzaDelivery.Models.Pizzas;
using Spectre.Console;
using System;
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
                // user picks a pizza or construct it from ingridients
                PickPizza(pizzaTypes, pizzaIngredients, pizzaPrices, pizzaWeights);

                // moving the picked pizza to cart
                IndicateNumberOfPizzas(_pickedPizza, cart);

                System.Console.Clear();

                // user selects a menu point
                bool orderStatus = ContinueOrder("Перейти к корзине");
                if (orderStatus)
                {
                    // if user goes to the cart - display it
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

            // while-true - cycle is used to handle the console UI the user interact with
            while (true)
            {
                // user picks a pizza type
                pickedPizzaType = PizzaTypeChoose(pizzaTypes);

                System.Console.Clear();

                ShowPizzaIngredients(pickedPizzaType, pizzaIngredients);

                bool pizzaStatus = ContinueOrder("Продолжить");
                if (!pizzaStatus)
                {
                    System.Console.Clear();
                    continue;
                }

                // user pick a pizza size
                PizzaSizeChoose(out string stringSize, out PizzaSize chosenSize);
                pickedPizzaSize = stringSize;

                // calculating the price and weight based on choosen type and size
                pickedPizzaPrice = GetPizzaPrice(pickedPizzaType, chosenSize, pizzaPrices);
                pickedPizzaWeight = GetPizzaWeight(pickedPizzaType, chosenSize, pizzaWeights);

                System.Console.WriteLine($"Вес пиццы: {pickedPizzaWeight} г, цена: {pickedPizzaPrice} руб.");

                pizzaStatus = ContinueOrder("Изменить количество и/или добавить пиццу в корзину");

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
                  .Title("Выберите пиццу")
                  .PageSize(pizzaTypes.Count)
                  .AddChoices(pizzaTypes.Select(_ => _.Name).ToList()));
            return pizzaType;
        }

        internal static void ShowPizzaIngredients(string pizzaType, List<PizzaIngredient> pizzaIngredients)
        {
            List<PizzaIngredient> pickedPizzaIngredients = pizzaIngredients.Where(_ => _.PizzaTypesList.Contains(pizzaType)).ToList();

            System.Console.WriteLine($"{pizzaType.ToUpper()} - ингредиенты:");
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
            foreach (var item in cart.Items)
            {
                System.Console.WriteLine($"{item.Name}. {item.Size}. " +
                    $"Количесво: {item.Count} шт, {item.LineSum} руб.");
            }

            System.Console.WriteLine();
            System.Console.WriteLine($"Сумма заказа: {cart.TotalSum} руб.");
            System.Console.WriteLine();
        }

        internal static CartStatus ProceedToCheckout()
        {
            CartStatus cartStatus = CartStatus.Checkout;
            var cartStatusStr = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(3)
                .AddChoices(new[]
                {
                   "Оформить заказ",
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

        internal static void IndicateNumberOfPizzas(PickedPizza pickedPizza, Cart cart)
        {
            System.Console.WriteLine("Укажите количество пицц:");
            int pizzasNumber = 1;
            int pizzasNumberLimit = 20;
            do
            {
                try
                {
                    pizzasNumber = Int32.Parse(System.Console.ReadLine());
                    if (pizzasNumberLimit < pizzasNumber)
                    {
                        throw new PizzaCountException("В настоящий момент максимально возможное " +
                            "количество пицц для заказа равно 20 шт.");
                    }
                    if (pizzasNumber <= 0)
                    {
                        throw new PizzaCountException("Введите корректное число.");
                    }

                    break;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Количество необходимо указать в числовом формате.");
                    continue;
                }
                catch (PizzaCountException pce)
                {
                    System.Console.WriteLine(pce.Message);

                    continue;
                }
            }
            while (true);

            for (int i = 1; i <= pizzasNumber; i++)
            {
                cart.PickedPizza.Add(pickedPizza);
            }
        }
    }
}
