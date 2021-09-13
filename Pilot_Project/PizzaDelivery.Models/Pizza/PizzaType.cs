using System;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Pizza
{
    [DataContract]
    public class PizzaType
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        public PizzaType(){}
        public PizzaType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}
