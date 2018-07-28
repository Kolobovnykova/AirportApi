using System;
using System.Collections.Generic;
using AirportApi.Controllers;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Shared.DTOs;
using NUnit.Framework;
using Shared.Exceptions;

namespace AirportApi.Tests.ControllerTests
{
//    [TestFixture]
//    public class PilotControllerTests
//    {
//        private readonly List<PilotDTO> pilots;
//        private Mock<IService<PilotDTO>> service;
//        private PilotController controller;
//
//        public PilotControllerTests()
//        {
//            pilots = new List<PilotDTO>
//            {
//                new PilotDTO { Id = 1, FirstName = "Pilot 1", LastName = "Pilot 11", Experience = 5, DateOfBirth = new DateTime(1960, 8, 30)},
//                new PilotDTO { Id = 2, FirstName = "Pilot 2", LastName = "Pilot 22", Experience = 3, DateOfBirth = new DateTime(1970, 4, 6)},
//                new PilotDTO { Id = 3, FirstName = "Pilot 3", LastName = "Pilot 33", Experience = 7, DateOfBirth = new DateTime(1980, 12, 12)}
//            };
//        }
//
//        private void MockService()
//        {
//            service = new Mock<IService<PilotDTO>>();
//            service.Setup(x => x.GetAll()).Returns(pilots);
//            service.Setup(x => x.GetById(It.IsAny<int>())).Returns((int i) => pilots.Find(x => x.Id == i));
//            service.Setup(x => x.Update(It.IsAny<PilotDTO>()));
//            service.Setup(x => x.Remove(It.IsAny<int>()));
//        }
//
//        [Test]
//        public void GetPilotById_WhenCorrectId_ReturnsOkObjectResult()
//        {
//            MockService();
//            controller = new PilotController(service.Object);
//            int pilotId = 1;
//
//            var result = controller.Get(pilotId);
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            Assert.IsTrue((result as OkObjectResult).StatusCode == 200);
//        }
//
//        [Test]
//        public void GetPilotById_WhenIncorrectId_ReturnsNotFoundObjectResult()
//        {
//            service = new Mock<IService<PilotDTO>>();
//            service.Setup(x => x.GetById(It.IsAny<int>())).Throws<NotFoundException>();
//
//            controller = new PilotController(service.Object);
//            int pilotId = 100;
//
//            var result = controller.Get(pilotId);
//            Assert.IsInstanceOf<NotFoundObjectResult>(result);
//            Assert.IsTrue((result as NotFoundObjectResult).StatusCode == 404);
//        }
//
//        [Test]
//        public void GetPilotById_WhenNegativeId_ReturnsNotFoundObjectResult()
//        {
//            service = new Mock<IService<PilotDTO>>();
//            service.Setup(x => x.GetById(It.IsAny<int>())).Throws<ArgumentException>();
//
//            controller = new PilotController(service.Object);
//            int pilotId = -1;
//
//            var result = controller.Get(pilotId);
//            Assert.IsInstanceOf<BadRequestResult>(result);
//            Assert.IsTrue((result as BadRequestResult).StatusCode == 400);
//        }
//
//        [Test]
//        public void GetAllPilots_ReturnsJsonResult()
//        {
//            MockService();
//            controller = new PilotController(service.Object);
//            var result = controller.Get() as JsonResult;
//
//            Assert.IsInstanceOf<JsonResult>(result);
//            Assert.IsTrue(((List<PilotDTO>) result.Value).Count == 3);
//        }
//
//        [Test]
//        public void PostPilot_WhenValid_ReturnsOkObjectResult()
//        {
//            MockService();
//            controller = new PilotController(service.Object);
//            var result = controller.Create(pilots[0]) as OkObjectResult;
//
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            Assert.IsTrue(result.StatusCode == 200);
//        }
//
//        [Test]
//        public void PostPilot_WhenInvalid_ReturnsBadRequestResult()
//        {
//            service = new Mock<IService<PilotDTO>>();
//            service.Setup(x => x.Add(It.IsAny<PilotDTO>())).Throws<ArgumentNullException>();
//
//            var invalidPilot = new PilotDTO
//            {
//                FirstName = "No last name pilot",
//                Experience = 5,
//                DateOfBirth = new DateTime(1960, 8, 30)
//            };
//
//            controller = new PilotController(service.Object);
//            var result = controller.Create(invalidPilot);
//
//            Assert.IsInstanceOf<BadRequestResult>(result);
//            Assert.IsTrue((result as BadRequestResult).StatusCode == 400);
//        }
//
//        [Test]
//        public void PutPilot_WhenValid_ReturnsOkObjectResult()
//        {
//            MockService();
//            controller = new PilotController(service.Object);
//
//            var result = controller.Update(pilots[0].Id, pilots[0]);
//
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            Assert.IsTrue((result as OkObjectResult).StatusCode == 200);
//        }
//
//        [Test]
//        public void PutPilot_WhenInvalid_ReturnsBadRequestResult()
//        {
//            int pilotId = 100;
//            var invalidPilot = new PilotDTO
//            {
//                FirstName = "No last name pilot",
//                Experience = 5,
//                DateOfBirth = new DateTime(1960, 8, 30)
//            };
//
//            service = new Mock<IService<PilotDTO>>();
//            service.Setup(x => x.Update(It.IsAny<PilotDTO>())).Throws<ArgumentNullException>();
//            controller = new PilotController(service.Object);
//
//            var result = controller.Update(pilotId, invalidPilot);
//
//            Assert.IsInstanceOf<BadRequestResult>(result);
//            Assert.IsTrue((result as BadRequestResult).StatusCode == 400);
//        }
//
//        [Test]
//        public void DeletePilot_WhenCorrectId_ReturnsOkObjectResult()
//        {
//            MockService();
//            controller = new PilotController(service.Object);
//
//            var result = controller.Delete(pilots[0].Id);
//
//            Assert.IsInstanceOf<OkObjectResult>(result);
//            Assert.IsTrue((result as OkObjectResult).StatusCode == 200);
//        }
//
//        [Test]
//        public void DeletePilot_WhenWrongId_ReturnsNotFoundResult()
//        {
//            int pilotId = 100;
//
//            service = new Mock<IService<PilotDTO>>();
//            service.Setup(x => x.Remove(It.IsAny<int>())).Throws<NotFoundException>();
//            controller = new PilotController(service.Object);
//
//            var result = controller.Delete(pilotId);
//
//            Assert.IsInstanceOf<NotFoundObjectResult>(result);
//            Assert.IsTrue((result as NotFoundObjectResult).StatusCode == 404);
//        }
//
//        [Test]
//        public void DeletePilot_WhenNegativeId_ReturnsBadRequestResult()
//        {
//            int pilotId = -1;
//
//            service = new Mock<IService<PilotDTO>>();
//            service.Setup(x => x.Remove(It.IsAny<int>())).Throws<ArgumentException>();
//            controller = new PilotController(service.Object);
//
//            var result = controller.Delete(pilotId);
//
//            Assert.IsInstanceOf<BadRequestResult>(result);
//            Assert.IsTrue((result as BadRequestResult).StatusCode == 400);
//        }
//    }
}