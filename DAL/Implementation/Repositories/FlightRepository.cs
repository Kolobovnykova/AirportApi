using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

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
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            context.Flights.Add(entity);
        }

        public void Update(Flight entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = context.Flights.Find(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Flights.Find(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Flights.Remove(entity);
        }
    }
}