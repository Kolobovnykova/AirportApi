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
    public class PlaneTypeService : IService<PlaneTypeDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlaneTypeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public PlaneTypeDTO GetById(int id)
        {
            var item = mapper.Map<PlaneType, PlaneTypeDTO>(unitOfWork.PlaneTypeRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Planetype with id {id} was not found");
            }

            return item;
        }

        public List<PlaneTypeDTO> GetAll()
        {
            return mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(unitOfWork.PlaneTypeRepository.GetAll());
        }

        public void Add(PlaneTypeDTO entity)
        {
            if (entity.Model == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.PlaneTypeRepository.Create(mapper.Map<PlaneTypeDTO, PlaneType>(entity));
        }

        public void Update(PlaneTypeDTO entity)
        {
            if (entity.Model == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.PlaneTypeRepository.Update(mapper.Map<PlaneTypeDTO, PlaneType>(entity));
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