using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

namespace DAL.Implementation.Repositories
{
    public class CrewRepository : ICrewRepository
    {
        private readonly AirportContext context;

        public CrewRepository(AirportContext context)
        {
            this.context = context;
        }

        public async Task<List<Crew>> GetAll()
        {
            return await context.Crews.Include(c => c.Pilot).Include(c => c.Stewardesses).ToListAsync();
        }

        public async Task<Crew> Get(int id)
        {
            return await context.Crews.Include(c => c.Pilot).Include(c => c.Stewardesses)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task Create(Crew entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            await context.Crews.AddAsync(entity);
        }
        
        public async Task CreateRange(List<Crew> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            foreach (var e in entity)
            {
                if (e.Id > 0)
                {
                    e.Id = 0;
                }
            }
            
            await context.Crews.AddRangeAsync(entity);
        }

        public async Task Update(Crew entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            Crew temp = await context.Crews.FindAsync(entity.Id);
            if (temp != null)
            {
                temp.Pilot = entity.Pilot;
                temp.Stewardesses = entity.Stewardesses;

                context.Crews.Update(temp);
                await context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var entity = await context.Crews.FindAsync(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Crews.Remove(entity);
        }
    }
}