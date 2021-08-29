using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Api.Models;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        [HttpGet]
        [Route("{Id}")]
        public IActionResult Get(int Id)
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
