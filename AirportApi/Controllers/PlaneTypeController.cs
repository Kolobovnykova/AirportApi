﻿using System.ComponentModel.DataAnnotations;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace AirportApi.Controllers
{
    [Produces("application/json")]
    [Route("api/planetypes")]
    public class PlaneTypeController : Controller
    {
        private readonly IService<PlaneTypeDTO> service;

        public PlaneTypeController(IService<PlaneTypeDTO> service)
        {
            this.service = service;
        }

        //GET: api/planetypes/
        [HttpGet]
        public IActionResult Get()
        {
            return Json(service.GetAll());
        }

        //GET: api/planetypes/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var item = service.GetById(id);
                return Ok(item);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlaneTypeDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            service.Add(item);
            return Ok(item);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody] PlaneTypeDTO item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                service.GetById(item.Id);
                service.Update(item);
                return Ok(item);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var item = service.GetById(id);
                service.Remove(id);
                return Ok(item);
            }
            catch (ValidationException)
            {
                return NotFound();
            }
        }
    }
}