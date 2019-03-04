using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AirportApi.Tests.FakeObjects;
using AutoMapper;
using BLL.Services;
using NUnit.Framework;
using Shared.DTOs;
using Shared.Exceptions;

namespace AirportApi.Tests.ServiceTests
{
    [TestFixture]
    public class CrewServiceTests
    {
        private readonly FakeUnitOfWork fakeUnitOfWork;
        private readonly IMapper mapper;

        public CrewServiceTests()
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
        public async Task GetCrewById_WhenCorrectId_ReturnsCrew()
        {
            var id = 1;
            var service = new CrewService(fakeUnitOfWork, mapper);

            var result = await service.GetById(id);

            Assert.IsTrue(result != null);
        }

        [Test, Order(2)]
        public void GetCrewById_WhenWrongId_ThrowsNotFoundException()
        {
            var id = 10;
            var service = new CrewService(fakeUnitOfWork, mapper);

            Assert.ThrowsAsync<NotFoundException>(
                () => service.GetById(id));
        }

        [Test, Order(3)]
        public void GetCrewById_WhenNegativeId_ThrowsArgumentException()
        {
            var id = -1;
            var service = new CrewService(fakeUnitOfWork, mapper);

            Assert.ThrowsAsync<ArgumentException>(
                () => service.GetById(id));
        }

        [Test, Order(4)]
        public async Task CreateCrew_WhenValid_ShouldCreateCrewInDb()
        {
            var crew = new CrewDTO
            {
                Pilot = new PilotDTO
                {
                    FirstName = "crewPilotFirst",
                    LastName = "crewPilotLast",
                    DateOfBirth = new DateTime(1992, 5, 30),
                    Experience = 1
                },
                Stewardesses = new List<StewardessDTO>
                {
                    new StewardessDTO
                    {
                        FirstName = "crewSt1",
                        LastName = "crewStLast1",
                        DateOfBirth = new DateTime(1970, 05, 03)
                    },
                    new StewardessDTO
                    {
                        FirstName = "crewSt2",
                        LastName = "crewStLast2",
                        DateOfBirth = new DateTime(1990, 11, 09)
                    }
                }
            };

            var service = new CrewService(fakeUnitOfWork, mapper);

            await service.Add(crew);

            var result = fakeUnitOfWork.CrewRepository.GetAll().Result.FirstOrDefault(
                x => x.Pilot.FirstName == "crewPilotFirst" && x.Stewardesses.Count == 2);

            Assert.IsNotNull(result);
        }

        [Test, Order(5)]
        public void CreateCrew_WhenInvalid_ThrowsArgumentNullException()
        {
            var crew = new CrewDTO
            {
                Stewardesses = new List<StewardessDTO>
                {
                    new StewardessDTO
                    {
                        FirstName = "crewSt1",
                        LastName = "crewStLast1",
                        DateOfBirth = new DateTime(1970, 05, 03)
                    },
                    new StewardessDTO
                    {
                        FirstName = "crewSt2",
                        LastName = "crewStLast2",
                        DateOfBirth = new DateTime(1990, 11, 09)
                    }
                }
            };

            var service = new CrewService(fakeUnitOfWork, mapper);

            Assert.ThrowsAsync<ArgumentNullException>(
                () => service.Add(crew));
        }

        [Test, Order(6)]
        public void UpdateCrew_WhenInvalid_ThrowsArgumentNullException()
        {
            var crew = new CrewDTO
            {
                Stewardesses = new List<StewardessDTO>
                {
                    new StewardessDTO
                    {
                        FirstName = "Maria",
                        LastName = "Petrova",
                        DateOfBirth = new DateTime(1970, 05, 03)
                    },
                    new StewardessDTO
                    {
                        FirstName = "Anna",
                        LastName = "Ivanova",
                        DateOfBirth = new DateTime(1990, 11, 09)
                    }
                }
            };

            var service = new CrewService(fakeUnitOfWork, mapper);

            Assert.ThrowsAsync<ArgumentNullException>(
                () => service.Update(crew));
        }

        [Test, Order(7)]
        public async Task DeleteCrew_WhenCorrectId_DeletesCrew()
        {
            var id = 1;
            var service = new CrewService(fakeUnitOfWork, mapper);

            await service.Remove(id);

            Assert.ThrowsAsync<NotFoundException>(
                () => service.GetById(id));
        }

        [Test, Order(8)]
        public void DeleteCrew_WhenWrongId_ThrowsNotFoundException()
        {
            var id = 10;
            var service = new CrewService(fakeUnitOfWork, mapper);

            Assert.ThrowsAsync<NotFoundException>(
                () => service.Remove(id));
        }

        [Test, Order(9)]
        public void DeleteCrew_WhenNegativeId_ThrowsArgumentException()
        {
            var id = -1;
            var service = new CrewService(fakeUnitOfWork, mapper);

            Assert.ThrowsAsync<ArgumentException>(
                () => service.Remove(id));
        }
    }
}