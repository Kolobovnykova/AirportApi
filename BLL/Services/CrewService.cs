using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Newtonsoft.Json;
using Shared.DTOs;
using Shared.Exceptions;

namespace BLL.Services
{
    public class CrewService : ICrewService
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private const string Endpoint = "http://5b128555d50a5c0014ef1204.mockapi.io/crew";

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<CrewDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }

            var item = mapper.Map<Crew, CrewDTO>(await unitOfWork.CrewRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Crew with id {id} was not found");
            }

            return item;
        }

        public async Task<List<CrewDTO>> GetAll()
        {
            return mapper.Map<List<Crew>, List<CrewDTO>>(await unitOfWork.CrewRepository.GetAll());
        }

        public async Task<List<CrewDTO>> GetFirstItems(string endpoint, int count = 10)
        {
            var client = new HttpClient();
            var response = await client.GetAsync(endpoint);

            response.EnsureSuccessStatusCode();

            string content = await response.Content.ReadAsStringAsync();
            var deserializedList = JsonConvert.DeserializeObject<List<ExternalCrewDTO>>(content);
            var firstItems = deserializedList.Take(count).ToList();

            CustomMapper(firstItems, out var list);

            return list;
        }

        public async Task Add(CrewDTO entity)
        {
            if (entity.Pilot == null || entity.Stewardesses == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.CrewRepository.Create(mapper.Map<CrewDTO, Crew>(entity));
        }

        public async Task AddRange(List<CrewDTO> entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.CrewRepository.CreateRange(mapper.Map<List<CrewDTO>, List<Crew>>(entity));
        }

        public async Task Update(CrewDTO entity)
        {
            if (entity.Pilot == null || entity.Stewardesses == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.CrewRepository.Update(mapper.Map<CrewDTO, Crew>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }

            await unitOfWork.CrewRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }

        public async Task<List<CrewDTO>> LoadTenCrews()
        {
            // get first 10
            var items = await GetFirstItems(Endpoint);
            // write to db
            var addTask = AddRange(items);
            var saveTask = SaveChanges();
            // write to csv
            var writeTask = FileHelpers.WriteTextAsync(items);
            await Task.WhenAll(addTask, saveTask, writeTask);
            return items;
        }

        private void CustomMapper(List<ExternalCrewDTO> external, out List<CrewDTO> crew)
        {
            crew = new List<CrewDTO>();
            foreach (var item in external)
            {
                var stews = new List<StewardessDTO>();
                foreach (var externalStew in item.stewardess)
                {
                    var stewDto = new StewardessDTO
                    {
                        DateOfBirth = externalStew.birthDate,
                        CrewId = externalStew.crewId,
                        FirstName = externalStew.firstName,
                        LastName = externalStew.lastName
                    };

                    stews.Add(stewDto);
                }

                var crewDto = new CrewDTO
                {
                    Id = item.id,
                    Pilot = new PilotDTO
                    {
                        DateOfBirth = item.pilot[0].birthDate,
                        Experience = item.pilot[0].exp,
                        FirstName = item.pilot[0].firstName,
                        LastName = item.pilot[0].lastName
                    },
                    Stewardesses = new List<StewardessDTO>(stews)
                };

                crew.Add(crewDto);
            }
        }
    }
}