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
    public class PilotService : IService<PilotDTO>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PilotService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public PilotDTO GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Pilot, PilotDTO>(unitOfWork.PilotRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Pilot with id {id} was not found");
            }

            return item;
        }

        public List<PilotDTO> GetAll()
        {
            return mapper.Map<List<Pilot>, List<PilotDTO>>(unitOfWork.PilotRepository.GetAll());
        }

        public void Add(PilotDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null || entity.DateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.PilotRepository.Create(mapper.Map<PilotDTO, Pilot>(entity));
        }

        public void Update(PilotDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null || entity.DateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.PilotRepository.Update(mapper.Map<PilotDTO, Pilot>(entity));
        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            unitOfWork.PilotRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}