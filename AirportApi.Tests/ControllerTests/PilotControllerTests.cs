using System;
using System.Collections.Generic;
using AirportApi.Controllers;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shared.DTOs;
using NUnit.Framework;

namespace AirportApi.Tests.ControllerTests
{
    [TestFixture]
    public class PilotControllerTests
    {
        private readonly List<PilotDTO> pilots;
        private Mock<IService<PilotDTO>> service;
        private PilotController controller;

        public PilotControllerTests()
        {
            pilots = new List<PilotDTO>
            {
                new PilotDTO { Id = 1, FirstName = "Pilot 1", LastName = "Pilot 11", Experience = 5, DateOfBirth = new DateTime(1960, 8, 30)},
                new PilotDTO { Id = 2, FirstName = "Pilot 2", LastName = "Pilot 22", Experience = 3, DateOfBirth = new DateTime(1970, 4, 6)},
                new PilotDTO { Id = 3, FirstName = "Pilot 3", LastName = "Pilot 33", Experience = 7, DateOfBirth = new DateTime(1980, 12, 12)}
            };

      //    var service = new PilotService(new FakeUnitOfWork(), IMapper);

              MockService();
        }

        private void MockService()
        {
            service = new Mock<IService<PilotDTO>>();
            service.Setup(x => x.GetAll()).Returns(pilots);
            service.Setup(x => x.GetById(It.IsAny<int>())).Returns((int i) => pilots.Find(x => x.Id == i));
            service.Setup(x => x.Update(It.IsAny<PilotDTO>()));
            service.Setup(x => x.Remove(It.IsAny<int>()));
        }

        [Test]
        public void GetPilotById_ReturnsOkObjectResult()
        {
            controller = new PilotController(service.Object);
            const int pilotId = 1;

            //controller.Get(pilotId);

            //    var mapperMock = new Mock<IMapper>();
            //   mapperMock.Setup(m => m.Map<PilotDTO, Pilot>(It.IsAny<PilotDTO>())).Returns(new Pilot());

            var result = controller.Get(pilotId);
            Assert.IsInstanceOf<OkObjectResult>(result);
        }

        [Test]
        public void GetAllPilots_ReturnsJsonResult()
        {
            controller = new PilotController(service.Object);
            var result = controller.Get();

            Assert.IsInstanceOf<JsonResult>(result);
        }

        [Test]
        public void TestPost()
        {
            controller = new PilotController(service.Object);
            var result = controller.Create(pilots[0]);
        }
    }
}