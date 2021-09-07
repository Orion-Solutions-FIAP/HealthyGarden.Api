using HealthyGarden.Api.Constants;
using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository _settingRepository;

        public SettingController(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest(new { Message = ReturnMessage.IdIsMandatory });
            var setting = _settingRepository.GetById(id);
            if (setting == null)
                return NotFound(new { Message = ReturnMessage.SettingNotFound });
            return Ok(setting);
        }

        [HttpPost]
        public IActionResult Create(Setting setting)
        {
            var newSetting = _settingRepository.Insert(setting);
            return CreatedAtAction("Get", new { newSetting.GardenId }, newSetting);
        }

        [HttpPut]
        public IActionResult Update(Setting setting)
        {
            if (setting.GardenId <= 0)
                return BadRequest(new { Message = ReturnMessage.IdIsMandatory });
            if (_settingRepository.GetById(setting.GardenId) == null)
                return NotFound(new { Message = ReturnMessage.SettingNotFound });
            return Ok(_settingRepository.Update(setting));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest(new { Message = ReturnMessage.IdIsMandatory });
            if (_settingRepository.GetById(id) == null)
                return NotFound(new { Message = ReturnMessage.SettingNotFound });
            _settingRepository.Delete(id);
            return Ok();
        }
    }
}
