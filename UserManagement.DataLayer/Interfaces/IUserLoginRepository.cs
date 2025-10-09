using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Entities.Entities;

namespace UserManagement.DataLayer.Interfaces
{
    public interface IUserLoginRepository
    {
        Task<IEnumerable<UserLogin>> GetAllAsync();
        Task<UserLogin> GetByIdAsync(int id);
        Task<UserLogin> CreateAsync(UserLogin user);
        Task UpdateAsync(UserLogin user);
        Task DeleteAsync(UserLogin user);
        Task<UserLogin?> GetUserByUsernameAsync(string username);
    }
}
