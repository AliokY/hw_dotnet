using PizzaDelivery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Abstract
{
    abstract class BasicPizza
    {
        public Guid Id { get; }
        public abstract string Name { get; set; }
        public PizzaSizes Size { get; set; } = PizzaSizes.Medium;

        private int _weight;
        public int Weight => _weight;
        public Dictionary<PizzaSizes, decimal> SizeMarkups { get; set; }
        public DoughTypes Dough { get; set; } = DoughTypes.Traditional;
        public (PizzaSizes, DoughTypes) ToWeightKey { get; set; }
        abstract public Dictionary<(PizzaSizes, DoughTypes), int> SizeDoughToWeight { get; set; }
        public abstract List<string> BasicIngredients { get; set; }
        public abstract List<string> SelectiveIngredients { get; set; }
        public List<string> AppliedSelectiveIngredients { get; set; }
        public abstract Dictionary<string, Dictionary<PizzaSizes, decimal>> Additives { get; set; }
        public Dictionary<string, decimal> AppliedAdditives { get; set; }
        public decimal BasePrice { get; private set; }

        private decimal _finalPrice;

        public decimal FinalPrice => _finalPrice;

        public void CalculateFinalPrice()
        {
            decimal additivesMurkup = 0;
            foreach (var additive in AppliedAdditives)
            {
                additivesMurkup += additive.Value;
            }

            decimal sizeMarkup = SizeMarkups[Size];

            _finalPrice = BasePrice + additivesMurkup + sizeMarkup;
        }

        public void CalculateWeight()
        {
            _weight = SizeDoughToWeight[(Size, Dough)];
        }
    }
}

