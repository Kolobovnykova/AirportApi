using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private readonly IDataSource dataSource;

        public Repository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public List<TEntity> Get(int? filter = null)
        {
            List<TEntity> query = dataSource.Set<TEntity>();

            if (filter != null)
            {
                query = query.Where(x => x.Id == filter).ToList();
            }

            return query.ToList();
        }

        public void Create(TEntity entity)
        {
            dataSource.Set<TEntity>().Add(entity);
        }

        public void Update(TEntity entity)
        {
            var index = dataSource.Set<TEntity>().FindIndex(x => x.Id == entity.Id);
            dataSource.Set<TEntity>()[index] = entity;
        }

        public void Delete(int? filter = null)
        {
            List<TEntity> query = dataSource.Set<TEntity>();

            if (filter != null)
            {
                Delete(query.Find(x => x.Id == filter));
            }
            else
            {
                query.Clear();
            }
        }

        public void Delete(TEntity entity)
        {
            dataSource.Set<TEntity>().Remove(entity);
        }
    }
}