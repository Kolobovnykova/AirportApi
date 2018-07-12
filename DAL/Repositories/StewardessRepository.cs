using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class StewardessRepository : IRepository<Stewardess>
    {
        private readonly IDataSource dataSource;

        public StewardessRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Stewardess Get(int id)
        {
            return dataSource.Stewardesses.Find(p => p.Id == id);
        }

        public IEnumerable<Stewardess> GetAll()
        {
            return dataSource.Stewardesses;
        }

        public void Create(Stewardess entity)
        {
            dataSource.Stewardesses.Add(entity);
        }

        public void Update(Stewardess entity)
        {
            var stewardess = Get(entity.Id);

            if (entity.FirstName != null)
            {
                stewardess.FirstName = entity.FirstName;
            }

            if (entity.LastName != null)
            {
                stewardess.LastName = entity.LastName;
            }

            if (entity.DateOfBirth > DateTime.MinValue)
            {
                stewardess.DateOfBirth = entity.DateOfBirth;
            }
        }

        public void Delete(int id)
        {
            dataSource.Stewardesses.Remove(Get(id));
        }
    }
}