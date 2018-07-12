using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
    }
}