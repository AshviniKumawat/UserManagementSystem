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
    public class UserProfileService : IUserProfileService
    {
        private readonly IUserProfileRepository _repo;
        public UserProfileService(IUserProfileRepository repo) => _repo = repo;

        public async Task<IEnumerable<UserProfileDto>> GetAllAsync()
        {
            var profiles = await _repo.GetAllAsync();
            return profiles.Select(p => new UserProfileDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Email = p.Email,
            });
        }

        public async Task<UserProfileDto> GetByIdAsync(int id)
        {
            var p = await _repo.GetByIdAsync(id);
            if (p == null) return null;
            return new UserProfileDto
            {
                Id = p.Id,
                FullName = p.FullName,
                Email = p.Email
            };
        }

        public async Task<UserProfileDto> CreateAsync(UserProfileDto dto)
        {
            var profile = new UserProfile
            {
                FullName = dto.FullName,
                Email = dto.Email
            };
            var created = await _repo.CreateAsync(profile);
            return await GetByIdAsync(created.Id);
        }

        public async Task<bool> UpdateAsync(int id, UserProfileDto dto)
        {
            var profile = await _repo.GetByIdAsync(id);
            if (profile == null) return false;

            profile.FullName = dto.FullName;
            profile.Email = dto.Email;

            await _repo.UpdateAsync(profile);
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var profile = await _repo.GetByIdAsync(id);
            if (profile == null) return false;
            await _repo.DeleteAsync(profile);
            return true;
        }
    }
}
