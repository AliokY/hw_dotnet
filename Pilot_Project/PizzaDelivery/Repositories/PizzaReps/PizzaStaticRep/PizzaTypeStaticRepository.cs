﻿using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep
{
    class PizzaTypeStaticRepository : IRepository<PizzaType>
    {
        private static List<PizzaType> _pizzaTypes = new()
        {
            new PizzaType("Карбонара"),
            new PizzaType("Маргарита"),
            new PizzaType("Двойной цыплёнок"),
            new PizzaType("Колбаски барбекю"),
            new PizzaType("Нежный лосось"),
            new PizzaType("Сырная"),
            new PizzaType("Ветчина и сыр")
        };
        public void Add(PizzaType type)
        {
            _pizzaTypes.Add(type);
        }

        public void Delete(Guid Id)
        {
            _pizzaTypes.RemoveAll(_ => _.Id == Id);
        }

        public List<PizzaType> GetAll()
        {
            return _pizzaTypes;
        }

        public PizzaType GetById(Guid Id)
        {
            return _pizzaTypes.Find(_ => _.Id.Equals(Id));
        }

        public void Update(PizzaType type)
        {
            PizzaType updatedType = GetById(type.Id);

            if (updatedType != null)
            {
                updatedType.Name = type.Name;
            }
            else 
            {
                throw new Exception("Такой пиццы не существует!");
            }
        }
    }
}