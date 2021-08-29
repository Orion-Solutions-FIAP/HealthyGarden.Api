using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Api.Models;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
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
        public IActionResult Create(User user)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            return Ok();
        }
    }
}
