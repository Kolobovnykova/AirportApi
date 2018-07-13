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
    public class StewardessService : IService<StewardessDTO>
    {
        readonly IUnitOfWork unitOfWork;

        public StewardessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public StewardessDTO GetById(int id)
        {
            var item = Mapper.Map<Stewardess, StewardessDTO>(unitOfWork.StewardessRepository.Get(id).FirstOrDefault());

            if (item == null)
            {
                throw new ValidationException($"Stewardess with id {id} was not found");
            }

            return item;
        }

        public List<StewardessDTO> GetAll()
        {
            return Mapper.Map<List<Stewardess>, List<StewardessDTO>>(unitOfWork.StewardessRepository.Get());
        }

        public void Add(StewardessDTO entity)
        {
            unitOfWork.StewardessRepository.Create(Mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public void Update(StewardessDTO entity)
        {
            unitOfWork.StewardessRepository.Update(Mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.StewardessRepository.Delete(id);
        }
    }
}