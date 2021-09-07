using System;
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
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet]
        [Route("number")]
        public IActionResult GetNumberOfUsers()
        {
            return Ok(new { NumberOfUsers = _userRepository.GetNumberOfUsers()});
        }

        [HttpGet("{id:int}")]
        public IActionResult Get(int id)
        {
            try
            {
                var user = _userRepository.GetById(id);
                if (user == null)
                    return NotFound(new {Message = "Usuário não encontrado"});
                return Ok(user);
            }
            catch (Exception e)
            {
                return StatusCode(500, new {e.Message});
            }
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            return Ok(_userRepository.Insert(user));
        }

        [HttpPut]
        public IActionResult Update(User user)
        {
            return Ok(_userRepository.Update(user));
        }
    }
}
