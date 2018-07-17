using AutoMapper;
using BLL.Services;
using DAL.Implementation;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using Ninject.Modules;
using Shared.DTOs;

namespace AirportApi.Tests
{
    public class AirportModule : NinjectModule
    {
        public override void Load()
        {
            Bind<PilotService>().ToSelf();
            Bind<IUnitOfWork>().To<UnitOfWork>();
            Bind<IMapper>().ToMethod(context =>
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

                return config.CreateMapper();
            }).InSingletonScope();

            var connectionString = @"Server=(LocalDb)\\MSSQLLocalDB;Database=AirportDb;Trusted_Connection=True;";

            var options = new DbContextOptionsBuilder<AirportContext>()
                .UseSqlServer(connectionString, x => x.MigrationsAssembly("DAL")).Options;

            Bind<AirportContext>().ToSelf().WithConstructorArgument("options", options);
        }
    }
}