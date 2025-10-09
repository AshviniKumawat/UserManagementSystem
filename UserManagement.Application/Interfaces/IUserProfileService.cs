using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Entities.Entities;

namespace UserManagement.Application.Interfaces
{
    public interface IUserProfileService
    {
        Task<IEnumerable<UserProfileDto>> GetAllAsync();
        Task<UserProfileDto> GetByIdAsync(int id);
        Task<UserProfileDto> CreateAsync(UserProfileDto dto);
        Task<bool> UpdateAsync(int id, UserProfileDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
