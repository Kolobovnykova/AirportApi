using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace AirportApi.Controllers
{
    [Produces("application/json")]
    [Route("api/tickets")]
    public class TicketController : Controller
    {
        private readonly IService<TicketDTO> service;

        public TicketController(IService<TicketDTO> service)
        {
            this.service = service;
        }

        //GET: api/tickets/
        [HttpGet]
        public IActionResult Get()
        {
            return Json(service.GetAll());
        }

        //GET: api/tickets/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] TicketDTO item)
        {
            service.Add(item);
            return Ok();
        }

        [HttpPut("{id})")]
        public IActionResult Update([FromBody] TicketDTO item)
        {
            service.Update(item);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            service.Remove(id);
            return Ok();
        }
    }
}