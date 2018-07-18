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
    public class CrewRepository : IRepository<Crew>
    {
        private readonly AirportContext context;

        public CrewRepository(AirportContext context)
        {
            this.context = context;
        }

        public async Task<List<Crew>> GetAll()
        {
            return await context.Crews.Include(c => c.Pilot).Include(c => c.Stewardesses).ToListAsync();
        }

        public async Task<Crew> Get(int id)
        {
            return await context.Crews.Include(c => c.Pilot).Include(c => c.Stewardesses)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(Crew entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            await context.Crews.AddAsync(entity);
        }

        public async Task Update(Crew entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = await context.Crews.Include(c => c.Pilot).Include(c => c.Stewardesses)
                .FirstOrDefaultAsync(c => c.Id == entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.Crews.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Crews.Remove(entity);
        }
    }
}