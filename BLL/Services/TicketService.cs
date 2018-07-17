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
    public class TicketService : IService<TicketDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public TicketDTO GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Ticket, TicketDTO>(unitOfWork.TicketRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Ticket with id {id} was not found");
            }

            return item;
        }

        public List<TicketDTO> GetAll()
        {
            return mapper.Map<List<Ticket>, List<TicketDTO>>(unitOfWork.TicketRepository.GetAll());
        }

        public void Add(TicketDTO entity)
        {
            if (entity.FlightId == 0)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.TicketRepository.Create(mapper.Map<TicketDTO, Ticket>(entity));
        }

        public void Update(TicketDTO entity)
        {
            if (entity.FlightId == 0)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            unitOfWork.TicketRepository.Update(mapper.Map<TicketDTO, Ticket>(entity));
        }

        public void Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            unitOfWork.TicketRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}