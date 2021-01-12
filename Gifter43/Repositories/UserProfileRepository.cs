using Gifter43.Data;
using Gifter43.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter43.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private ApplicationDbContext _context;

        public UserProfileRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<UserProfile> GetAll()
        {
            return _context.UserProfile.ToList();
        }

        public UserProfile GetById(int id)
        {
            return _context.UserProfile.FirstOrDefault(p => p.Id == id);
        }

        public void Add(UserProfile user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public void Update(UserProfile user)
        {
            _context.Entry(user).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var userToDelete = _context.UserProfile
                .Where(u => u.Id == id) // Find the user by id
                .Include(u => u.Comments) // Comments they've made
                .Include(u => u.Posts) // Posts they've written
                .ThenInclude(p => p.Comments); // All Comments on posts they've written

            _context.UserProfile.RemoveRange(userToDelete);
            _context.SaveChanges();
        }
    }
}
