using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricController : ControllerBase
    {
        private readonly IHistoricRepository _historicRepository;
        public HistoricController(IHistoricRepository historicRepository)
        {
            _historicRepository = historicRepository;
        }

        [HttpGet]
        public IActionResult GetHistoric()
        {
            return Ok("Under development :B");
        }

        [HttpPost]
        public IActionResult Create(Historic historic)
        {
            _historicRepository.Insert(historic);
            return Ok();
        }

        [HttpGet("garden/{gardenId:int}")]
        public IActionResult GetByGarden(int gardenId)
        {
            return Ok(_historicRepository.GetByGardenId(gardenId));
        }
    }
}
