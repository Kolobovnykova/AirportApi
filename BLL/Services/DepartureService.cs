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
    public class DepartureService : IService<DepartureDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public DepartureService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public DepartureDTO GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Departure, DepartureDTO>(unitOfWork.DepartureRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Departure with id {id} was not found");
            }

            return item;
        }

        public List<DepartureDTO> GetAll()
        {
            return mapper.Map<List<Departure>, List<DepartureDTO>>(unitOfWork.DepartureRepository.GetAll());
        }

        public void Add(DepartureDTO entity)
        {
            if (entity.Crew == null || entity.Flight == null || entity.Plane == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.DepartureRepository.Create(mapper.Map<DepartureDTO, Departure>(entity));
        }

        public void Update(DepartureDTO entity)
        {
            if (entity.Crew == null || entity.Flight == null || entity.Plane == null || entity.DateOfDeparture == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.DepartureRepository.Update(mapper.Map<DepartureDTO, Departure>(entity));
        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            unitOfWork.DepartureRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}