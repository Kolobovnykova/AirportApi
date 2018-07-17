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
    public class CrewService : IService<CrewDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CrewService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public CrewDTO GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Crew, CrewDTO>(unitOfWork.CrewRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Crew with id {id} was not found");
            }

            return item;
        }

        public List<CrewDTO> GetAll()
        {
            return mapper.Map<List<Crew>, List<CrewDTO>>(unitOfWork.CrewRepository.GetAll());
        }

        public void Add(CrewDTO entity)
        {
            if (entity.Pilot == null || entity.Stewardesses == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.CrewRepository.Create(mapper.Map<CrewDTO, Crew>(entity));
        }

        public void Update(CrewDTO entity)
        {
            if (entity.Pilot == null || entity.Stewardesses == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.CrewRepository.Update(mapper.Map<CrewDTO, Crew>(entity));
        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            unitOfWork.CrewRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}