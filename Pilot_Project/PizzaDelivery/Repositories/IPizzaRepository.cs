using System;
using System.Collections.Generic;

namespace PizzaDelivery.Console.Repositories
{
    /// <summary>
    /// Interface for CRUD Repository
    /// </summary>
    interface IRepository<T> where T : class
    {
        public void Add(T item);
        public IList<T> GetAll();
        public T GetById(Guid Id);
        public void Delete(Guid Id);
        public void Update(T item);
    }
}
