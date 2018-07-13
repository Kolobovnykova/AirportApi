using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Shared.DTOs;

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
            return Json(service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] DepartureDTO item)
        {
            service.Add(item);
            return Ok();
        }

        [HttpPut("{id})")]
        public IActionResult Update([FromBody] DepartureDTO item)
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