using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.Repositories
{
    public class FlightRepository : IRepository<Flight>
    {
        private readonly AirportContext context;

        public FlightRepository(AirportContext context)
        {
            this.context = context;
        }

        public List<Flight> GetAll()
        {
            var query = context.Flights.Include(f => f.Tickets);

            return query.ToList();
        }

        public Flight Get(int id)
        {
            return context.Flights.Include(f => f.Tickets).FirstOrDefault(f => f.Id == id);
        }

        public void Create(Flight entity)
        {
            context.Flights.Add(entity);
        }

        public void Update(Flight entity)
        {
            var oldEntity = context.Flights.Find(entity.Id);
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Flights.Find(id);

            context.Flights.Remove(entity);
        }
    }
}