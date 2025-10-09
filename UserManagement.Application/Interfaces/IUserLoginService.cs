using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Entities.Entities;

namespace UserManagement.Application.Interfaces
{
    public interface IUserLoginService
    {
        Task<IEnumerable<UserLoginDto>> GetAllAsync();
        Task<UserLoginDto> GetByIdAsync(int id);
        Task<UserLoginDto> CreateAsync(CreateUserLoginDto dto);
        Task<bool> UpdateAsync(int id, CreateUserLoginDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
