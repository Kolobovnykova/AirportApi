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
    public class StewardessService : IService<StewardessDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public StewardessService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<StewardessDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Stewardess, StewardessDTO>(await unitOfWork.StewardessRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Stewardess with id {id} was not found");
            }

            return item;
        }

        public async Task<List<StewardessDTO>> GetAll()
        {
            return mapper.Map<List<Stewardess>, List<StewardessDTO>>(await unitOfWork.StewardessRepository.GetAll());
        }

        public async Task Add(StewardessDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.StewardessRepository.Create(mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public async Task Update(StewardessDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.StewardessRepository.Update(mapper.Map<StewardessDTO, Stewardess>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            await unitOfWork.StewardessRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}