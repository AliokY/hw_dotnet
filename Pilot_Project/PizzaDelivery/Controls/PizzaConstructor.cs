using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Pizza.Enums;
using PizzaDelivery.Models.Pizzas;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;

namespace PizzaDelivery.Console.Controls
{
    static class PizzaConstructorConsole
    {
        // todo: make it as extension method (staic class!)
       static internal string PizzaTypeChoose(List<PizzaType> pizzaTypes)
        {
            var pizzaType = AnsiConsole.Prompt(
                  new SelectionPrompt<string>()
                  .Title("Выберете пиццу")
                  .PageSize(pizzaTypes.Count)
                  .MoreChoicesText("[grey](Перемещение с помощью стрелок, выбор - Enter)[/]")
                  .AddChoices(pizzaTypes.Select(_ => _.Name).ToList()));
            return pizzaType;
        }

        static internal void PizzaSizeChoose(out string stringSize, out PizzaSize chosenSize)
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

        static internal decimal GetPizzaPrice(string pizzaType, PizzaSize chosenSize,
             List<PizzaPrice> pizzaPrices)
        {
            PizzaPrice basePrice = pizzaPrices.Find(_ => _.PizzaPriceToSize.Equals(pizzaType));
            decimal pizzaPrice = basePrice.PizzaPriceToSize[chosenSize];
            return pizzaPrice;
        }

        static internal int GetPizzaWeight(string pizzaType, PizzaSize chosenSize,
            List<PizzaWeight> pizzaWeights)
        {
            PizzaWeight baseWeight = pizzaWeights.Find(_ => _.PizzaWeightToSize.Equals(pizzaType));
            int pizzaWeight = baseWeight.PizzaWeightToSize[chosenSize];
            return pizzaWeight;
        }
    }
}
