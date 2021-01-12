using Gifter43.Data;
using Gifter43.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter43.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private ApplicationDbContext _context;

        public CommentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Comment> GetCommentsForPost(int postId)
        {
            return _context.Comment
                .Where(c => c.PostId == postId)
                .ToList();
        }
    }
}
