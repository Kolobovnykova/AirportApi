using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<PlaneTypeDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<PlaneType, PlaneTypeDTO>(await unitOfWork.PlaneTypeRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Planetype with id {id} was not found");
            }

            return item;
        }

        public async Task<List<PlaneTypeDTO>> GetAll()
        {
            return mapper.Map<List<PlaneType>, List<PlaneTypeDTO>>(await unitOfWork.PlaneTypeRepository.GetAll());
        }

        public async Task Add(PlaneTypeDTO entity)
        {
            if (entity.Model == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.PlaneTypeRepository.Create(mapper.Map<PlaneTypeDTO, PlaneType>(entity));
        }

        public async Task Update(PlaneTypeDTO entity)
        {
            if (entity.Model == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.PlaneTypeRepository.Update(mapper.Map<PlaneTypeDTO, PlaneType>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            await unitOfWork.PlaneTypeRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}