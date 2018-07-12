using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class TicketRepository : IRepository<Ticket>
    {
        private readonly IDataSource dataSource;

        public TicketRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Ticket Get(int id)
        {
            return dataSource.Tickets.Find(p => p.Id == id);
        }

        public IEnumerable<Ticket> GetAll()
        {
            return dataSource.Tickets;
        }

        public void Create(Ticket entity)
        {
            dataSource.Tickets.Add(entity);
        }

        public void Update(Ticket entity)
        {
            var ticket = Get(entity.Id);

            if (entity.Flight != null)
            {
                ticket.Flight = entity.Flight;
            }

            if (entity.Price >= 0)
            {
                ticket.Price = entity.Price;
            }
        }

        public void Delete(int id)
        {
            dataSource.Tickets.Remove(Get(id));
        }
    }
}