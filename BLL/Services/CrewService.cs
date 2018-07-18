using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Shared.DTOs;
using Shared.Exceptions;

namespace BLL.Services
{
    public class CrewService : IService<CrewDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

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

        public async Task Add(CrewDTO entity)
        {
            if (entity.Pilot == null || entity.Stewardesses == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.CrewRepository.Create(mapper.Map<CrewDTO, Crew>(entity));
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
    }
}