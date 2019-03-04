using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

namespace DAL.Implementation.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private readonly AirportContext context;

        public DepartureRepository(AirportContext context)
        {
            this.context = context;
        }

        public async Task<List<Departure>> GetAll()
        {
            return await context.Departures.Include(d => d.Crew).ThenInclude(c => c.Pilot).Include(d => d.Crew)
                .ThenInclude(c => c.Stewardesses)
                .Include(d => d.Flight).ThenInclude(f => f.Tickets)
                .Include(d => d.Plane).ThenInclude(p => p.PlaneType)
                .ToListAsync();
        }

        public async Task<Departure> Get(int id)
        {
            return await context.Departures.Include(d => d.Crew).ThenInclude(c => c.Pilot).Include(d => d.Crew)
                .ThenInclude(c => c.Stewardesses)
                .Include(d => d.Flight).ThenInclude(f => f.Tickets)
                .Include(d => d.Plane).ThenInclude(p => p.PlaneType).FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task Create(Departure entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            await context.Departures.AddAsync(entity);
        }

        public async Task Update(Departure entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = await context.Departures.FindAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.Departures.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Departures.Remove(entity);
        }
    }
}