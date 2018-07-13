using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using DAL.Models;

namespace DAL.Implementation
{
    public class DataSource : IDataSource
    {
        public List<Plane> Planes { get; set; } = new List<Plane>();
        public List<Pilot> Pilots { get; set; } = new List<Pilot>();
        public List<Flight> Flights { get; set; } = new List<Flight>();
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
        public List<Departure> Departures { get; set; } = new List<Departure>();
        public List<Stewardess> Stewardesses { get; set; } = new List<Stewardess>();
        public List<Crew> Crews { get; set; } = new List<Crew>();
        public List<PlaneType> PlaneTypes { get; set; } = new List<PlaneType>();

        public DataSource()
        {
            Pilots.Add(new Pilot
            {
                Id = 1,
                FirstName = "Ivan",
                LastName = "Ivanov",
                DateOfBirth = new DateTime(1960, 08, 30),
                Experience = 9
            });
            Pilots.Add(new Pilot
            {
                Id = 2,
                FirstName = "Petr",
                LastName = "Petrov",
                DateOfBirth = new DateTime(1980, 06, 12),
                Experience = 3
            });

            Stewardesses.Add(new Stewardess
            {
                Id = 1,
                FirstName = "Maria",
                LastName = "Petrova",
                DateOfBirth = new DateTime(1970, 05, 03)
            });

            Stewardesses.Add(new Stewardess
            {
                Id = 2,
                FirstName = "Anna",
                LastName = "Ivanova",
                DateOfBirth = new DateTime(1990, 11, 09)
            });
            Stewardesses.Add(new Stewardess
            {
                Id = 3,
                FirstName = "Violetta",
                LastName = "Sidorova",
                DateOfBirth = new DateTime(1980, 11, 10)
            });
            Stewardesses.Add(new Stewardess
            {
                Id = 4,
                FirstName = "Valeria",
                LastName = "Kuznetsova",
                DateOfBirth = new DateTime(1998, 10, 05)
            });

            Crews.Add(new Crew
            {
                Id = 1,
                Pilot = Pilots.FirstOrDefault(x => x.Id == 1),
                Stewardesses = new List<Stewardess>
                {
                    Stewardesses.FirstOrDefault(x => x.Id == 1),
                    Stewardesses.FirstOrDefault(x => x.Id == 2)
                }
            });
            
            Crews.Add(new Crew
            {
                Id = 2,
                Pilot = Pilots.FirstOrDefault(x => x.Id == 2),
                Stewardesses = new List<Stewardess>
                {
                    Stewardesses.FirstOrDefault(x => x.Id == 3),
                    Stewardesses.FirstOrDefault(x => x.Id == 4)
                }
            });

            
        }

        public List<TEntity> Set<TEntity>()
        {
            if (Planes is List<TEntity>)
            {
                return Planes as List<TEntity>;
            }

            if (PlaneTypes is List<TEntity>)
            {
                return PlaneTypes as List<TEntity>;
            }

            if (Tickets is List<TEntity>)
            {
                return Tickets as List<TEntity>;
            }

            if (Flights is List<TEntity>)
            {
                return Flights as List<TEntity>;
            }

            if (Departures is List<TEntity>)
            {
                return Departures as List<TEntity>;
            }

            if (Pilots is List<TEntity>)
            {
                return Pilots as List<TEntity>;
            }

            if (Stewardesses is List<TEntity>)
            {
                return Stewardesses as List<TEntity>;
            }

            if (Crews is List<TEntity>)
            {
                return Crews as List<TEntity>;
            }

            throw new Exception("No such repository");
        }
    }
}