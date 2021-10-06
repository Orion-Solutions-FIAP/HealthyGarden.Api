using System;
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
                return BadRequest(ReturnMessage.IdIsMandatory);
            var garden = _gardenRepository.GetById(id);
            if (garden == null)
                return NotFound(ReturnMessage.GardenNotFound);
            return Ok(garden);
        }

        [HttpGet("user/{userId:int}")]
        public IActionResult GetUser(int userId)
        {
            if (userId <= 0)
                return BadRequest(ReturnMessage.IdIsMandatory);
            var garden = _gardenRepository.GetByUserId(userId);
            if (garden == null)
                return NotFound(ReturnMessage.GardenNotFound);
            return Ok(garden);
        }

        /// <param name="garden">
        /// No parâmetro MoistureStatus, escolha entre as opções:
        /// 1 - Umidade Baixa
        /// 2 -	Umidade	Alta
        /// 3 -	Umidade	Neutra
        /// No parâmetro TemperatureStatus, escolha entre as opções:
        /// 1 -	Temperatura	Alta
        /// 2 -	Temperatura	Baixa
        /// 3 -	Temperatura	Neutra
        /// </param>
        [HttpPost]
        public IActionResult Create(Garden garden)
        {
            if (!StatusExists(garden.MoistureStatus))
                return NotFound(ReturnMessage.MoistureStatusNotExist);

            if (!StatusExists(garden.TemperatureStatus))
                return NotFound(ReturnMessage.TemperatureStatusNotExist);


            var newGarden = _gardenRepository.Insert(garden);
            return CreatedAtAction("Get", new { newGarden.Id }, newGarden);
        }


        /// <param name="garden">
        /// No parâmetro MoistureStatus, escolha entre as opções:
        /// 1 - Umidade Baixa
        /// 2 -	Umidade	Alta
        /// 3 -	Umidade	Neutra
        /// No parâmetro TemperatureStatus, escolha entre as opções:
        /// 1 -	Temperatura	Alta
        /// 2 -	Temperatura	Baixa
        /// 3 -	Temperatura	Neutra
        /// </param>
        [HttpPut]
        public IActionResult Update(Garden garden)
        {
            if (garden.Id <= 0)
                return BadRequest(ReturnMessage.IdIsMandatory);

            if (!StatusExists(garden.MoistureStatus))
                return NotFound(ReturnMessage.MoistureStatusNotExist);

            if (!StatusExists(garden.TemperatureStatus))
                return NotFound(ReturnMessage.TemperatureStatusNotExist);

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

        private bool StatusExists<T>(T status) => Enum.IsDefined(typeof(T), status);
    }
}
