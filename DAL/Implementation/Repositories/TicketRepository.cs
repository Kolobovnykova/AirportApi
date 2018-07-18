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

        public async Task<List<Ticket>> GetAll()
        {
            return await context.Tickets.ToListAsync();
        }

        public async Task<Ticket> Get(int id)
        {
            return await context.Tickets.FindAsync(id);
        }

        public async Task Create(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            await context.Tickets.AddAsync(entity);
        }

        public async Task Update(Ticket entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = await context.Tickets.FindAsync(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public async Task Delete(int id)
        {
            var entity = await context.Tickets.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Tickets.Remove(entity);
        }
    }
}