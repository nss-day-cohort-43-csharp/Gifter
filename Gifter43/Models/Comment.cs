using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gifter43.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int UserProfileId { get; set; }
        public UserProfile UserProfile { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
        public string Message { get; set; }
    }
}
