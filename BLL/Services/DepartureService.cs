using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Shared.DTOs;
using Shared.Exceptions;

namespace BLL.Services
{
    public class DepartureService : IService<DepartureDTO>
    {
        readonly IUnitOfWork unitOfWork;

        public DepartureService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public DepartureDTO GetById(int id)
        {
            var item = Mapper.Map<Departure, DepartureDTO>(unitOfWork.DepartureRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Departure with id {id} was not found");
            }

            return item;
        }

        public List<DepartureDTO> GetAll()
        {
            return Mapper.Map<List<Departure>, List<DepartureDTO>>(unitOfWork.DepartureRepository.GetAll());
        }

        public void Add(DepartureDTO entity)
        {
            unitOfWork.DepartureRepository.Create(Mapper.Map<DepartureDTO, Departure>(entity));
        }

        public void Update(DepartureDTO entity)
        {
            unitOfWork.DepartureRepository.Update(Mapper.Map<DepartureDTO, Departure>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.DepartureRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}