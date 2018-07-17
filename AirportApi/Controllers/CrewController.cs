using System;
using System.ComponentModel.DataAnnotations;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;
using Shared.Exceptions;

namespace AirportApi.Controllers
{
    [Produces("application/json")]
    [Route("api/crews")]
    public class CrewController : Controller
    {
        private readonly IService<CrewDTO> service;

        public CrewController(IService<CrewDTO> service)
        {
            this.service = service;
        }

        //GET: api/crews/
        [HttpGet]
        public IActionResult Get()
        {
            return Json(service.GetAll());
        }

        //GET: api/crews/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var item = service.GetById(id);
                return Ok(item);
            }
            catch (ValidationException e)
            {
                return NotFound(e.Message);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        // [Route("api/crews/")]
        public IActionResult Create([FromBody] CrewDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                service.Add(item);
                service.SaveChanges();
                return Ok(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] CrewDTO item)
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
            catch (Exception)
            {
                return BadRequest();
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
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}