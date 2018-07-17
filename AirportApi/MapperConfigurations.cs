using AutoMapper;
using DAL.Models;
using Shared.DTOs;

namespace AirportApi
{
    public static class MapperConfigurations
    {
        public static MapperConfiguration GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Flight, FlightDTO>();
                cfg.CreateMap<FlightDTO, Flight>();
                cfg.CreateMap<Departure, DepartureDTO>();
                cfg.CreateMap<DepartureDTO, Departure>();
                cfg.CreateMap<Pilot, PilotDTO>();
                cfg.CreateMap<PilotDTO, Pilot>();
                cfg.CreateMap<Crew, CrewDTO>();
                cfg.CreateMap<CrewDTO, Crew>();
                cfg.CreateMap<Plane, PlaneDTO>();
                cfg.CreateMap<PlaneDTO, Plane>();
                cfg.CreateMap<PlaneType, PlaneTypeDTO>();
                cfg.CreateMap<PlaneTypeDTO, PlaneType>();
                cfg.CreateMap<Stewardess, StewardessDTO>();
                cfg.CreateMap<StewardessDTO, Stewardess>();
                cfg.CreateMap<Ticket, TicketDTO>();
                cfg.CreateMap<TicketDTO, Ticket>();
            });

            return config;
        }
    }
}