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
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly AirportContext context;

        public TicketRepository(AirportContext context)
        {
            this.context = context;
        }

        public List<Ticket> GetAll()
        {
            var query = context.Tickets;

            return query.ToList();
        }

        public Ticket Get(int id)
        {
            return context.Tickets.Find(id);
        }

        public void Create(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            context.Tickets.Add(entity);
        }

        public void Update(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = context.Tickets.Find(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Tickets.Find(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Tickets.Remove(entity);
        }
    }
}