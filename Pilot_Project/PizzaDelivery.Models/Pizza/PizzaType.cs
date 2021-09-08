using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Pizza
{
   public class PizzaType
    {
        public Guid Id { get; }
        public string Name { get; set; }
        public PizzaType(){}
        public PizzaType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
