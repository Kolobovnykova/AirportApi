using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Shared.DTOs;

namespace BLL.Services
{
    public class PlaneService : IService<PlaneDTO>
    {
        readonly IUnitOfWork unitOfWork;

        public PlaneService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PlaneDTO GetById(int id)
        {
            var item = Mapper.Map<Plane, PlaneDTO>(unitOfWork.PlaneRepository.Get(id).FirstOrDefault());

            if (item == null)
            {
                throw new Exception($"Plane with id {id} was not found");
            }

            return item;
        }

        public List<PlaneDTO> GetAll()
        {
            return Mapper.Map<List<Plane>, List<PlaneDTO>>(unitOfWork.PlaneRepository.Get());
        }

        public void Add(PlaneDTO entity)
        {
            unitOfWork.PlaneRepository.Create(Mapper.Map<PlaneDTO, Plane>(entity));
        }

        public void Update(PlaneDTO entity)
        {
            unitOfWork.PlaneRepository.Update(Mapper.Map<PlaneDTO, Plane>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.PlaneRepository.Delete(id);
        }
    }
}