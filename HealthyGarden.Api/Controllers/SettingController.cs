using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Domain.Entities;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Create(Setting setting)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(Setting setting)
        {
            return Ok();
        }
    }
}
