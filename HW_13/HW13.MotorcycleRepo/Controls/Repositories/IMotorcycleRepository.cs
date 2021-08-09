using HW02.MotorcycleRepo.Models;
using System;
using System.Collections.Generic;

namespace HW02.MotorcycleRepo.Controls.Repositories
{
    /// <summary>
    /// Interface for CRUD Repository of T objects
    /// </summary>
    interface IGenericRepository<T> where T : IRepositoryItem
    {
        #region CRUD

        public void Create(T vehicle);
        public IList<T> GetAll();
        public T GetById(Guid id);
        public void Delete(Guid id);
        public void Update(T vehicle);

        #endregion
    }
}
