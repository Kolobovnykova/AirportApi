using System;
using System.Collections.Generic;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL.Implementation
{
    public static class DataBuilder
    {
        public static void Build(ModelBuilder modelBuilder)
        {
            var pilots = new[]
            {
                new Pilot
                {
                    Id = 1,
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    DateOfBirth = new DateTime(1960, 08, 30),
                    Experience = 9
                },
                new Pilot
                {
                    Id = 2,
                    FirstName = "Petr",
                    LastName = "Petrov",
                    DateOfBirth = new DateTime(1980, 06, 12),
                    Experience = 3
                }
            };

            var stewardesses = new[]
            {
                new Stewardess
                {
                    Id = 1,
                    FirstName = "Maria",
                    LastName = "Petrova",
                    DateOfBirth = new DateTime(1970, 05, 03)
                },
                new Stewardess
                {
                    Id = 2,
                    FirstName = "Anna",
                    LastName = "Ivanova",
                    DateOfBirth = new DateTime(1990, 11, 09)
                },
                new Stewardess
                {
                    Id = 3,
                    FirstName = "Violetta",
                    LastName = "Sidorova",
                    DateOfBirth = new DateTime(1980, 11, 10)
                },
                new Stewardess
                {
                    Id = 4,
                    FirstName = "Valeria",
                    LastName = "Kuznetsova",
                    DateOfBirth = new DateTime(1998, 10, 05)
                }
            };

            var crews = new[]
            {
                new Crew
                {
                    Id = 1,
                   // Pilot = pilots[0],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[0],
                        stewardesses[1]
                    }
                },
                new Crew
                {
                    Id = 2,
                    //Pilot = pilots[1],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[2],
                        stewardesses[3]
                    }
                }
            };
//
//            pilots[0].Crew = crews[0];
//            pilots[0].CrewId = crews[0].Id;
//            pilots[1].Crew = crews[1];
//            pilots[1].CrewId = crews[1].Id;

            stewardesses[0].Crew = crews[0];
            stewardesses[1].Crew = crews[0];
            stewardesses[2].Crew = crews[1];
            stewardesses[3].Crew = crews[1];

            var tickets = new[]
            {
                new Ticket
                {
                    Id = 1,
                    Flight = null,
                    Price = 38
                },
                new Ticket
                {
                    Id = 2,
                    Flight = null,
                    Price = 47
                },
                new Ticket
                {
                    Id = 3,
                    Flight = null,
                    Price = 59
                },
                new Ticket
                {
                    Id = 4,
                    Flight = null,
                    Price = 35
                }
            };

            var flights = new []
            {
                new Flight
                {
                    Id = 1,
                    DateOfArrival = new DateTime(2018, 10, 5, 16, 13, 0),
                    DateOfDeparture = new DateTime(2018, 10, 5, 20, 5, 0),
                    PointOfDeparture = "Heathrow",
                    Destination = "Boryspil",
                    Tickets = new List<Ticket>
                    {
                        tickets[0],
                        tickets[1]
                    }
                },
                new Flight
                {
                    Id = 2,
                    DateOfArrival = new DateTime(2018, 10, 5, 4, 5, 0),
                    DateOfDeparture = new DateTime(2018, 10, 5, 6, 5, 0),
                    PointOfDeparture = "Boryspil",
                    Destination = "Heathrow",
                    Tickets = new List<Ticket>
                    {
                        tickets[2],
                        tickets[3]
                    }
                }
            };

            tickets[0].Flight = flights[0];
            tickets[1].Flight = flights[0];
            tickets[2].Flight = flights[1];
            tickets[3].Flight = flights[1];

            var planeTypes = new[]
            {
                new PlaneType
                {
                    Id = 1,
                    Model = "Type 1",
                    CarryingCapacity = 1000,
                    MaxAltitude = 2000,
                    MaxRange = 10000,
                    MaxSpeed = 1200,
                    NumberOfSeats = 100
                },
                new PlaneType
                {
                    Id = 2,
                    Model = "Type 2",
                    CarryingCapacity = 1000,
                    MaxAltitude = 2000,
                    MaxRange = 10000,
                    MaxSpeed = 1200,
                    NumberOfSeats = 100
                }
            };

            var planes = new[]
            {
                new Plane
                {
                    Id = 1,
                    DateOfRelease = new DateTime(2017, 10, 9),
                    Lifetime = 14,
                    Name = "Plane 1",
                    PlaneType = planeTypes[0]
                },
                new Plane
                {
                    Id = 2,
                    DateOfRelease = new DateTime(2016, 12, 1),
                    Lifetime = 10,
                    Name = "Plane 2",
                    PlaneType = planeTypes[1]
                }
            };

            var departures = new[]
            {
                new Departure
                {
                    Id = 1,
                    Crew = crews[0],
                    Flight = flights[0],
                    DateOfDeparture = new DateTime(2018, 10, 5, 6, 10, 0),
                    Plane = planes[0]
                },
                new Departure
                {
                    Id = 2,
                    Crew = crews[1],
                    Flight = flights[1],
                    DateOfDeparture = new DateTime(2018, 10, 5, 8, 16, 0),
                    Plane = planes[1]
                }
            };

            modelBuilder.Entity<Pilot>().HasData(pilots);
            modelBuilder.Entity<Stewardess>().HasData(stewardesses);
            modelBuilder.Entity<Crew>().HasData(crews);
            modelBuilder.Entity<Ticket>().HasData(tickets);
            modelBuilder.Entity<Flight>().HasData(flights);
            modelBuilder.Entity<Plane>().HasData(planes);
            modelBuilder.Entity<PlaneType>().HasData(planeTypes);
            modelBuilder.Entity<Departure>().HasData(departures);
        }
    }
}