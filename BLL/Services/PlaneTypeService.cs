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
    public class PlaneTypeService : IService<PlaneTypeDTO>
    {
        readonly IUnitOfWork unitOfWork;

        public PlaneTypeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PlaneTypeDTO GetById(int id)
        {
            var item = Mapper.Map<PlaneType, PlaneTypeDTO>(unitOfWork.PlaneTypeRepository.Get(id).FirstOrDefault());

            if (item == null)
            {
                throw new ValidationException($"Planetype with id {id} was not found");
            }

            return item;
        }

        public List<PlaneTypeDTO> GetAll()
        {
            return Mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(unitOfWork.PlaneTypeRepository.Get());
        }

        public void Add(PlaneTypeDTO entity)
        {
            unitOfWork.PlaneTypeRepository.Create(Mapper.Map<PlaneTypeDTO, PlaneType>(entity));
        }

        public void Update(PlaneTypeDTO entity)
        {
            unitOfWork.PlaneTypeRepository.Update(Mapper.Map<PlaneTypeDTO, PlaneType>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.PlaneTypeRepository.Delete(id);
        }
    }
}