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
            return Json(service.GetById(id));
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlaneTypeDTO item)
        {
            service.Add(item);
            return Ok();
        }

        [HttpPut("{id})")]
        public IActionResult Update([FromBody] PlaneTypeDTO item)
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