using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

namespace AirportApi.Controllers
{
    [Produces("application/json")]
    [Route("api/planes")]
    public class PlaneController : Controller
    {
        private readonly IService<PlaneDTO> service;

        public PlaneController(IService<PlaneDTO> service)
        {
            this.service = service;
        }

        //GET: api/planes/
        [HttpGet]
        public IActionResult Get()
        {
            return Json(service.GetAll());
        }

        //GET: api/planes/id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Json(service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlaneDTO item)
        {
            service.Add(item);
            return Ok();
        }

        [HttpPut("{id})")]
        public IActionResult Update([FromBody] PlaneDTO item)
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