using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class PlaneRepository : IRepository<Plane>
    {
        private readonly IDataSource dataSource;

        public PlaneRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public Plane Get(int id)
        {
            return dataSource.Planes.Find(p => p.Id == id);
        }

        public IEnumerable<Plane> GetAll()
        {
            return dataSource.Planes;
        }

        public void Create(Plane entity)
        {
            dataSource.Planes.Add(entity);
        }

        public void Update(Plane entity)
        {
            var plane = Get(entity.Id);

            if (entity.Name != null)
            {
                plane.Name = entity.Name;
            }

            if (entity.PlaneType != null)
            {
                plane.PlaneType = entity.PlaneType;
            }

            if (entity.DateOfRelease >= DateTime.MinValue)
            {
                plane.DateOfRelease = entity.DateOfRelease;
            }

            if (entity.Lifetime >= TimeSpan.MinValue)
            {
                plane.Lifetime = entity.Lifetime;
            }
        }

        public void Delete(int id)
        {
            dataSource.Planes.Remove(Get(id));
        }
    }
}