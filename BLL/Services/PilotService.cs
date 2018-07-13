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
    public class PilotService : IService<PilotDTO>
    {
        readonly IUnitOfWork unitOfWork;

        public PilotService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PilotDTO GetById(int id)
        {
            var item = Mapper.Map<Pilot, PilotDTO>(unitOfWork.PilotRepository.Get(id).FirstOrDefault());

            if (item == null)
            {
                throw new ValidationException($"Pilot with id {id} was not found");
            }

            return item;
        }

        public List<PilotDTO> GetAll()
        {
            return Mapper.Map<List<Pilot>, List<PilotDTO>>(unitOfWork.PilotRepository.Get());
        }

        public void Add(PilotDTO entity)
        {
            unitOfWork.PilotRepository.Create(Mapper.Map<PilotDTO, Pilot>(entity));
        }

        public void Update(PilotDTO entity)
        {
            unitOfWork.PilotRepository.Update(Mapper.Map<PilotDTO, Pilot>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.PilotRepository.Delete(id);
        }
    }
}