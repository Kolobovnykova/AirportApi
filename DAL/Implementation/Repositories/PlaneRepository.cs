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
    public class PlaneRepository : IRepository<Plane>
    {
        private readonly AirportContext context;

        public PlaneRepository(AirportContext context)
        {
            this.context = context;
        }

        public async Task<List<Plane>> GetAll()
        {
            return await context.Planes.Include(p => p.PlaneType).ToListAsync();
        }

        public async Task<Plane> Get(int id)
        {
            return await context.Planes.Include(p => p.PlaneType).FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task Create(Plane entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await context.Planes.AddAsync(entity);
        }

        public async Task Update(Plane entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var oldEntity = await context.Planes.FindAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }

            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.Planes.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            context.Planes.Remove(entity);
        }
    }
}