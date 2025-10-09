using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.DataLayer.Data;
using UserManagement.DataLayer.Interfaces;
using UserManagement.Entities.Entities;

namespace UserManagement.DataLayer.Repositories
{
    public class UserProfileRepository : IUserProfileRepository
    {
        private readonly AppDbContext _context;
        public UserProfileRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<UserProfile>> GetAllAsync()
        {
            return await _context.UserProfiles.Include(p => p.UserLogin).ToListAsync();
        }

        public async Task<UserProfile> GetByIdAsync(int id)
        {
            return await _context.UserProfiles.Include(p => p.UserLogin).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<UserProfile> CreateAsync(UserProfile profile)
        {
            _context.UserProfiles.Add(profile);
            await _context.SaveChangesAsync();
            return profile;
        }

        public async Task UpdateAsync(UserProfile profile)
        {
            _context.UserProfiles.Update(profile);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserProfile profile)
        {
            var userProfile = await _context.UserProfiles
                .Include(up => up.UserLogin)
                    .FirstOrDefaultAsync(up => up.Id == profile.UserLoginId);
            _context.UserProfiles.Remove(profile);
            await _context.SaveChangesAsync();
        }
    }
}
