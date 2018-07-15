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

        public List<Pilot> GetAll()
        {
            var query = context.Pilots;

            return query.ToList();
        }

        public Pilot Get(int id)
        {
            return context.Pilots.Find(id);
        }

        public void Create(Pilot entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            context.Pilots.Add(entity);
        }

        public void Update(Pilot entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = context.Pilots.Find(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Pilots.Find(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Pilots.Remove(entity);
        }
    }
}