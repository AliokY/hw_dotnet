using PizzaDelivery.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models
{
    class ReadyMadePizza
    {
        public Guid Id { get; }
        public string Name { get; private set; }
        public PizzaSizes Size { get; set; }
        private int _weight;
        public int Weight => _weight;
        public Dictionary<string, decimal> AppliedAdditives { get; set; }


        private decimal _finalPrice;

       
    }
}
