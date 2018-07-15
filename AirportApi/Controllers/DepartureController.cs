using System.ComponentModel.DataAnnotations;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Exceptions;

namespace AirportApi.Controllers
{
    [Produces("application/json")]
    [Route("api/departures")]
    public class DepartureController : Controller
    {
        private readonly IService<DepartureDTO> service;

        public DepartureController(IService<DepartureDTO> service)
        {
            this.service = service;
        }

        //GET: api/departures/
        [HttpGet]
        public IActionResult Get()
        {
            return Json(service.GetAll());
        }

        //GET: api/departures/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var item = service.GetById(id);
                return Ok(item);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] DepartureDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Add(item);
            service.SaveChanges();
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] DepartureDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                item.Id = id;
                service.GetById(id);
                service.Update(item);
                service.SaveChanges();
                return Ok(item);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = service.GetById(id);
                service.Remove(id);
                service.SaveChanges();
                return Ok(item);
            }
            catch (NotFoundException e)
            {
                return NotFound(e.Message);
            }
        }
    }
}