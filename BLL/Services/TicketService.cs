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

        public TicketService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public TicketDTO GetById(int id)
        {
            var item = Mapper.Map<Ticket, TicketDTO>(unitOfWork.TicketRepository.Get(id));

            if (item == null)
            {
                throw new NotFoundException($"Ticket with id {id} was not found");
            }

            return item;
        }

        public List<TicketDTO> GetAll()
        {
            return Mapper.Map<List<Ticket>, List<TicketDTO>>(unitOfWork.TicketRepository.GetAll());
        }

        public void Add(TicketDTO entity)
        {
            unitOfWork.TicketRepository.Create(Mapper.Map<TicketDTO, Ticket>(entity));
        }

        public void Update(TicketDTO entity)
        {
            unitOfWork.TicketRepository.Update(Mapper.Map<TicketDTO, Ticket>(entity));
        }

        public void Remove(int id)
        {
            unitOfWork.TicketRepository.Delete(id);
        }

        public void SaveChanges()
        {
            unitOfWork.SaveChanges();
        }
    }
}