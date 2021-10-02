using System;
using HealthyGarden.Api.Constants;
using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Entities.Enum;
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
                return BadRequest(ReturnMessage.IdIsMandatory);
            var garden = _gardenRepository.GetById(id);
            if (garden == null)
                return NotFound(ReturnMessage.GardenNotFound);
            return Ok(garden);
        }

        /// <param name="garden">
        /// No parâmetro StatusId, escolha entre as opções:
        /// 1 - Umidade	Baixa
        /// 2 -	Umidade	Alta
        /// 3 -	Umidade	Neutra
        /// 4 -	Temperatura	Alta
        /// 5 -	Temperatura	Baixa
        /// 6 -	Temperatura	Neutra
        /// </param>
        [HttpPost]
        public IActionResult Create(Garden garden)
        {
            if (!StatusExists(garden.StatusId))
                return NotFound(ReturnMessage.StatusNotExist);

            var newGarden = _gardenRepository.Insert(garden);
            return CreatedAtAction("Get", new { newGarden.Id }, newGarden);
        }

        /// <param name="garden">
        /// No parâmetro StatusId, escolha entre as opções:
        /// 1 - Umidade	Baixa
        /// 2 -	Umidade	Alta
        /// 3 -	Umidade	Neutra
        /// 4 -	Temperatura	Alta
        /// 5 -	Temperatura	Baixa
        /// 6 -	Temperatura	Neutra
        /// </param>
        [HttpPut]
        public IActionResult Update(Garden garden)
        {
            if (garden.Id <= 0)
                return BadRequest(ReturnMessage.IdIsMandatory);

            if (!StatusExists(garden.StatusId))
                return NotFound(ReturnMessage.StatusNotExist);

            if (_gardenRepository.GetById(garden.Id) == null)
                return NotFound(ReturnMessage.GardenNotFound);

            return Ok(_gardenRepository.Update(garden));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest(ReturnMessage.IdIsMandatory);
            if (_gardenRepository.GetById(id) == null)
                return NotFound(ReturnMessage.GardenNotFound);
            _gardenRepository.Delete(id);
            return Ok(ReturnMessage.SuccessfullyDeleted);
        }

        private bool StatusExists(Status status) => Enum.IsDefined(typeof(Status), status);
    }
}
