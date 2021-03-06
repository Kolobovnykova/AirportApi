﻿// <auto-generated />
using System;
using DAL.Implementation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DAL.Migrations
{
    [DbContext(typeof(AirportContext))]
    partial class AirportContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DAL.Models.Crew", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PilotId");

                    b.HasKey("Id");

                    b.HasIndex("PilotId");

                    b.ToTable("Crews");
                });

            modelBuilder.Entity("DAL.Models.Departure", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrewId");

                    b.Property<DateTime>("DateOfDeparture");

                    b.Property<int>("FlightId");

                    b.Property<int>("PlaneId");

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.HasIndex("FlightId")
                        .IsUnique();

                    b.HasIndex("PlaneId");

                    b.ToTable("Departures");
                });

            modelBuilder.Entity("DAL.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfArrival");

                    b.Property<DateTime>("DateOfDeparture");

                    b.Property<string>("Destination")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<string>("PointOfDeparture")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Flights");
                });

            modelBuilder.Entity("DAL.Models.Pilot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<int>("Experience");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(40);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("Pilots");
                });

            modelBuilder.Entity("DAL.Models.Plane", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfRelease");

                    b.Property<int>("Lifetime");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60);

                    b.Property<int>("PlaneTypeId");

                    b.HasKey("Id");

                    b.HasIndex("PlaneTypeId");

                    b.ToTable("Planes");
                });

            modelBuilder.Entity("DAL.Models.PlaneType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CarryingCapacity");

                    b.Property<int>("MaxAltitude");

                    b.Property<int>("MaxRange");

                    b.Property<int>("MaxSpeed");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("NumberOfSeats");

                    b.HasKey("Id");

                    b.ToTable("Planetypes");
                });

            modelBuilder.Entity("DAL.Models.Stewardess", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrewId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("CrewId");

                    b.ToTable("Stewardesses");
                });

            modelBuilder.Entity("DAL.Models.Ticket", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FlightId");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.HasIndex("FlightId");

                    b.ToTable("Tickets");
                });

            modelBuilder.Entity("DAL.Models.Crew", b =>
                {
                    b.HasOne("DAL.Models.Pilot", "Pilot")
                        .WithMany()
                        .HasForeignKey("PilotId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Departure", b =>
                {
                    b.HasOne("DAL.Models.Crew", "Crew")
                        .WithMany()
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Flight", "Flight")
                        .WithOne("Departure")
                        .HasForeignKey("DAL.Models.Departure", "FlightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DAL.Models.Plane", "Plane")
                        .WithMany()
                        .HasForeignKey("PlaneId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Plane", b =>
                {
                    b.HasOne("DAL.Models.PlaneType", "PlaneType")
                        .WithMany()
                        .HasForeignKey("PlaneTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Stewardess", b =>
                {
                    b.HasOne("DAL.Models.Crew")
                        .WithMany("Stewardesses")
                        .HasForeignKey("CrewId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DAL.Models.Ticket", b =>
                {
                    b.HasOne("DAL.Models.Flight")
                        .WithMany("Tickets")
                        .HasForeignKey("FlightId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
