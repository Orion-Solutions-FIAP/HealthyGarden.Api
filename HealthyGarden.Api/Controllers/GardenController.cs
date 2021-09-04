using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Domain.Entities;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GardenController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(Garden garden)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Garden garden)
        {
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
