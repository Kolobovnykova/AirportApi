using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Shared.Exceptions;

namespace AirportApi.Tests.FakeObjects
{
    public class FakeRepositoryCrew : ICrewRepository
    {
        public List<Crew> Data;

        public FakeRepositoryCrew()
        {
        }

        public FakeRepositoryCrew(List<Crew> data)
        {
            Data = data;
        }

        public async Task<List<Crew>> GetAll()
        {
            return Data;
        }

        public async Task<Crew> Get(int id)
        {
            return Data.FirstOrDefault(x => x.Id == id);
        }

        public async Task Create(Crew entity)
        {
            Data.Add(entity);
        }

        public async Task Update(Crew entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            var oldEntity = Data.Find(x => x.Id == entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }

            Data[oldEntity.Id] = entity;
        }

        public async Task Delete(int id)
        {
            var entity = Data.Find(i => i.Id == id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }

            Data.Remove(entity);
        }

        public Task CreateRange(List<Crew> entity)
        {
            throw new NotImplementedException();
        }
    }
}