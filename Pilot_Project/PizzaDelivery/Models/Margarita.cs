using PizzaDelivery.Enums;
using PizzaDelivery.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    class Margarita : BasicPizza
    {
        public override string Name { get; set; } = "Маргарита";
        public override Dictionary<(PizzaSizes, DoughTypes), int> SizeDoughToWeight { get; set; } =
            new Dictionary<(PizzaSizes, DoughTypes), int>
            {
                { (PizzaSizes.Small, DoughTypes.Traditional), 460}, // use constants?
                { (PizzaSizes.Medium, DoughTypes.Traditional), 640},
                { (PizzaSizes.Large, DoughTypes.Traditional), 890},
                { (PizzaSizes.Medium, DoughTypes.Thin), 560},
                { (PizzaSizes.Large, DoughTypes.Thin), 790}
            };

        public override List<string> BasicIngredients { get; set; } = new List<string>()
        {
            "Томатный соус",
            "Моцарелла"
        };

        public override List<string> SelectiveIngredients { get; set; } = new List<string>()
        {
        "Итальянские травы",
        "Томаты"
        };

        public override Dictionary<string, Dictionary<PizzaSizes, decimal>> Additives { get; set; } =
            new Dictionary<string, Dictionary<PizzaSizes, decimal>>
            {
                { "Сырный бортик",
                    new Dictionary<PizzaSizes, decimal>
                    {[PizzaSizes.Medium] = 3.90m,
                     [PizzaSizes.Large] = 4.90m }
                },
                { "Острая чоризо",
                    new Dictionary<PizzaSizes, decimal>
                    {[PizzaSizes.Small] = 2.40m,
                    [PizzaSizes.Medium] = 2.80m,
                    [PizzaSizes.Large] = 3.20m}
                },
                { "Острый халапеньо",
                    new Dictionary<PizzaSizes, decimal>
                    {[PizzaSizes.Small] = 1.80m,
                    [PizzaSizes.Medium] = 2.0m,
                    [PizzaSizes.Large] = 2.40m}
                    },
                { "Брынза",
                    new Dictionary<PizzaSizes, decimal>
                    {[PizzaSizes.Small] = 2.40m,
                    [PizzaSizes.Medium] = 2.80m,
                    [PizzaSizes.Large] = 3.20m }
                },
                { "Острый цыплёнок",
                new Dictionary<PizzaSizes, decimal>
                    {[PizzaSizes.Small] = 2.40m,
                    [PizzaSizes.Medium] = 2.80m,
                    [PizzaSizes.Large] = 3.20m }
                },
            };


    }
}
