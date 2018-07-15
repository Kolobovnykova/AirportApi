﻿using System;
using System.Collections.Generic;
using AutoMapper;
using BLL.Interfaces;
using DAL.Interfaces;
using DAL.Models;
using Shared.DTOs;
using Shared.Exceptions;

namespace BLL.Services
{
    public class PilotService : IService<PilotDTO>
    {
        readonly IUnitOfWork unitOfWork;

        public PilotService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public PilotDTO GetById(int id)
        {
            var item = Mapper.Map<Pilot, PilotDTO>(unitOfWork.PilotRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Pilot with id {id} was not found");
            }

            return item;
        }

        public List<PilotDTO> GetAll()
        {
            return Mapper.Map<List<Pilot>, List<PilotDTO>>(unitOfWork.PilotRepository.GetAll());
        }

        public void Add(PilotDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null || entity.DateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.PilotRepository.Create(Mapper.Map<PilotDTO, Pilot>(entity));
        }

        public void Update(PilotDTO entity)
        {
            if (entity.FirstName == null || entity.LastName == null || entity.DateOfBirth == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            
            unitOfWork.PilotRepository.Update(Mapper.Map<PilotDTO, Pilot>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.PilotRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}