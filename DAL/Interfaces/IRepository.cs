using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        List<TEntity> Get(int? filter = null);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int? filter = null);
    }
}