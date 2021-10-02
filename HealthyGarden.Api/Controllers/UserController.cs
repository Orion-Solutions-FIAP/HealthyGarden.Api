using System.Threading.Tasks;
using HealthyGarden.Api.Constants;
using Microsoft.AspNetCore.Mvc;
using HealthyGarden.Domain.Entities;
using HealthyGarden.Domain.Interfaces;
using HealthyGarden.Infrastructure.Enum;
using HealthyGarden.Service.Interfaces;
using HealthyGarden.Service.Services;
using Microsoft.AspNetCore.Authorization;

namespace HealthyGarden.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;

        public UserController(IUserService userService, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] User user)
        {
            var authStatus = _userService.ValidateUser(user);

            if (authStatus == AuthStatus.UserNotFound)
                return NotFound(ReturnMessage.UserNotFound);
            if (authStatus == AuthStatus.WrongPassword)
                return BadRequest(ReturnMessage.WrongPassword);

            return Ok(new { token = TokenService.GenerateToken(user) });
        }

        [HttpGet]
        public IActionResult GetByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return BadRequest();
            
            var user = _userRepository.GetByEmail(email);
            
            if (user == null)
                return NotFound(ReturnMessage.UserNotFound);

            return Ok(user);
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
