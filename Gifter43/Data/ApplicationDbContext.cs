using Gifter43.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter43.Data
{
    // This is the C# representation of our whole database
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Post> Post { get; set; }
        public DbSet<UserProfile> UserProfile { get; set; }
        public DbSet<Comment> Comment { get; set; }

    }
}
