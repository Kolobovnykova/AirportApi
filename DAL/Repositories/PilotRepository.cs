using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class PilotRepository : IRepository<Pilot>
    {
        private readonly IDataSource dataSource;

        public PilotRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public Pilot Get(int id)
        {
            return dataSource.Pilots.Find(p => p.Id == id);
        }

        public IEnumerable<Pilot> GetAll()
        {
            return dataSource.Pilots;
        }

        public void Create(Pilot entity)
        {
            dataSource.Pilots.Add(entity);
        }

        public void Update(Pilot entity)
        {
            var pilot = Get(entity.Id);

            if (entity.FirstName != null)
            {
                pilot.FirstName = entity.FirstName;
            }

            if (entity.LastName != null)
            {
                pilot.LastName = entity.LastName;
            }

            if (entity.DateOfBirth >= DateTime.MinValue)
            {
                pilot.DateOfBirth = entity.DateOfBirth;
            }

            if (entity.Experience >= TimeSpan.MinValue)
            {
                pilot.Experience = entity.Experience;
            }
        }

        public void Delete(int id)
        {
            dataSource.Pilots.Remove(Get(id));
        }
    }
}