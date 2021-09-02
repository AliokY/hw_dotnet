using PizzaDelivery.Models;
using PizzaDelivery.Models.Enums;
using Spectre.Console;
using System.Collections.Generic;

namespace PizzaDelivery.Console.Controls
{
    static class PizzaConstructorConsole
    {
        // todo: make it as extension method (staic class!)
       static internal string PizzaTypeChoose(List<string> pizzaTypes)
        {
            var pizzaType = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                  .Title("Выберете пиццу")
                  .PageSize(7)
                  .MoreChoicesText("[grey](Перемещение с помощью стрелок, выбор - Enter)[/]")
                  .AddChoices(pizzaTypes));
            return pizzaType;
        }

        static internal PizzaSizes PizzaSizeChoose()
        {
            PizzaSizes chosenSize = PizzaSizes.Medium;
            var stringSize = AnsiConsole.Prompt(
                     new SelectionPrompt<string>()
                     .Title("Выберете желаемый [green]размер пиццы[/]:")
                     .PageSize(3)
                     .MoreChoicesText("[grey](Перемещение с помощью стрелок, выбор - Enter)[/]")
                     .AddChoices(new[] { "Маленькая", "Средняя", "Большая" }
                     ));

            switch (stringSize)
            {
                case "Маленькая":
                    chosenSize = PizzaSizes.Small;
                    break;
                case "Средняя":
                    break;
                case "Большая":
                    chosenSize = PizzaSizes.Large;
                    break;
            }
            return chosenSize;
        }

        static internal decimal GetPizzaPrice(string pizzaType, PizzaSizes chosenSize)
        {
            decimal pizzaPrice = PizzaTypes.pizzaPrice[pizzaType][chosenSize];
            return pizzaPrice;
        }

        static internal int GetPizzaWeight(string pizzaType, PizzaSizes chosenSize)
        {
            int pizzaWeight = PizzaTypes.pizzaWeight[pizzaType][chosenSize];
            return pizzaWeight;
        }
    }
}
