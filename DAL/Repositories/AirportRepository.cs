using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class AirportRepository : IRepository<Airport>
    {
        readonly IDataSource dataSource;

        public AirportRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public Airport Get(int id)
        {
            return dataSource.Airports.Find(p => p.Id == id);
        }

        public IEnumerable<Airport> GetAll()
        {
            return dataSource.Airports;
        }

        public void Create(Airport entity)
        {
            dataSource.Airports.Add(entity);
        }

        public void Update(Airport entity)
        {
            var airport = Get(entity.Id);

            if (entity.Name != null)
            {
                airport.Name = entity.Name;
            }

            if (entity.City != null)
            {
                airport.City = entity.City;
            }

            if (entity.Country != null)
            {
                airport.Country = entity.Country;
            }
        }

        public void Delete(int id)
        {
            dataSource.Airports.Remove(Get(id));
        }
    }
}