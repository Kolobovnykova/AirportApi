using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace AirportApi.Controllers
{
    [Produces("application/json")]
    [Route("api/stewardesses")]
    public class StewardessController : Controller
    {
        private readonly IService<StewardessDTO> service;

        public StewardessController(IService<StewardessDTO> service)
        {
            this.service = service;
        }

        //GET: api/stewardesses/
        [HttpGet]
        public IActionResult Get()
        {
            return Json(service.GetAll());
        }

        //GET: api/stewardesses/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(service.GetById(id));
        }
    }
}