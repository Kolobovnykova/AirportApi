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
    public class PilotService : IService<PilotDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PilotDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Pilot, PilotDTO>(await unitOfWork.PilotRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Pilot with id {id} was not found");
            }

            return item;
        }

        public async Task<List<PilotDTO>> GetAll()
        {
            return mapper.Map<List<Pilot>, List<PilotDTO>>(await unitOfWork.PilotRepository.GetAll());
        }

        public async Task Add(PilotDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null || entity.DateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.PilotRepository.Create(mapper.Map<PilotDTO, Pilot>(entity));
        }

        public async Task Update(PilotDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null || entity.DateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.PilotRepository.Update(mapper.Map<PilotDTO, Pilot>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            await unitOfWork.PilotRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}