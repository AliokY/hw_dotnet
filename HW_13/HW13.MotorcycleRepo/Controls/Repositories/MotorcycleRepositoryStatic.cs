using HW02.MotorcycleRepo.Controls.Repositories;
using System;
using System.Collections.Generic;

namespace HW02.MotorcycleRepo
{
    class GenericRepository<T> : IGenericRepository<T> where T : IRepositoryItem
    {
        private static IList<T> _vehicles = new List<T>(6);

        public IList<T> GetAll()
        {
            return _vehicles;
        }

        public T GetById(Guid id)
        {
            T requiredItem = default(T);

            foreach (var item in _vehicles)
            {
                if (item.Id == id)
                {
                    requiredItem = item;
                    break;
                }
            }
            return requiredItem;
        }

        public void Delete(Guid id)
        {
            foreach (var item in _vehicles)
            {
                if (item.Id == id)
                {
                    _vehicles.Remove(item);
                    break;
                }
            }
        }

        public void Update(T vehicle)
        {
            T requiredItem = GetById(vehicle.Id);

            if (requiredItem != null)
            {
                requiredItem = vehicle;
            }
        }

        public void Create(T vehicle)
        {
            _vehicles.Add(vehicle);
        }
    }
}
