﻿using PizzaDelivery.Models.Pizza.Enums;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Pizza
{
    [DataContract]
    public class PizzaWeight
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string PizzaName { get; set; }
        [DataMember]
        public Dictionary<PizzaSize, int> PizzaWeightToSize { get; set; }
        public PizzaWeight(){}
        public PizzaWeight(string pizzaName, Dictionary<PizzaSize, int> pizzaWeightToSize)
        {
            Id = Guid.NewGuid();

            PizzaWeightToSize = pizzaWeightToSize;
            PizzaName = pizzaName;
        }
    }
}
