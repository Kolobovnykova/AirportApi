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
    public class PlaneService : IService<PlaneDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlaneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<PlaneDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Plane, PlaneDTO>(await unitOfWork.PlaneRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Plane with id {id} was not found");
            }

            return item;
        }

        public async Task<List<PlaneDTO>> GetAll()
        {
            return mapper.Map<List<Plane>, List<PlaneDTO>>(await unitOfWork.PlaneRepository.GetAll());
        }

        public async Task Add(PlaneDTO entity)
        {
            if (entity.PlaneType == null || entity.Name == null || entity.DateOfRelease == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.PlaneRepository.Create(mapper.Map<PlaneDTO, Plane>(entity));
        }

        public async Task Update(PlaneDTO entity)
        {
            if (entity.PlaneType == null || entity.Name == null || entity.DateOfRelease == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.PlaneRepository.Update(mapper.Map<PlaneDTO, Plane>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            await unitOfWork.PlaneRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}