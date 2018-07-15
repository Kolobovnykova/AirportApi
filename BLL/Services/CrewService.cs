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

        public CrewService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public CrewDTO GetById(int id)
        {
            var item = Mapper.Map<Crew, CrewDTO>(unitOfWork.CrewRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Crew with id {id} was not found");
            }

            return item;
        }

        public List<CrewDTO> GetAll()
        {
            return Mapper.Map<List<Crew>, List<CrewDTO>>(unitOfWork.CrewRepository.GetAll());
        }

        public void Add(CrewDTO entity)
        {
            if (entity.Pilot == null || entity.Stewardesses == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            unitOfWork.CrewRepository.Create(Mapper.Map<CrewDTO, Crew>(entity));
        }

        public void Update(CrewDTO entity)
        {
            if (entity.Pilot == null || entity.Stewardesses == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            unitOfWork.CrewRepository.Update(Mapper.Map<CrewDTO, Crew>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.CrewRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}