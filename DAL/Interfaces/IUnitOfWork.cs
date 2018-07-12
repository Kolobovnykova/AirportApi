using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork 
    {
        IRepository<TEntity> Set<TEntity>() where TEntity: Entity;

        int SaveChages();

        Task<int> SaveChangesAsync();
    }
}
