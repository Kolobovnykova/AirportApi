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
    public class StewardessRepository : IRepository<Stewardess>
    {
        private readonly AirportContext context;

        public StewardessRepository(AirportContext context)
        {
            this.context = context;
        }

        public async Task<List<Stewardess>> GetAll()
        {
            return await context.Stewardesses.ToListAsync();
        }

        public async Task<Stewardess> Get(int id)
        {
            return await context.Stewardesses.FindAsync(id);
        }

        public async Task Create(Stewardess entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await context.Stewardesses.AddAsync(entity);
        }

        public async Task Update(Stewardess entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var oldEntity = await context.Stewardesses.FindAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }

            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.Stewardesses.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            context.Stewardesses.Remove(entity);
        }
    }
}