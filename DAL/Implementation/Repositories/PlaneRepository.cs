using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

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
            context.Planes.Add(entity);
        }

        public void Update(Plane entity)
        {
            context.Planes.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Planes.Find(id);

            context.Planes.Remove(entity);
        }
    }
}