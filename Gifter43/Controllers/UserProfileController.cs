using Gifter43.Models;
using Gifter43.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter43.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private IUserProfileRepository _repo;

        public UserProfileController(IUserProfileRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var allUsers = _repo.GetAll();
            return Ok(allUsers);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repo.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        public IActionResult Add(UserProfile user)
        {
            user.DateCreated = DateTime.Now;

            _repo.Add(user);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, UserProfile user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            var existingUser = _repo.GetById(id);

            if (existingUser == null)
            {
                return NotFound();
            }

            _repo.Update(user);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repo.GetById(id);

            if (user == null)
            {
                return NotFound();
            }

            _repo.Delete(id);
            return NoContent();
        }
    }
}
