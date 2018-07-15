﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Shared.Exceptions;

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
            var query = context.Departures.Include(d => d.Crew).ThenInclude(c => c.Pilot).Include(d => d.Crew)
                .ThenInclude(c => c.Stewardesses)
                .Include(d => d.Flight).ThenInclude(f => f.Tickets)
                .Include(d => d.Plane).ThenInclude(p => p.PlaneType);

            return query.ToList();
        }

        public Departure Get(int id)
        {
            return context.Departures.Include(d => d.Crew).ThenInclude(c => c.Pilot).Include(d => d.Crew)
                .ThenInclude(c => c.Stewardesses)
                .Include(d => d.Flight).ThenInclude(f => f.Tickets)
                .Include(d => d.Plane).ThenInclude(p => p.PlaneType).FirstOrDefault(s => s.Id == id);
        }

        public void Create(Departure entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            context.Departures.Add(entity);
        }

        public void Update(Departure entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            var oldEntity = context.Departures.Find(entity.Id);
            if (oldEntity == null)
            {
                throw new NotFoundException(nameof(oldEntity));
            }
            
            context.Entry(oldEntity).State = EntityState.Detached;
            context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(int id)
        {
            var entity = context.Departures.Find(id);
            if (entity == null)
            {
                throw new NotFoundException(nameof(entity));
            }
            
            context.Departures.Remove(entity);
        }
    }
}