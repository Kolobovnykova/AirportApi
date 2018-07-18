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
    public class PilotRepository : IRepository<Pilot>
    {
        private readonly AirportContext context;

        public PilotRepository(AirportContext context)
        {
            this.context = context;
        }

        public async Task<List<Pilot>> GetAll()
        {
            return await context.Pilots.ToListAsync();
        }

        public async Task<Pilot> Get(int id)
        {
            return await context.Pilots.FindAsync(id);
        }

        public async Task Create(Pilot entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await context.Pilots.AddAsync(entity);
        }

        public async Task Update(Pilot entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var oldEntity = await context.Pilots.FindAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }

            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.Pilots.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            context.Pilots.Remove(entity);
        }
    }
}