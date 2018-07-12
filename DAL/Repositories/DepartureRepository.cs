using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private readonly IDataSource dataSource;

        public DepartureRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public Departure Get(int id)
        {
            return dataSource.Departures.Find(p => p.Id == id);
        }

        public IEnumerable<Departure> GetAll()
        {
            return dataSource.Departures;
        }

        public void Create(Departure entity)
        {
            dataSource.Departures.Add(entity);
        }

        public void Update(Departure entity)
        {
            var departure = Get(entity.Id);

            if (entity.Crew != null)
            {
                departure.Crew = entity.Crew;
            }

            if (entity.Flight != null)
            {
                departure.Flight = entity.Flight;
            }
            
            if (entity.Plane != null)
            {
                departure.Plane = entity.Plane;
            }
        }

        public void Delete(int id)
        {
            dataSource.Departures.Remove(Get(id));
        }
    }
}