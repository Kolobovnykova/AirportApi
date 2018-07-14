using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options)
        {
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
        }
    }
}