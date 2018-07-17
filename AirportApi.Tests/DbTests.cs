using System.Linq;
using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using Ninject;
using NUnit.Framework;
using Shared.DTOs;

namespace AirportApi.Tests
{
    [TestFixture]
    public class DbTests
    {
        private IService<PilotDTO> pilotService;
        private IUnitOfWork unitOfWork;

        public DbTests()
        {
            var kernel = new StandardKernel(new AirportModule());
            pilotService = kernel.Get<PilotService>();
            unitOfWork = kernel.Get<IUnitOfWork>();
            unitOfWork.Seed();
        }

        [Test]
        public void DbTest()
        {
            var pilot = pilotService.GetAll().Last();

            pilot.FirstName = "Pilot1";

            pilotService.SaveChanges();

            var newPilot = pilotService.GetAll().FirstOrDefault(p => p.FirstName == "Pilot1");

            Assert.False(newPilot == null);
        }
    }
}