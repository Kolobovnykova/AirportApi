using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IService<T>
    {
        List<T> GetAll();

        T GetById(int id);

        void Add(T entity);

        void Update(T entity);

        void Remove(int id);
    }
}