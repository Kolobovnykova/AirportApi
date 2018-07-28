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
    public class DepartureService : IService<DepartureDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<DepartureDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Departure, DepartureDTO>(await unitOfWork.DepartureRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Departure with id {id} was not found");
            }

            return item;
        }

        public async Task<List<DepartureDTO>> GetAll()
        {
            return mapper.Map<List<Departure>, List<DepartureDTO>>(await unitOfWork.DepartureRepository.GetAll());
        }

        public async Task Add(DepartureDTO entity)
        {
            if (entity.Crew == null || entity.Flight == null || entity.Plane == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.DepartureRepository.Create(mapper.Map<DepartureDTO, Departure>(entity));
        }

        public async Task Update(DepartureDTO entity)
        {
            if (entity.Crew == null || entity.Flight == null || entity.Plane == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.DepartureRepository.Update(mapper.Map<DepartureDTO, Departure>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            await unitOfWork.DepartureRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}