using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Pizza
{
    [DataContract]
    public class PizzaIngredient
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public List<string> PizzaTypesList { get; set; }
        [DataMember]
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
