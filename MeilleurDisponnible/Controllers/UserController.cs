using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
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
        public IActionResult Post([FromBody] string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Name is empty");
            }

            int id =_userRepository.CreateUser(name);
            return Ok(id);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] string name)
        {
            if (String.IsNullOrEmpty(name))
            {
                return BadRequest("Name is empty");
            }

            UserEntity user = _userRepository.GetUser(id);
            if (user == null)
            {
                return NotFound();
            }

            _userRepository.UpdateUser(user, name);
            return Ok();
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
            return Ok();
        }
    }
}
