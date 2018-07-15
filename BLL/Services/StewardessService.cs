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
    public class StewardessService : IService<StewardessDTO>
    {
        readonly IUnitOfWork unitOfWork;

        public StewardessService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public StewardessDTO GetById(int id)
        {
            var item = Mapper.Map<Stewardess, StewardessDTO>(unitOfWork.StewardessRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Stewardess with id {id} was not found");
            }

            return item;
        }

        public List<StewardessDTO> GetAll()
        {
            return Mapper.Map<List<Stewardess>, List<StewardessDTO>>(unitOfWork.StewardessRepository.GetAll());
        }

        public void Add(StewardessDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.StewardessRepository.Create(Mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public void Update(StewardessDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            unitOfWork.StewardessRepository.Update(Mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.StewardessRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}