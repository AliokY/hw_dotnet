using PizzaDelivery.Enums;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Controls
{
    class PizzaConstructor //console
    {
        internal PizzaSizes chosenSize;

        internal DoughTypes chosenDough;


        // todo: make it as extension method
        internal string PizzaChoose()
        {
            var pizzaType = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Выберете пиццу")
                .PageSize(3)
                .MoreChoicesText("[grey](Перемещение с помощью стрелок, выбор - Enter)[/]")
                .AddChoices(new[] { "Маргарита", "Двойной цыплёнок", "Карбонара" }
                ));
            return pizzaType;
        }

        internal void ChooseSize()
        {
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
                    chosenSize = PizzaSizes.Medium;
                    break;
                case "Большая":
                    chosenSize = PizzaSizes.Large;
                    break;
            }
        }

        internal void ChooseDough()
        {
            var stringDough = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .Title("Выберете [green]тип теста")
                .PageSize(2)
                .AddChoices(new[] {"Традиционное", "Тонкое"}
                ));

            switch (stringDough)
            {
                case "Традиционное":
                    chosenDough = DoughTypes.Traditional;
                    break;
                case "Тонкое":
                    chosenDough = DoughTypes.Thin;
                    break;
            }
        }







    }
}
