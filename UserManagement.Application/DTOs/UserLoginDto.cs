using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs
{
    public class UserLoginDto
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;

        // Optional: include profile info
        public UserProfileDto? UserProfile { get; set; }
    }
}
