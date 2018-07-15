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

        public List<Stewardess> GetAll()
        {
            var query = context.Stewardesses;

            return query.ToList();
        }

        public Stewardess Get(int id)
        {
            return context.Stewardesses.Find(id);
        }

        public void Create(Stewardess entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            context.Stewardesses.Add(entity);
        }

        public void Update(Stewardess entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = context.Stewardesses.Find(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Stewardesses.Find(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Stewardesses.Remove(entity);
        }
    }
}