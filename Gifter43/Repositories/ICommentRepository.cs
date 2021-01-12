using Gifter43.Models;
using System.Collections.Generic;

namespace Gifter43.Repositories
{
    public interface ICommentRepository
    {
        List<Comment> GetCommentsForPost(int postId);
    }
}