using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserManagement.Entities.Entities
{
    public class UserProfile
    {
        public int Id { get; set; }
        public int UserLoginId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // Navigation
        public UserLogin? UserLogin { get; set; }
    }
}
