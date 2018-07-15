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

        public List<Plane> GetAll()
        {
            var query = context.Planes.Include(p => p.PlaneType);

            return query.ToList();
        }

        public Plane Get(int id)
        {
            return context.Planes.Include(p => p.PlaneType).FirstOrDefault(f => f.Id == id);
        }

        public void Create(Plane entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            context.Planes.Add(entity);
        }

        public void Update(Plane entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = context.Planes.Find(entity.Id);
            if (oldEntity == null)
            {
                throw new ArgumentNullException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Planes.Find(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Planes.Remove(entity);
        }
    }
}