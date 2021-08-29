using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Api.Models;

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
        public IActionResult Get(int Id)
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
            return Ok();
        }
    }
}
