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
    public class TicketService : IService<TicketDTO>
    {
        readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public TicketService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<TicketDTO> GetById(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            var item = mapper.Map<Ticket, TicketDTO>(await unitOfWork.TicketRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Ticket with id {id} was not found");
            }

            return item;
        }

        public async Task<List<TicketDTO>> GetAll()
        {
            return mapper.Map<List<Ticket>, List<TicketDTO>>(await unitOfWork.TicketRepository.GetAll());
        }

        public async Task Add(TicketDTO entity)
        {
            if (entity.FlightId == 0)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.TicketRepository.Create(mapper.Map<TicketDTO, Ticket>(entity));
        }

        public async Task Update(TicketDTO entity)
        {
            if (entity.FlightId == 0)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            await unitOfWork.TicketRepository.Update(mapper.Map<TicketDTO, Ticket>(entity));
        }

        public async Task Remove(int id)
        {
            if (id < 0)
            {
                throw new ArgumentException();
            }
            
            await unitOfWork.TicketRepository.Delete(id);
        }

        public async Task SaveChanges()
        {
            await unitOfWork.SaveChangesAsync();
        }
    }
}