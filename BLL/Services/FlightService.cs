using System;
using System.Collections.Generic;
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

        public FlightService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public FlightDTO GetById(int id)
        {
            var item = Mapper.Map<Flight, FlightDTO>(unitOfWork.FlightRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Flight with id {id} was not found");
            }

            return item;
        }

        public List<FlightDTO> GetAll()
        {
            return Mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.GetAll());
        }

        public void Add(FlightDTO entity)
        {
            if (entity.Destination == null || entity.PointOfDeparture == null || entity.Tickets == null ||
                entity.DateOfArrival == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.FlightRepository.Create(Mapper.Map<FlightDTO, Flight>(entity));
        }

        public void Update(FlightDTO entity)
        {
            if (entity.Destination == null || entity.PointOfDeparture == null || entity.Tickets == null ||
                entity.DateOfArrival == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            unitOfWork.FlightRepository.Update(Mapper.Map<FlightDTO, Flight>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.FlightRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}