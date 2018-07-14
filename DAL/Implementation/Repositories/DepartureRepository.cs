using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.Repositories
{
    public class DepartureRepository : IRepository<Departure>
    {
        private readonly AirportContext context;

        public DepartureRepository(AirportContext context)
        {
            this.context = context;
        }

        public List<Departure> GetAll()
        {
            var query = context.Departures;

            return query.ToList();
        }

        public Departure Get(int id)
        {
            return context.Departures.Find(id);
        }

        public void Create(Departure entity)
        {
            context.Departures.Add(entity);
        }

        public void Update(Departure entity)
        {
            context.Departures.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Departures.Find(id);

            context.Departures.Remove(entity);
        }

        public virtual void Save()
        {
            context.SaveChanges();
        }

        public virtual Task SaveAsync()
        {
            return context.SaveChangesAsync();
        }
    }
}