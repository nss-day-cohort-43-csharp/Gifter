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
    public class PostsController : ControllerBase
    {
        private IPostRepository _postRepo;

        public PostsController(IPostRepository postRepo)
        {
            _postRepo = postRepo;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var posts = _postRepo.GetAll();
            return Ok(posts);
        }

        [HttpGet("search")]
        public IActionResult Search(string criterion, bool oldestFirst)
        {
            if (criterion == null)
            {
                return Ok(_postRepo.GetAll());
            }

            var posts = _postRepo.Search(criterion, oldestFirst);
            return Ok(posts);
        }


        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var post = _postRepo.GetById(id);
            
            if (post == null)
            {
                return NotFound();
            }

            return Ok(post);
        }

        [HttpGet("getbyuser/{id}")]
        public IActionResult GetByUser(int id)
        {
            return Ok(_postRepo.GetByUserProfileId(id));
        }

        [HttpPost]
        public IActionResult Add(Post post)
        {
            post.DateCreated = DateTime.Now;

            _postRepo.Add(post);
            return Ok(post);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            var existingPost = _postRepo.GetById(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            _postRepo.Update(post);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var existingPost = _postRepo.GetById(id);

            if (existingPost == null)
            {
                return NotFound();
            }

            _postRepo.Delete(id);
            return NoContent();
        }
    }
}
