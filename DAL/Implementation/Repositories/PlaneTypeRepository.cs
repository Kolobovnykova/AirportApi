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

        public List<PlaneType> GetAll()
        {
            var query = context.PlaneTypes;

            return query.ToList();
        }

        public PlaneType Get(int id)
        {
            return context.PlaneTypes.Find(id);
        }

        public void Create(PlaneType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            context.PlaneTypes.Add(entity);
        }

        public void Update(PlaneType entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = context.PlaneTypes.Find(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.PlaneTypes.Find(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.PlaneTypes.Remove(entity);
        }
    }
}