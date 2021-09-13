using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep
{
    class PizzaTypeStaticRepository : IRepository<PizzaType>
    {
        public static List<PizzaType> _pizzaTypes = new()
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
