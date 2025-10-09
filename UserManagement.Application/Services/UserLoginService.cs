using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Application.DTOs;
using UserManagement.Application.Interfaces;
using UserManagement.DataLayer.Interfaces;
using UserManagement.Entities.Entities;

namespace UserManagement.Application.Services
{
    public class UserLoginService : IUserLoginService
    {
        private readonly IUserLoginRepository _repo;
        public UserLoginService(IUserLoginRepository repo) => _repo = repo;

        public async Task<IEnumerable<UserLoginDto>> GetAllAsync()
        {
            var users = await _repo.GetAllAsync();
            return users.Select(u => new UserLoginDto
            {
                Id = u.Id,
                Username = u.Username,
                UserProfile = u.UserProfile == null ? null : new UserProfileDto
                {
                    Id = u.UserProfile.Id,
                    FullName = u.UserProfile.FullName,
                    Email = u.UserProfile.Email
                }
            });
        }

        public async Task<UserLoginDto> GetByIdAsync(int id)
        {
            var u = await _repo.GetByIdAsync(id);
            if (u == null) return null;
            return new UserLoginDto
            {
                Id = u.Id,
                Username = u.Username,
                UserProfile = u.UserProfile == null ? null : new UserProfileDto
                {
                    Id = u.UserProfile.Id,
                    FullName = u.UserProfile.FullName,
                    Email = u.UserProfile.Email
                }
            };
        }

        public async Task<UserLoginDto> CreateAsync(CreateUserLoginDto dto)
        {
            var user = new UserLogin
            {
                Username = dto.Username,
                Password = dto.Password,
                UserProfile = dto.UserProfile == null ? null : new UserProfile
                {
                    FullName = dto.UserProfile.FullName,
                    Email = dto.UserProfile.Email
                }
            };
            var created = await _repo.CreateAsync(user);
            return await GetByIdAsync(created.Id);
        }

        public async Task<bool> UpdateAsync(int id, CreateUserLoginDto dto)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;

            user.Username = dto.Username;
            if (!string.IsNullOrEmpty(dto.Password))
                user.Password = dto.Password;

            if (dto.UserProfile != null)
            {
                if (user.UserProfile == null) user.UserProfile = new UserProfile();
                user.UserProfile.FullName = dto.UserProfile.FullName;
                user.UserProfile.Email = dto.UserProfile.Email;
            }

            await _repo.UpdateAsync(user);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var user = await _repo.GetByIdAsync(id);
            if (user == null) return false;
            await _repo.DeleteAsync(user);
            return true;
        }
    }
}
