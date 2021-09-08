using PizzaDelivery.Models.Pizzas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Console.Repositories.CartRep
{
    class CartRepositoryStatic : IRepository<ReadyMadePizza>
    {
        private static List<ReadyMadePizza> _chosenPizzas { get; set; } = new();

        public void Add(ReadyMadePizza rmPizza)
        {
            _chosenPizzas.Add(rmPizza);
        }

        public void Delete(Guid Id)
        {
            _chosenPizzas.RemoveAll(_ => _.Id == Id);
        }

        public List<ReadyMadePizza> GetAll()
        {
            return _chosenPizzas;
        }

        public ReadyMadePizza GetById(Guid Id)
        {
            return _chosenPizzas.Find(_ => _.Id.Equals(Id));
        }

        public void Update(ReadyMadePizza item) // change nomber?
        {
            throw new NotImplementedException();
        }
    }
}
