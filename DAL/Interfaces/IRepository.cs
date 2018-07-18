using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        Task<List<TEntity>> GetAll();
        Task<TEntity> Get(int id);
        Task Create(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(int id);
    }
}