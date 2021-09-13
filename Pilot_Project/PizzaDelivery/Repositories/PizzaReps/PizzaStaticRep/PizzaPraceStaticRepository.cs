using PizzaDelivery.Models.Pizza;
using System;
using System.Collections.Generic;
using PizzaDelivery.Models.Pizza.Enums;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Console.Repositories.PizzaReps.PizzaStaticRep
{
    class PizzaPraceStaticRepository : IRepository<PizzaPrice>
    {
        private static List<PizzaPrice> _pizzaPricesToSize = new()
        {
            new PizzaPrice("Карбонара",
                new Dictionary<PizzaSize, decimal>
                {
                    [PizzaSize.Small] = 14.90m,
                    [PizzaSize.Medium] = 21.90m,
                    [PizzaSize.Large] = 25.90m
                }),
            new PizzaPrice("Маргарита",
                new Dictionary<PizzaSize, decimal>
                {
                    [PizzaSize.Small] = 5.90m,
                    [PizzaSize.Medium] = 13.90m,
                    [PizzaSize.Large] = 18.90m
                }),
            new PizzaPrice("Двойной цыплёнок",
                new Dictionary<PizzaSize, decimal>
                {
                    [PizzaSize.Small] = 10.90m,
                    [PizzaSize.Medium] = 18.90m,
                    [PizzaSize.Large] = 23.90m
                }),
            new PizzaPrice("Колбаски барбекю",
                new Dictionary<PizzaSize, decimal>
                {
                    [PizzaSize.Small] = 14.90m,
                    [PizzaSize.Medium] = 21.90m,
                    [PizzaSize.Large] = 25.90m
                }),
            new PizzaPrice("Нежный лосось",
                new Dictionary<PizzaSize, decimal>
                {
                    [PizzaSize.Small] = 19.90m,
                    [PizzaSize.Medium] = 26.90m,
                    [PizzaSize.Large] = 29.90m
                }),
            new PizzaPrice("Сырная",
                new Dictionary<PizzaSize, decimal>
                {
                    [PizzaSize.Small] = 5.90m,
                    [PizzaSize.Medium] = 13.90m,
                    [PizzaSize.Large] = 18.90m
                }),
            new PizzaPrice("Ветчина и сыр", 
                new Dictionary<PizzaSize, decimal>
                {
                    [PizzaSize.Small] = 5.90m,
                    [PizzaSize.Medium] = 13.90m,
                    [PizzaSize.Large] = 18.90m
                })
            };

        public void Add(PizzaPrice pizzaPrice)
        {
            _pizzaPricesToSize.Add(pizzaPrice);
        }

        public void Delete(Guid id)
        {
            _pizzaPricesToSize.RemoveAll(_ => _.Id == id);
        }

        public List<PizzaPrice> GetAll()
        {
            return _pizzaPricesToSize;
        }

        public PizzaPrice GetById(Guid id)
        {
            return _pizzaPricesToSize.Find(_ => _.Id.Equals(id));
        }

        public void Update(PizzaPrice pizzaPrice)
        {
            PizzaPrice updatePrice = GetById(pizzaPrice.Id);

            if (updatePrice != null)
            {
                updatePrice.PizzaPriceToSize = pizzaPrice.PizzaPriceToSize;
            }
            else 
            {
                throw new Exception("Такой цены не существует!");
            }
        }
    }
}
