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
    public class UserLoginRepository : IUserLoginRepository
    {
        private readonly AppDbContext _context;
        public UserLoginRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<UserLogin>> GetAllAsync()
        {
            return await _context.UserLogins.Include(u => u.UserProfile).ToListAsync();
        }

        public async Task<UserLogin> GetByIdAsync(int id)
        {
            return await _context.UserLogins.Include(u => u.UserProfile).FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<UserLogin> CreateAsync(UserLogin user)
        {
            _context.UserLogins.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task UpdateAsync(UserLogin user)
        {
            _context.UserLogins.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(UserLogin user)
        {
            _context.UserLogins.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<UserLogin?> GetUserByUsernameAsync(string username)
        {
            return await _context.UserLogins
                .FirstOrDefaultAsync(u => u.Username == username);
        }
    }
}
