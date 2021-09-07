using HealthyGarden.Api.Constants;
using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenController : ControllerBase
    {
        private readonly IGardenRepository _gardenRepository;

        public GardenController(IGardenRepository gardenRepository)
        {
            _gardenRepository = gardenRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest(new { Message = ReturnMessage.IdIsMandatory });
            var garden = _gardenRepository.GetById(id);
            if (garden == null)
                return NotFound(new { Message = ReturnMessage.GardenNotFound });
            return Ok(garden);
        }

        [HttpPost]
        public IActionResult Create(Garden garden)
        {
            var newGarden = _gardenRepository.Insert(garden);
            return CreatedAtAction("Get", new { newGarden.Id }, newGarden);
        }

        [HttpPut]
        public IActionResult Update(Garden garden)
        {
            if (garden.Id <= 0)
                return BadRequest(new { Message = ReturnMessage.IdIsMandatory });
            if (_gardenRepository.GetById(garden.Id) == null)
                return NotFound(new { Message = ReturnMessage.GardenNotFound });
            return Ok(_gardenRepository.Update(garden));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new { Message = ReturnMessage.IdIsMandatory });
            if (_gardenRepository.GetById(id) == null)
                return NotFound(new { Message = ReturnMessage.GardenNotFound });
            _gardenRepository.Delete(id);
            return Ok();
        }

        [HttpGet]
        [Route("historic")]
        public IActionResult GetHistoric()
        {
            //Adicionar Cache
            return Ok();
        }
    }
}
