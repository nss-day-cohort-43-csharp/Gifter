using Gifter43.Data;
using Gifter43.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter43.Repositories
{
    public class PostRepository : IPostRepository
    {
        private ApplicationDbContext _context;

        public PostRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Post> GetAll()
        {
            return _context.Post
                .Include(p => p.UserProfile)
                .Take(3)
                .OrderByDescending(p => p.DateCreated)
                .ToList();
        }

        public List<Post> GetByUserProfileId(int id)
        {
            return _context.Post
                .Where(p => p.UserProfileId == id)
                .OrderBy(p => p.Title)
                .ToList();
        }

        public Post GetById(int id)
        {
            return _context.Post
                .Include(p => p.UserProfile)
                .Include(p => p.Comments)
                .FirstOrDefault(p => p.Id == id);
        }

        public void Add(Post post)
        {
            _context.Add(post);
            _context.SaveChanges();
        }

        public void Update(Post post)
        {
            _context.Entry(post).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var post = GetById(id);
            _context.Post.Remove(post);

            _context.SaveChanges();
        }

        public List<Post> Search(string searchTerm, bool oldestFirst)
        {
            var query = _context.Post
                .Where(p => p.Title.Contains(searchTerm));
 
            if (oldestFirst == true)
            {
                return query.OrderBy(p => p.DateCreated).ToList();
            }
            else
            {
                return query.OrderByDescending(p => p.DateCreated).ToList();
            }

        }
    }
}
