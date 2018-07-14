//using System.Collections.Generic;
//using System.Linq;
//using DAL.Interfaces;
//using DAL.Models;
//
//namespace DAL.Implementation
//{
//    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
//    {
//       // private readonly IDataSource dataSource;
//        private readonly AirportContext context;
//
//        public Repository(AirportContext context)
//        {
//            this.context = context;
//        }
//
//        public List<TEntity> Get(int? filter = null)
//        {
//            List<TEntity> query = context.Set<TEntity>();
//
//            if (filter != null)
//            {
//                query = query.Where(x => x.Id == filter).ToList();
//            }
//
//            return query.ToList();
//        }
//
//        public void Create(TEntity entity)
//        {
//            context.Set<TEntity>().Add(entity);
//        }
//
//        public void Update(TEntity entity)
//        {
//            var index = context.Set<TEntity>().FindIndex(x => x.Id == entity.Id);
//            context.Set<TEntity>()[index] = entity;
//        }
//
//        public void Delete(int id)
//        {
//            List<TEntity> query = context.Set<TEntity>();
//
//           
//                Delete(query.Find(x => x.Id == id));
//            
//        }
//
//        public void Delete(TEntity entity)
//        {
//            context.Set<TEntity>().Remove(entity);
//        }
//    }
//}