using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using DAL.Models;

namespace DAL.Implementation
{
    public static class AirportDbInitializer
    {
        public static void Initialize(AirportContext context)
        {
            context.Database.EnsureCreated();

            if (context.Flights.Any())
            {
                return;
            }

            var pilots = new List<Pilot>
            {
                new Pilot
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    DateOfBirth = new DateTime(1960, 08, 30),
                    Experience = 9
                },
                new Pilot
                {
                    FirstName = "Petr",
                    LastName = "Petrov",
                    DateOfBirth = new DateTime(1980, 06, 12),
                    Experience = 3
                }
            };

            var stewardesses = new List<Stewardess>
            {
                new Stewardess
                {
                    FirstName = "Maria",
                    LastName = "Petrova",
                    DateOfBirth = new DateTime(1970, 05, 03)
                },
                new Stewardess
                {
                    FirstName = "Anna",
                    LastName = "Ivanova",
                    DateOfBirth = new DateTime(1990, 11, 09)
                },
                new Stewardess
                {
                    FirstName = "Violetta",
                    LastName = "Sidorova",
                    DateOfBirth = new DateTime(1980, 11, 10)
                },
                new Stewardess
                {
                    FirstName = "Valeria",
                    LastName = "Kuznetsova",
                    DateOfBirth = new DateTime(1998, 10, 05)
                }
            };
            var crews = new List<Crew>
            {
                new Crew
                {
                    Pilot = pilots[0],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[0],
                        stewardesses[1]
                    }
                },
                new Crew
                {
                    Pilot = pilots[1],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[2],
                        stewardesses[3]
                    }
                }
            };

            context.Pilots.AddRange(pilots);
            context.Stewardesses.AddRange(stewardesses);
            context.Crews.AddRange(crews);

            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    FlightId = 1,
                    Price = 38
                },
                new Ticket
                {
                    FlightId = 1,
                    Price = 47
                },
                new Ticket
                {
                    FlightId = 2,
                    Price = 59
                },
                new Ticket
                {
                    FlightId = 2,
                    Price = 35
                }
            };

            context.Tickets.AddRange(tickets);

            var planeTypes = new List<PlaneType>
            {
                new PlaneType
                {
                    Model = "Type 1",
                    CarryingCapacity = 1000,
                    MaxAltitude = 2000,
                    MaxRange = 10000,
                    MaxSpeed = 1200,
                    NumberOfSeats = 100
                },

                new PlaneType
                {
                    Model = "Type 2",
                    CarryingCapacity = 1000,
                    MaxAltitude = 2000,
                    MaxRange = 10000,
                    MaxSpeed = 1200,
                    NumberOfSeats = 100
                }
            };

            context.PlaneTypes.AddRange(planeTypes);

            var planes = new List<Plane>
            {
                new Plane
                {
                    DateOfRelease = new DateTime(2017, 10, 9),
                    Lifetime = 14,
                    Name = "Plane 1",
                    PlaneType = planeTypes[0]
                },
                new Plane
                {
                    DateOfRelease = new DateTime(2016, 12, 1),
                    Lifetime = 10,
                    Name = "Plane 2",
                    PlaneType = planeTypes[1]
                }
            };

            context.AddRange(planes);

            var flights = new List<Flight>
            {
                new Flight
                {
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

            context.Flights.AddRange(flights);

            var departures = new List<Departure>
            {
                new Departure
                {
                    Crew = crews[0],
                    Flight = flights[0],
                    DateOfDeparture = new DateTime(2018, 10, 5, 6, 10, 0),
                    Plane = planes[0]
                },
                new Departure
                {
                    Crew = crews[1],
                    Flight = flights[1],
                    DateOfDeparture = new DateTime(2018, 10, 5, 8, 16, 0),
                    Plane = planes[1]
                }
            };

            context.Departures.AddRange(departures);
            context.SaveChanges();
        }
    }
}