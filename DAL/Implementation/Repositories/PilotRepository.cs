using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

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
            context.Pilots.Add(entity);
        }

        public void Update(Pilot entity)
        {
            context.Pilots.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Pilots.Find(id);

            context.Pilots.Remove(entity);
        }
    }
}