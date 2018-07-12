using System;
using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class PlaneTypeRepository : IRepository<PlaneType>
    {
        private readonly IDataSource dataSource;

        public PlaneTypeRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public PlaneType Get(int id)
        {
            return dataSource.PlaneTypes.Find(p => p.Id == id);
        }

        public IEnumerable<PlaneType> GetAll()
        {
            return dataSource.PlaneTypes;
        }

        public void Create(PlaneType entity)
        {
            dataSource.PlaneTypes.Add(entity);
        }

        public void Update(PlaneType entity)
        {
            var planeType = Get(entity.Id);

            if (entity.Model != null)
            {
                planeType.Model = entity.Model;
            }

            if (entity.CarryingCapacity > 0)
            {
                planeType.CarryingCapacity = entity.CarryingCapacity;
            }

            if (entity.MaxAltitude > 0)
            {
                planeType.MaxAltitude = entity.MaxAltitude;
            }

            if (entity.MaxRange > 0)
            {
                planeType.MaxRange = entity.MaxRange;
            }

            if (entity.MaxSpeed > 0)
            {
                planeType.MaxSpeed = entity.MaxSpeed;
            }

            if (entity.NumberOfSeats > 0)
            {
                planeType.NumberOfSeats = entity.NumberOfSeats;
            }
        }

        public void Delete(int id)
        {
            dataSource.PlaneTypes.Remove(Get(id));
        }
    }
}