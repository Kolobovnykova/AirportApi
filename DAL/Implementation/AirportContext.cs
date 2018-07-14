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
      //  public AirportContext(DbContextOptions<AirportContext> options) : base(options)
       public AirportContext() : base()
        {
           // Database.EnsureCreated();
        }

        public virtual DbSet<Crew> Crews { get; set; }
        public virtual DbSet<Departure> Departures { get; set; }
        public virtual DbSet<Flight> Flights { get; set; }
        public virtual DbSet<Pilot> Pilots { get; set; }
        public virtual DbSet<Plane> Planes { get; set; }
        public virtual DbSet<PlaneType> PlaneTypes { get; set; }
        public virtual DbSet<Stewardess> Stewardesses { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
       
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