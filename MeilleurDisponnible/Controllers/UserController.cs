using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MeilleurDisponnible.CustomMapper;
using MeilleurDisponnible.Models;
using MeilleurDisponnible.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace MeilleurDisponnible.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public IUserRepository _userRepository;
        public IValidator _userValidator;
        public IMappingProvider _createUserEntityProvider;
        public Mapper _mapper;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _userValidator = new UserValidator();
            _createUserEntityProvider = new UserEntityMappingProvider();
            _mapper = new Mapper(_createUserEntityProvider);
        }

        // GET api/user
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userRepository.GetUsers());
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            UserEntity user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        // POST api/user
        [HttpPost]
        public IActionResult Post([FromBody] CreateUserDTO createUserDTO)
        {
            UserEntity user = _mapper.Map<UserEntity>(createUserDTO);

            var valid = _userValidator.Validate(user);
            if (!valid.IsValid)
            {
                return BadRequest();
            }

            _userRepository.CreateUser(user);

            if (_userRepository.SaveUser() > 0)
            {
                return Created("user/me", user);
            }

            return BadRequest();
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] UserDTO userDTO)
        {
            UserEntity user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            user.Name = userDTO.name;

            var valid = _userValidator.Validate(user);
            if (!valid.IsValid)
            {
                return BadRequest();
            }

            _userRepository.UpdateUser(user);
            if (_userRepository.SaveUser() > 0)
            {
                return Ok(userDTO);
            }

            return BadRequest(); ;
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            UserEntity user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.DeleteUser(user);
            if (_userRepository.SaveUser() > 0)
            {
                return Ok(user);
            }

            return BadRequest(); ;
        }
    }
}
