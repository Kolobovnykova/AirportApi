using System;
using System.Linq;
using AirportApi.Tests.FakeObjects;
using AutoMapper;
using BLL.Services;
using NUnit.Framework;
using Shared.DTOs;
using Shared.Exceptions;

namespace AirportApi.Tests.ServiceTests
{
    [TestFixture]
    public class PilotServiceTests
    {
        private readonly FakeUnitOfWork fakeUnitOfWork;
        private readonly IMapper mapper;

        public PilotServiceTests()
        {
            fakeUnitOfWork = new FakeUnitOfWork();
            mapper = MapperConfigurations.GetMapper().CreateMapper();
        }

        [SetUp]
        public void TestSetup()
        {
            fakeUnitOfWork.Seed();
        }

        [TearDown]
        public void TestTearDown()
        {
            fakeUnitOfWork.DropDb();
        }

        [Test, Order(1)]
        public void GetPilotById_WhenCorrectId_ReturnsPilot()
        {
            var id = 1;
            var service = new PilotService(fakeUnitOfWork, mapper);

            var result = service.GetById(id);

            Assert.IsTrue(result != null);
        }

        [Test, Order(2)]
        public void GetPilotById_WhenWrongId_ThrowsNotFoundException()
        {
            var id = 10;
            var service = new PilotService(fakeUnitOfWork, mapper);

            Assert.Throws<NotFoundException>(
                () => service.GetById(id));
        }
        
        [Test, Order(3)]
        public void GetPilotById_WhenNegativeId_ThrowsArgumentException()
        {
            var id = -1;
            var service = new PilotService(fakeUnitOfWork, mapper);

            Assert.Throws<ArgumentException>(
                () => service.GetById(id));
        }

        [Test, Order(4)]
        public void CreatePilot_WhenValid_ShouldCreatePilotInDb()
        {
            var pilot = new PilotDTO
            {
                FirstName = "test_pilot",
                LastName = "test_pilot2",
                DateOfBirth = new DateTime(1990, 12, 2),
                Experience = 2
            };

            var service = new PilotService(fakeUnitOfWork, mapper);

            service.Add(pilot);

            var result = fakeUnitOfWork.PilotRepository.GetAll().FirstOrDefault(
                x => x.FirstName == "test_pilot" && x.LastName == "test_pilot2" && x.Experience == 2);

            Assert.IsNotNull(result);
        }

        [Test, Order(5)]
        [TestCase(null, "test_name")]
        [TestCase("test_name", null)]
        public void CreatePilot_WhenInvalid_ThrowsArgumentNullException(string fName, string lName)
        {
            var pilot = new PilotDTO
            {
                FirstName = fName,
                LastName = lName,
                DateOfBirth = new DateTime(1990, 12, 2),
                Experience = 2
            };

            var service = new PilotService(fakeUnitOfWork, mapper);

            Assert.Throws<ArgumentNullException>(
                () => service.Add(pilot));
        }
        
        [Test, Order(6)]
        public void UpdatePilot_WhenValid_UpdatesPilot()
        {
            var pilot = new PilotDTO
            {
                Id = 1,
                FirstName = "UpdatedIvan",
                LastName = "Ivanov",
                DateOfBirth = new DateTime(1960, 8, 30),
                Experience = 9
            };

            var service = new PilotService(fakeUnitOfWork, mapper);

            service.Update(pilot);

            var result = fakeUnitOfWork.PilotRepository.GetAll().FirstOrDefault(
                x => x.FirstName == "UpdatedIvan");
            
            Assert.IsNotNull(result);
        }
        
        [Test, Order(7)]
        public void UpdatePilot_WhenInvalid_ThrowsArgumentNullException()
        {
            var pilot = new PilotDTO
            {
                Id = 1,
                LastName = "Ivanov",
                DateOfBirth = new DateTime(1960, 8, 30),
                Experience = 9
            };

            var service = new PilotService(fakeUnitOfWork, mapper);

            Assert.Throws<ArgumentNullException>(
                () => service.Update(pilot));
        }
        
        [Test, Order(8)]
        public void UpdatePilot_WhenNotExistingInBase_ThrowsArgumentNullException()
        {
            var pilot = new PilotDTO
            {
                Id = 10,
                LastName = "test_pilot_lastname",
                DateOfBirth = new DateTime(1990, 8, 30),
                Experience = 5
            };

            var service = new PilotService(fakeUnitOfWork, mapper);

            Assert.Throws<ArgumentNullException>(
                () => service.Update(pilot));
        }

        [Test, Order(9)]
        public void DeletePilot_WhenCorrectId_DeletesPilot()
        {
            var id = 1;
            var service = new PilotService(fakeUnitOfWork, mapper);

            service.Remove(id);

            Assert.Throws<NotFoundException>(
                () => service.GetById(id));
        }

        [Test, Order(10)]
        public void DeletePilot_WhenWrongId_ThrowsNotFoundException()
        {
            var id = 10;
            var service = new PilotService(fakeUnitOfWork, mapper);

            Assert.Throws<NotFoundException>(
                () => service.Remove(id));
        }
        
        [Test, Order(11)]
        public void DeletePilot_WhenNegativeId_ThrowsArgumentException()
        {
            var id = -1;
            var service = new PilotService(fakeUnitOfWork, mapper);

            Assert.Throws<ArgumentException>(
                () => service.Remove(id));
        }
    }
}