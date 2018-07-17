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
        private readonly IMapper mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public StewardessDTO GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Stewardess, StewardessDTO>(unitOfWork.StewardessRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Stewardess with id {id} was not found");
            }

            return item;
        }

        public List<StewardessDTO> GetAll()
        {
            return mapper.Map<List<Stewardess>, List<StewardessDTO>>(unitOfWork.StewardessRepository.GetAll());
        }

        public void Add(StewardessDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.StewardessRepository.Create(mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public void Update(StewardessDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.StewardessRepository.Update(mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            unitOfWork.StewardessRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}