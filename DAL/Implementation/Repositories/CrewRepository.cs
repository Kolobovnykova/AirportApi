using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        private readonly AirportContext context;

        public CrewRepository(AirportContext context)
        {
            this.context = context;
        }

        public List<Crew> GetAll()
        {
            var query = context.Crews.Include(c => c.Pilot).Include(c => c.Stewardesses);

            return query.ToList();
        }

        public Crew Get(int id)
        {
            return context.Crews.Include(c => c.Pilot).Include(c => c.Stewardesses).FirstOrDefault(c => c.Id == id);
        }

        public void Create(Crew entity)
        {
            context.Crews.Add(entity);
        }

        public void Update(Crew entity)
        {
            context.Crews.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Crews.Find(id);

            context.Crews.Remove(entity);
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