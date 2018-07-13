using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Shared.DTOs;

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
            var crew = Mapper.Map<Crew, CrewDTO>(unitOfWork.CrewRepository.Get(id).FirstOrDefault());

            if (crew == null)
            {
                throw new Exception($"Crew with id {id} was not found");
            }

            return crew;
        }

        public List<CrewDTO> GetAll()
        {
            return Mapper.Map<List<Crew>, List<CrewDTO>>(unitOfWork.CrewRepository.Get());
        }

        public void Add(CrewDTO entity)
        {
            unitOfWork.CrewRepository.Create(Mapper.Map<CrewDTO, Crew>(entity));
        }

        public void Update(CrewDTO entity)
        {
            unitOfWork.CrewRepository.Update(Mapper.Map<CrewDTO, Crew>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.CrewRepository.Delete(id);
        }
    }
}