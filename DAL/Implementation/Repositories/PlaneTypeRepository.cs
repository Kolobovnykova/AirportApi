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
    public class PlaneTypeRepository : IRepository<PlaneType>
    {
        private readonly AirportContext context;

        public PlaneTypeRepository(AirportContext context)
        {
            this.context = context;
        }

        public async Task<List<PlaneType>> GetAll()
        {
            return await context.PlaneTypes.ToListAsync();
        }

        public async Task<PlaneType> Get(int id)
        {
            return await context.PlaneTypes.FindAsync(id);
        }

        public async Task Create(PlaneType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await context.PlaneTypes.AddAsync(entity);
        }

        public async Task Update(PlaneType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var oldEntity = await context.PlaneTypes.FindAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }

            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.PlaneTypes.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            context.PlaneTypes.Remove(entity);
        }
    }
}