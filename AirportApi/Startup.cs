using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Implementation;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Shared.DTOs;

namespace AirportApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();

            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IDataSource, DataSource>();
            services.AddScoped<IRepository<Plane>, Repository<Plane>>();
            services.AddScoped<IRepository<PlaneType>, Repository<PlaneType>>();
            services.AddScoped<IRepository<Crew>, Repository<Crew>>();
            services.AddScoped<IRepository<Departure>, Repository<Departure>>();
            services.AddScoped<IRepository<Flight>, Repository<Flight>>();
            services.AddScoped<IRepository<Pilot>, Repository<Pilot>>();
            services.AddScoped<IRepository<Stewardess>, Repository<Stewardess>>();
            services.AddScoped<IRepository<Ticket>, Repository<Ticket>>();
            services.AddScoped<IService<PlaneDTO>, PlaneService>();
            services.AddScoped<IService<PlaneTypeDTO>, PlaneTypeService>();
            services.AddScoped<IService<CrewDTO>, CrewService>();
            services.AddScoped<IService<DepartureDTO>, DepartureService>();
            services.AddScoped<IService<FlightDTO>, FlightService>();
            services.AddScoped<IService<PilotDTO>, PilotService>();
            services.AddScoped<IService<StewardessDTO>, StewardessService>();
            services.AddScoped<IService<TicketDTO>, TicketService>();

            Mapper.Initialize(cfg =>
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
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}