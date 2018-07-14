using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation.Repositories
{
    public class PlaneTypeRepository : IRepository<PlaneType>
    {
        private readonly AirportContext context;

        public PlaneTypeRepository(AirportContext context)
        {
            this.context = context;
        }

        public List<PlaneType> GetAll()
        {
            var query = context.PlaneTypes;

            return query.ToList();
        }

        public PlaneType Get(int id)
        {
            return context.PlaneTypes.Find(id);
        }

        public void Create(PlaneType entity)
        {
            context.PlaneTypes.Add(entity);
        }

        public void Update(PlaneType entity)
        {
            context.PlaneTypes.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.PlaneTypes.Find(id);

            context.PlaneTypes.Remove(entity);
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