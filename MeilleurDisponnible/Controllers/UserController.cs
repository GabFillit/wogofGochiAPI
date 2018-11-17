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
        public ActionResult<List<UserEntity>> Get()
        {
            return _userRepository.GetUsers();
        }

        // GET api/user/5
        [HttpGet("{id}")]
        public ActionResult<UserEntity> Get(int id)
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
        public void Post([FromBody] string name)
        {
            _userRepository.CreateUser(name);
        }

        // PUT api/user/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string name)
        {
            if (_userRepository.UpdateUser(id, name))
            {
                return Ok();
            }
            return NotFound();
        }

        // DELETE api/user/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userRepository.DeleteUser(id);
        }
    }
}
