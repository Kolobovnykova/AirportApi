using System.Collections.Generic;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Repositories
{
    public class CrewRepository : IRepository<Crew>
    {
        private readonly IDataSource dataSource;

        public CrewRepository(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public Crew Get(int id)
        {
            return dataSource.Crews.Find(p => p.Id == id);
        }

        public IEnumerable<Crew> GetAll()
        {
            return dataSource.Crews;
        }

        public void Create(Crew entity)
        {
            dataSource.Crews.Add(entity);
        }

        public void Update(Crew entity)
        {
            var crew = Get(entity.Id);

            if (entity.Pilot != null)
            {
                crew.Pilot = entity.Pilot;
            }

            if (entity.Stewardesses != null)
            {
                crew.Stewardesses = entity.Stewardesses;
            }
        }

        public void Delete(int id)
        {
            dataSource.Crews.Remove(Get(id));
        }
    }
}