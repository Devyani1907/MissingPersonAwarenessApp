using System;
using System.Collections.Generic;

#nullable disable

namespace MissingPersonWebApp.Data
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedTime { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
