using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Application.DTOs
{
    public class CreateUserLoginDto
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public CreateUserProfileDto? UserProfile { get; set; }
    }

    public class CreateUserProfileDto
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
