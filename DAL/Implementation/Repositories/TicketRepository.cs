using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

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
            context.Tickets.Add(entity);
        }

        public void Update(Ticket entity)
        {
            var oldEntity = context.Tickets.Find(entity.Id);
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Tickets.Find(id);

            context.Tickets.Remove(entity);
        }
    }
}