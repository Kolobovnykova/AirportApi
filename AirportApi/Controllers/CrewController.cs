using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
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
        private readonly ICrewService service;

        public CrewController(ICrewService service)
        {
            this.service = service;
        }

        //GET: api/crews/
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Json(await service.GetAll());
        }

        //GET: api/crews/id
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var item = await service.GetById(id);
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

        [HttpGet("firstTen")]
        public async Task<IActionResult> GetFirstTen()
        {
            try
            {
                return Ok(await service.LoadTenCrews());
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        // [Route("api/crews/")]
        public async Task<IActionResult> Create([FromBody] CrewDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await service.Add(item);
                await service.SaveChanges();
                return Ok(item);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CrewDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                item.Id = id;
                await service.GetById(id);
                await service.Update(item);
                await service.SaveChanges();
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var item = await service.GetById(id);
                await service.Remove(id);
                await service.SaveChanges();
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