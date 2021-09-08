using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Pizza
{
    public class PizzaIngredient
    {
        public Guid Id { get; set; }
        public List<string> PizzaTypesList { get; set; }
        public string Name { get; set; }
        public PizzaIngredient(){}

        public PizzaIngredient(string name, List<string> types)
        {
            Id = Guid.NewGuid();

            Name = name;
            PizzaTypesList = new List<string>();
            PizzaTypesList.AddRange(types);
        }
    }
}
