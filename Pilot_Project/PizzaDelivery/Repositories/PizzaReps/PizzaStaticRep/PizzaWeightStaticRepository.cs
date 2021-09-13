using PizzaDelivery.Models.Pizza;
using PizzaDelivery.Models.Pizza.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep
{
    class PizzaWeightStaticRepository : IRepository<PizzaWeight>
    {
        public static List<PizzaWeight> _pizzaWeight = new()
        {
            new PizzaWeight("Карбонара",
                 new Dictionary<PizzaSize, int>
                 {
                     [PizzaSize.Small] = 420,
                     [PizzaSize.Medium] = 620,
                     [PizzaSize.Large] = 840
                 }),
            new PizzaWeight("Маргарита",
                new Dictionary<PizzaSize, int>
                {
                    [PizzaSize.Small] = 460,
                    [PizzaSize.Medium] = 640,
                    [PizzaSize.Large] = 890
                }),
            new PizzaWeight("Двойной цыплёнок",
                new Dictionary<PizzaSize, int>
                {
                    [PizzaSize.Small] = 360,
                    [PizzaSize.Medium] = 520,
                    [PizzaSize.Large] = 710
                }),
            new PizzaWeight("Колбаски барбекю",
                new Dictionary<PizzaSize, int>
                {
                    [PizzaSize.Small] = 330,
                    [PizzaSize.Medium] = 480,
                    [PizzaSize.Large] = 630
                }),
            new PizzaWeight("Нежный лосось",
                new Dictionary<PizzaSize, int>
                {
                    [PizzaSize.Small] = 430,
                    [PizzaSize.Medium] = 650,
                    [PizzaSize.Large] = 880
                }),
            new PizzaWeight("Сырная",
                new Dictionary<PizzaSize, int>
                {
                    [PizzaSize.Small] = 360,
                    [PizzaSize.Medium] = 540,
                    [PizzaSize.Large] = 710
                }),
            new PizzaWeight("Ветчина и сыр",
                new Dictionary<PizzaSize, int>
                {
                    [PizzaSize.Small] = 345,
                    [PizzaSize.Medium] = 480,
                    [PizzaSize.Large] = 690
                }
                )
        };

        public void Add(PizzaWeight pizzaWeight)
        {
            _pizzaWeight.Add(pizzaWeight);
        }

        public void Delete(Guid Id)
        {
            _pizzaWeight.RemoveAll(_ => _.Id == Id);
        }

        public List<PizzaWeight> GetAll()
        {
            return _pizzaWeight;
        }

        public PizzaWeight GetById(Guid Id)
        {
            return _pizzaWeight.Find(_ => _.Id.Equals(Id));
        }

        public void Update(PizzaWeight pizzaWeight)
        {
            PizzaWeight updateWeight = GetById(pizzaWeight.Id);

            if (updateWeight != null)
            {
                updateWeight.PizzaWeightToSize = pizzaWeight.PizzaWeightToSize;
            }
            else
            {
                throw new Exception("Такой массы не существует!");
            }
        }
    }
}
