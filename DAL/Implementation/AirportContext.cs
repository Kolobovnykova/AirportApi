using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Implementation.Configurations;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class AirportContext : DbContext
    {
        public AirportContext() : base()
        {
        }

        public DbSet<Crew> Crews { get; set; }
        public DbSet<Departure> Departures { get; set; }
        public DbSet<Flight> Flights { get; set; }
        public DbSet<Pilot> Pilots { get; set; }
        public DbSet<Plane> Planes { get; set; }
        public DbSet<PlaneType> PlaneTypes { get; set; }
        public DbSet<Stewardess> Stewardesses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


        public void Seed()
        {
            if (!Pilots.Any())
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
                SaveChanges();
            }

            if (!Stewardesses.Any())
            {
                Stewardesses.Add(new Stewardess
                {
                    Id = 1,
                    FirstName = "Maria",
                    LastName = "Petrova",
                    CrewId = 1,
                    DateOfBirth = new DateTime(1970, 05, 03)
                });
                Stewardesses.Add(new Stewardess
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Ivanova",
                    CrewId = 1,
                    DateOfBirth = new DateTime(1990, 11, 09)
                });
                Stewardesses.Add(new Stewardess
                {
                    Id = 3,
                    FirstName = "Violetta",
                    LastName = "Sidorova",
                    CrewId = 2,
                    DateOfBirth = new DateTime(1980, 11, 10)
                });
                Stewardesses.Add(new Stewardess
                {
                    Id = 4,
                    FirstName = "Valeria",
                    LastName = "Kuznetsova",
                    CrewId = 2,
                    DateOfBirth = new DateTime(1998, 10, 05)
                });
                SaveChanges();
            }
            
            if (!Crews.Any())
            {
                Crews.Add(new Crew
                {
                    Id = 1,
                    PilotId = 1
//                    Stewardesses = new List<Stewardess>
//                    {
//                        Stewardesses.FirstOrDefault(x => x.Id == 1),
//                        Stewardesses.FirstOrDefault(x => x.Id == 2)
//                    }
                });
                Crews.Add(new Crew
                {
                    Id = 2,
                    PilotId = 2,
//                    Stewardesses = new List<Stewardess>
//                    {
//                        Stewardesses.FirstOrDefault(x => x.Id == 3),
//                        Stewardesses.FirstOrDefault(x => x.Id == 4)
//                    }
                });
                SaveChanges();
            }
        
            if (!Tickets.Any())
            {
                Tickets.Add(new Ticket
                {
                    Id = 1,
                    FlightId = 1,
                    Price = 38
                });
                Tickets.Add(new Ticket
                {
                    Id = 2,
                    FlightId = 1,
                    Price = 47
                });
                Tickets.Add(new Ticket
                {
                    Id = 3,
                    FlightId = 2,
                    Price = 59
                });
                Tickets.Add(new Ticket
                {
                    Id = 4,
                    FlightId = 2,
                    Price = 35
                });
                SaveChanges();
            }
            
            if (!Planes.Any())
            {
                PlaneTypes.Add(new PlaneType
                    {
                        Id = 1,
                        Model = "Type 1",
                        CarryingCapacity = 1000,
                        MaxAltitude = 2000,
                        MaxRange = 10000,
                        MaxSpeed = 1200,
                        NumberOfSeats = 100
                    }
                );
                PlaneTypes.Add(new PlaneType
                    {
                        Id = 2,
                        Model = "Type 2",
                        CarryingCapacity = 1000,
                        MaxAltitude = 2000,
                        MaxRange = 10000,
                        MaxSpeed = 1200,
                        NumberOfSeats = 100
                    }
                );
                SaveChanges();
            }
            
            if (!PlaneTypes.Any())
            {
                Planes.Add(new Plane
                {
                    Id = 1,
                    DateOfRelease = new DateTime(2017, 10, 9),
                    Lifetime = 14,
                    Name = "Plane 1",
                    PlaneType = PlaneTypes.FirstOrDefault(x => x.Id == 1)
                });
            
                Planes.Add(new Plane
                {
                    Id = 2,
                    DateOfRelease = new DateTime(2016, 12, 1),
                    Lifetime = 10,
                    Name = "Plane 2",
                    PlaneType = PlaneTypes.FirstOrDefault(x => x.Id == 2)
                });
                SaveChanges();
            }

            if (!Flights.Any())
            {
                Flights.Add(new Flight
                {
                    Id = 1,
                    DateOfArrival = new DateTime(2018, 10, 5, 16, 13, 0),
                    DateOfDeparture = new DateTime(2018, 10, 5, 20, 5, 0),
                    PointOfDeparture = "Heathrow",
                    Destination = "Boryspil",
//                    Tickets = new List<Ticket>
//                    {
//                        Tickets.FirstOrDefault(x => x.Id == 1),
//                        Tickets.FirstOrDefault(x => x.Id == 2)
//                    }
                });

                Flights.Add(new Flight
                {
                    Id = 2,
                    DateOfArrival = new DateTime(2018, 10, 5, 4, 5, 0),
                    DateOfDeparture = new DateTime(2018, 10, 5, 6, 5, 0),
                    PointOfDeparture = "Boryspil",
                    Destination = "Heathrow",
//                    Tickets = new List<Ticket>
//                    {
//                        Tickets.FirstOrDefault(x => x.Id == 3),
//                        Tickets.FirstOrDefault(x => x.Id == 4)
//                    }
                });
                SaveChanges();
            }
            
            if (!Departures.Any())
            {
                Departures.Add(new Departure
                {
                    Id = 1,
                    CrewId = 1,
                    FlightId = 1,
                    DateOfDeparture =  new DateTime(2018, 10, 5, 6, 10, 0),
                    PlaneId = 1
                });
                Departures.Add(new Departure
                {
                    Id = 2,
                    CrewId = 2,
                    FlightId = 2,
                    DateOfDeparture =  new DateTime(2018, 10, 5, 8, 16, 0),
                    PlaneId = 2
                });
                SaveChanges();
            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Plane>().ToTable("Planes");
            modelBuilder.Entity<PlaneType>().ToTable("Planetypes");
            modelBuilder.Entity<Flight>().ToTable("Flights");
            modelBuilder.Entity<Crew>().ToTable("Crews");
            modelBuilder.Entity<Departure>().ToTable("Departures");
            modelBuilder.Entity<Pilot>().ToTable("Pilots");
            modelBuilder.Entity<Stewardess>().ToTable("Stewardesses");
            modelBuilder.Entity<Ticket>().ToTable("Tickets");


//            base.OnModelCreating(modelBuilder);
//            new FlightConfiguration(modelBuilder.Entity<Flight>());
//            new TicketConfiguration(modelBuilder.Entity<Ticket>());
//            new DepartureConfiguration(modelBuilder.Entity<Departure>());
//            new StewardessConfiguration(modelBuilder.Entity<Stewardess>());
//            new PilotConfiguration(modelBuilder.Entity<Pilot>());
//            new CrewConfiguration(modelBuilder.Entity<Crew>());
//            new PlaneTypeConfiguration(modelBuilder.Entity<PlaneType>());
//            new PlaneConfiguration(modelBuilder.Entity<Plane>());
            
            
            
            //DataBuilder.Build(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(LocalDb)\\MSSQLLocalDB;Database=AirportDb;Trusted_Connection=True;");
        }
    }
}