using System.Threading.Tasks;
using DAL.Models;

namespace DAL.Interfaces
{
    public interface IUnitOfWork
    {
        int SaveChages();
        Task<int> SaveChangesAsync();
    }
}