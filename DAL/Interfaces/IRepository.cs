using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        List<TEntity> GetAll();
        TEntity Get(int id);
        void Create(TEntity entity);
        void Update(TEntity entity);
        void Delete(int id);
        void Save();
        Task SaveAsync();
    }
}