using Gifter43.Models;
using System.Collections.Generic;

namespace Gifter43.Repositories
{
    public interface IUserProfileRepository
    {
        void Add(UserProfile user);
        void Delete(int id);
        List<UserProfile> GetAll();
        UserProfile GetById(int id);
        void Update(UserProfile user);
    }
}