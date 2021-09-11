using HealthyGarden.Api.Constants;
using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        [Route("number")]
        public IActionResult GetNumberOfUsers()
        {
            return Ok(new { NumberOfUsers = _userRepository.GetNumberOfUsers() });
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest(ReturnMessage.IdIsMandatory);
            var user = _userRepository.GetById(id);
            if (user == null)
                return NotFound(ReturnMessage.UserNotFound);
            return Ok(user);
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            var newUser = _userRepository.Insert(user);
            return CreatedAtAction("Get", new { newUser.Id }, newUser);
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            if (user.Id <= 0)
                return BadRequest(ReturnMessage.IdIsMandatory);
            if (_userRepository.GetById(user.Id) == null)
                return NotFound(ReturnMessage.UserNotFound);
            return Ok(_userRepository.Update(user));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest(ReturnMessage.IdIsMandatory);
            if (_userRepository.GetById(id) == null)
                return NotFound(ReturnMessage.UserNotFound);
            _userRepository.Delete(id);
            return Ok(ReturnMessage.SuccessfullyDeleted);
        }
    }
}
