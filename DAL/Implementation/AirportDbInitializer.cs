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
                },
                new Pilot
                {
                    FirstName = "Fritz",
                    LastName = "Kling",
                    DateOfBirth = new DateTime(1987, 06, 12),
                    Experience = 20
                },
                new Pilot
                {
                    FirstName = "Marshall",
                    LastName = "Padberg",
                    DateOfBirth = new DateTime(1988, 06, 12),
                    Experience = 10
                },
                new Pilot
                {
                    FirstName = "Bartholome",
                    LastName = "Lockman",
                    DateOfBirth = new DateTime(1988, 06, 12),
                    Experience = 5
                },
                new Pilot
                {
                    FirstName = "Rodrigo",
                    LastName = "Flatley",
                    DateOfBirth = new DateTime(1988, 06, 12),
                    Experience = 12
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
                    FirstName = "Una",
                    LastName = "Cole",
                    DateOfBirth = new DateTime(1998, 10, 05)
                },
                new Stewardess
                {
                    FirstName = "Dejah",
                    LastName = "Homenick",
                    DateOfBirth = new DateTime(1980, 11, 10)
                },
                new Stewardess
                {
                    FirstName = "Donnie",
                    LastName = "Sanford",
                    DateOfBirth = new DateTime(1998, 10, 05)
                },
                new Stewardess
                {
                    FirstName = "Lia",
                    LastName = "Effertz",
                    DateOfBirth = new DateTime(1980, 11, 10)
                },
                new Stewardess
                {
                    FirstName = "Annie",
                    LastName = "Howe",
                    DateOfBirth = new DateTime(1998, 10, 05)
                },
                new Stewardess
                {
                    FirstName = "Ellis",
                    LastName = "Adams",
                    DateOfBirth = new DateTime(1980, 11, 10)
                },
                new Stewardess
                {
                    FirstName = "Harmon",
                    LastName = "Yost",
                    DateOfBirth = new DateTime(1998, 10, 05)
                },
                new Stewardess
                {
                    FirstName = "Alyson",
                    LastName = "Koelpin",
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
                },
                new Crew
                {
                    Pilot = pilots[2],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[4],
                        stewardesses[5]
                    }
                },
                new Crew
                {
                    Pilot = pilots[3],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[6],
                        stewardesses[7]
                    }
                },
                new Crew
                {
                    Pilot = pilots[4],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[8],
                        stewardesses[9]
                    }
                },
                new Crew
                {
                    Pilot = pilots[5],
                    Stewardesses = new List<Stewardess>
                    {
                        stewardesses[10],
                        stewardesses[11]
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
                },
                new Ticket
                {
                    FlightId = 3,
                    Price = 23
                },
                new Ticket
                {
                    FlightId = 3,
                    Price = 45
                },
                new Ticket
                {
                    FlightId = 4,
                    Price = 35
                },
                new Ticket
                {
                    FlightId = 4,
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
                    MaxRange = 11000,
                    MaxSpeed = 1200,
                    NumberOfSeats = 90
                },
                new PlaneType
                {
                    Model = "Type 2",
                    CarryingCapacity = 1100,
                    MaxAltitude = 1900,
                    MaxRange = 10000,
                    MaxSpeed = 1200,
                    NumberOfSeats = 110
                },
                new PlaneType
                {
                    Model = "Type 3",
                    CarryingCapacity = 700,
                    MaxAltitude = 1800,
                    MaxRange = 12000,
                    MaxSpeed = 1400,
                    NumberOfSeats = 200
                },
                new PlaneType
                {
                    Model = "Type 4",
                    CarryingCapacity = 8000,
                    MaxAltitude = 1500,
                    MaxRange = 9000,
                    MaxSpeed = 900,
                    NumberOfSeats = 150
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
                    Lifetime = 14,
                    Name = "Plane 2",
                    PlaneType = planeTypes[1]
                },
                new Plane
                {
                    DateOfRelease = new DateTime(2016, 12, 1),
                    Lifetime = 13,
                    Name = "Plane 3",
                    PlaneType = planeTypes[2]
                },
                new Plane
                {
                    DateOfRelease = new DateTime(2016, 12, 1),
                    Lifetime = 12,
                    Name = "Plane 4",
                    PlaneType = planeTypes[3]
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
                },
                new Flight
                {
                    DateOfArrival = new DateTime(2018, 10, 5, 4, 5, 0),
                    DateOfDeparture = new DateTime(2018, 10, 5, 6, 5, 0),
                    PointOfDeparture = "Paris",
                    Destination = "Amsterdam",
                    Tickets = new List<Ticket>
                    {
                        tickets[4],
                        tickets[5]
                    }
                },
                new Flight
                {
                    DateOfArrival = new DateTime(2018, 10, 5, 4, 5, 0),
                    DateOfDeparture = new DateTime(2018, 10, 5, 6, 5, 0),
                    PointOfDeparture = "Madrid",
                    Destination = "Oslo",
                    Tickets = new List<Ticket>
                    {
                        tickets[6],
                        tickets[7]
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
                },
                new Departure
                {
                    Crew = crews[2],
                    Flight = flights[2],
                    DateOfDeparture = new DateTime(2017, 10, 5, 8, 16, 0),
                    Plane = planes[2]
                },
                new Departure
                {
                    Crew = crews[3],
                    Flight = flights[3],
                    DateOfDeparture = new DateTime(2018, 10, 5, 8, 16, 0),
                    Plane = planes[3]
                },
                new Departure
                {
                    Crew = crews[1],
                    Flight = flights[1],
                    DateOfDeparture = new DateTime(2018, 10, 5, 8, 16, 0),
                    Plane = planes[1]
                },
                new Departure
                {
                    Crew = crews[0],
                    Flight = flights[0],
                    DateOfDeparture = new DateTime(2018, 10, 5, 8, 16, 0),
                    Plane = planes[0]
                },
                new Departure
                {
                    Crew = crews[2],
                    Flight = flights[2],
                    DateOfDeparture = new DateTime(2018, 10, 5, 8, 16, 0),
                    Plane = planes[2]
                },
                new Departure
                {
                    Crew = crews[3],
                    Flight = flights[3],
                    DateOfDeparture = new DateTime(2018, 10, 5, 8, 16, 0),
                    Plane = planes[3]
                }
            };

            context.Departures.AddRange(departures);
            context.SaveChanges();
        }
    }
}