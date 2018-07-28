using System.Collections.Generic;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IService<T>
    {
        Task<List<T>> GetAll();

        Task<T> GetById(int id);

        Task Add(T entity);

        Task Update(T entity);

        Task Remove(int id);

        Task SaveChanges();
    }
}