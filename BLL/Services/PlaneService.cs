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
    public class PlaneService : IService<PlaneDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PlaneService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public PlaneDTO GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Plane, PlaneDTO>(unitOfWork.PlaneRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Plane with id {id} was not found");
            }

            return item;
        }

        public List<PlaneDTO> GetAll()
        {
            return mapper.Map<List<Plane>, List<PlaneDTO>>(unitOfWork.PlaneRepository.GetAll());
        }

        public void Add(PlaneDTO entity)
        {
            if (entity.PlaneType == null || entity.Name == null || entity.DateOfRelease == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.PlaneRepository.Create(mapper.Map<PlaneDTO, Plane>(entity));
        }

        public void Update(PlaneDTO entity)
        {
            if (entity.PlaneType == null || entity.Name == null || entity.DateOfRelease == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.PlaneRepository.Update(mapper.Map<PlaneDTO, Plane>(entity));
        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            unitOfWork.PlaneRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}