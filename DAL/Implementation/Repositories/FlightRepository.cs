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

        public async Task<List<Flight>>  GetAll()
        {
            return await context.Flights.Include(f => f.Tickets).ToListAsync();
        }

        public async Task<Flight> Get(int id)
        {
            return await context.Flights.Include(f => f.Tickets).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Create(Flight entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            await context.Flights.AddAsync(entity);
        }

        public async Task Update(Flight entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = await context.Flights.FindAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.Flights.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Flights.Remove(entity);
        }
    }
}