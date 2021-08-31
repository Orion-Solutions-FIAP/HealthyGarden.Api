using Microsoft.AspNetCore.Mvc;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EchoController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("It's running =D !!");
        }
    }
}
