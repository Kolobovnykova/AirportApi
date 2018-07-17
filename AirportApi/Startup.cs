using AutoMapper;
using BLL.Interfaces;
using BLL.Services;
using DAL.Implementation;
using DAL.Implementation.Repositories;
using DAL.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRepository<Plane>, PlaneRepository>();
            services.AddScoped<IRepository<PlaneType>, PlaneTypeRepository>();
            services.AddScoped<IRepository<Crew>, CrewRepository>();
            services.AddScoped<IRepository<Departure>, DepartureRepository>();
            services.AddScoped<IRepository<Flight>, FlightRepository>();
            services.AddScoped<IRepository<Pilot>, PilotRepository>();
            services.AddScoped<IRepository<Stewardess>, StewardessRepository>();
            services.AddScoped<IRepository<Ticket>, TicketRepository>();
            services.AddScoped<IService<PlaneDTO>, PlaneService>();
            services.AddScoped<IService<PlaneTypeDTO>, PlaneTypeService>();
            services.AddScoped<IService<CrewDTO>, CrewService>();
            services.AddScoped<IService<DepartureDTO>, DepartureService>();
            services.AddScoped<IService<FlightDTO>, FlightService>();
            services.AddScoped<IService<PilotDTO>, PilotService>();
            services.AddScoped<IService<StewardessDTO>, StewardessService>();
            services.AddScoped<IService<TicketDTO>, TicketService>();
            services.AddScoped<IMapper>(m => MapperConfigurations.GetMapper().CreateMapper());

            services.AddDbContext<AirportContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ConnectionStringAirportDb"),
                    b => b.MigrationsAssembly("DAL")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            using (var scope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                var context = scope.ServiceProvider.GetService<AirportContext>();
                context.Database.EnsureCreated();
                AirportDbInitializer.Initialize(context);
            }

            app.UseMvc();
        }
    }
}