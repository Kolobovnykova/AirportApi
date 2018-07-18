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
    public class FlightService : IService<FlightDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public FlightService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<FlightDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Flight, FlightDTO>(await unitOfWork.FlightRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Flight with id {id} was not found");
            }

            return item;
        }

        public async Task<List<FlightDTO>> GetAll()
        {
            return mapper.Map<List<Flight>, List<FlightDTO>>(await unitOfWork.FlightRepository.GetAll());
        }

        public async Task Add(FlightDTO entity)
        {
            if (entity.Destination == null || entity.PointOfDeparture == null || entity.Tickets == null ||
                entity.DateOfArrival == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.FlightRepository.Create(mapper.Map<FlightDTO, Flight>(entity));
        }

        public async Task Update(FlightDTO entity)
        {
            if (entity.Destination == null || entity.PointOfDeparture == null || entity.Tickets == null ||
                entity.DateOfArrival == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.FlightRepository.Update(mapper.Map<FlightDTO, Flight>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            await unitOfWork.FlightRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}