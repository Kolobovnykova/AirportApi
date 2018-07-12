using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity: Entity
    {
        TEntity Get(int id);
        
        IEnumerable<TEntity> GetAll();
        
        IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);

        void Create(TEntity entity, string createdBy = null);

        void Update(TEntity entity, string modifiedBy = null);

        void Delete(object id);

        void Delete(TEntity entity);
    }
}
