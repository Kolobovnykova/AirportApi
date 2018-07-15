using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Shared.DTOs;
using Shared.Exceptions;

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
            var item = Mapper.Map<PlaneType, PlaneTypeDTO>(unitOfWork.PlaneTypeRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Planetype with id {id} was not found");
            }

            return item;
        }

        public List<PlaneTypeDTO> GetAll()
        {
            return Mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(unitOfWork.PlaneTypeRepository.GetAll());
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

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}