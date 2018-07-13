using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Shared.DTOs;

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
            var item = Mapper.Map<Flight, FlightDTO>(unitOfWork.FlightRepository.Get(id).FirstOrDefault());

            if (item == null)
            {
                throw new Exception($"Flight with id {id} was not found");
            }

            return item;
        }

        public List<FlightDTO> GetAll()
        {
            return Mapper.Map<List<Flight>, List<FlightDTO>>(unitOfWork.FlightRepository.Get());
        }

        public void Add(FlightDTO entity)
        {
            unitOfWork.FlightRepository.Create(Mapper.Map<FlightDTO, Flight>(entity));
        }

        public void Update(FlightDTO entity)
        {
            unitOfWork.FlightRepository.Update(Mapper.Map<FlightDTO, Flight>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.FlightRepository.Delete(id);
        }
    }
}