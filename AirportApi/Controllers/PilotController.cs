﻿using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace AirportApi.Controllers
{
    [Produces("application/json")]
    [Route("api/pilots")]
    public class PilotController : Controller
    {
        private readonly IService<PilotDTO> service;

        public PilotController(IService<PilotDTO> service)
        {
            this.service = service;
        }

        //GET: api/pilots/
        [HttpGet]
        public IActionResult Get()
        {
            return Json(service.GetAll());
        }

        //GET: api/pilots/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(service.GetById(id));
        }
    }
}