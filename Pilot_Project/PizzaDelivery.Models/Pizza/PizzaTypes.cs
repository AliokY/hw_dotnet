//using PizzaDelivery.Models.Pizzas.Enums;
//using System.Collections.Generic;

//namespace PizzaDelivery.Models
//{
//    public static class PizzaTypes
//    {
//        // use PascalCase for public elements
//        public static List<string> Pizza_Types { get; } = new List<string>() {
//        "Карбонара",
//        "Маргарита",
//        "Двойной цыплёнок",
//        "Колбаски барбекю",
//        "Нежный лосось",
//        "Сырная",
//        "Ветчина и сыр"
//        };

//        public static Dictionary<string, List<string>> Ingredients { get; }
//            = new Dictionary<string, List<string>>
//            {
//                {"Карбонара",
//                    new List<string>
//                    {"бекон",
//                    "сыры чеддер и пармезан",
//                    "моцарелла",
//                    "томаты",
//                    "соус альфреддо",
//                    "красный лук", 
//                    "чеснок",
//                    "итальянские травы"}
//                },
//                {"Маргарита",
//                    new List<string>
//                    {"Итальянские травы",
//                    "томатный соус",
//                    "томаты",
//                    "моцарелла"}
//                },
//                {"Двойной цыплёнок",
//                    new List<string>
//                    {"Цыплёнок",
//                     "моцарелла",
//                     "соус альфреддо"}
//                },
//                {"Колбаски барбекю",
//                    new List<string>
//                    {"Острые колбаски чоризо",
//                    "соус барбекю",
//                    "томаты",
//                    "красный лук",
//                    "моцарелла",
//                    "томатный соус"}
//                },
//                {"Нежный лосось",
//                    new List<string>
//                    {"Лосось",
//                    "томаты",
//                    "соус песто",
//                    "моцарелла",
//                    "соус альфреддо"}
//                },
//                {"Сырная",
//                    new List<string>
//                    {"Моцарелла",
//                    "сыры чеддер и пармезан",
//                    "соус альфреддо"}
//                },
//                {"Ветчина и сыр",
//                    new List<string>
//                    {"Моцарелла",
//                    "ветчина",
//                    "соус альфреддо"}
//                }
//            };

//        public static Dictionary<string, Dictionary<PizzaSizes, decimal>> PizzaPrice { get; } =
//        new Dictionary<string, Dictionary<PizzaSizes, decimal>>
//            {
//                {
//                    "Карбонара",
//                    new Dictionary<PizzaSizes, decimal>
//                    {
//                        [PizzaSizes.Small]= 14.90m,
//                    [PizzaSizes.Medium] = 21.90m,
//                    [PizzaSizes.Large] = 25.90m
//                    }
//                },
//                {"Маргарита",
//                new Dictionary<PizzaSizes, decimal>
//                {[PizzaSizes.Small]= 5.90m,
//                [PizzaSizes.Medium] = 13.90m,
//                [PizzaSizes.Large] = 18.90m}
//                },
//                {"Двойной цыплёнок",
//                new Dictionary<PizzaSizes, decimal>
//                {[PizzaSizes.Small]= 10.90m,
//                [PizzaSizes.Medium] = 18.90m,
//                [PizzaSizes.Large] = 23.90m}
//                },
//                {"Колбаски барбекю",
//                new Dictionary<PizzaSizes, decimal>
//                {[PizzaSizes.Small]= 14.90m,
//                [PizzaSizes.Medium] = 21.90m,
//                [PizzaSizes.Large] = 25.90m}
//                },
//                {"Нежный лосось",
//                new Dictionary<PizzaSizes, decimal>
//                {[PizzaSizes.Small]= 19.90m,
//                [PizzaSizes.Medium] = 26.90m,
//                [PizzaSizes.Large] = 29.90m}
//                },
//                {"Сырная",
//                new Dictionary<PizzaSizes, decimal>
//                {[PizzaSizes.Small]= 5.90m,
//                [PizzaSizes.Medium] = 13.90m,
//                [PizzaSizes.Large] = 18.90m}
//                },
//                {"Ветчина и сыр",
//                new Dictionary<PizzaSizes, decimal>
//                {[PizzaSizes.Small]= 5.90m,
//                [PizzaSizes.Medium] = 13.90m,
//                [PizzaSizes.Large] = 18.90m}
//                }
//            };

//        public static Dictionary<string, Dictionary<PizzaSizes, int>> PizzaWeight { get; } =
//       new Dictionary<string, Dictionary<PizzaSizes, int>>
//           {
//                {"Карбонара",
//                new Dictionary<PizzaSizes, int>
//                {[PizzaSizes.Small]= 420,
//                [PizzaSizes.Medium] = 620,
//                [PizzaSizes.Large] = 840}
//                },
//                {"Маргарита",
//                new Dictionary<PizzaSizes, int>
//                {[PizzaSizes.Small]= 460,
//                [PizzaSizes.Medium] = 640,
//                [PizzaSizes.Large] = 890}
//                },
//                {"Двойной цыплёнок",
//                new Dictionary<PizzaSizes, int>
//                {[PizzaSizes.Small]= 360,
//                [PizzaSizes.Medium] = 520,
//                [PizzaSizes.Large] = 710}
//                },
//                {"Колбаски барбекю",
//                new Dictionary<PizzaSizes, int>
//                {[PizzaSizes.Small]= 330,
//                [PizzaSizes.Medium] = 480,
//                [PizzaSizes.Large] = 630}
//                },
//                {"Нежный лосось",
//                new Dictionary<PizzaSizes, int>
//                {[PizzaSizes.Small]= 430,
//                [PizzaSizes.Medium] = 650,
//                [PizzaSizes.Large] = 880}
//                },
//                {"Сырная",
//                new Dictionary<PizzaSizes, int>
//                {[PizzaSizes.Small]= 360,
//                [PizzaSizes.Medium] = 540,
//                [PizzaSizes.Large] = 710}
//                },
//                {"Ветчина и сыр",
//                new Dictionary<PizzaSizes, int>
//                {[PizzaSizes.Small]= 345,
//                [PizzaSizes.Medium] = 480,
//                [PizzaSizes.Large] = 690}
//                }
//           };
//    }
//}
