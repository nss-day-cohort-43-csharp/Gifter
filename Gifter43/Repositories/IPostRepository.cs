using Gifter43.Models;
using System.Collections.Generic;

namespace Gifter43.Repositories
{
    public interface IPostRepository
    {
        void Add(Post post);
        void Delete(int id);
        List<Post> GetAll();
        Post GetById(int id);
        List<Post> GetByUserProfileId(int id);
        void Update(Post post);
        List<Post> Search(string searchTerm, bool recent);
    }
}