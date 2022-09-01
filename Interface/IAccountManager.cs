using SiotohBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace SiotohBlog.Interface
{
    public interface IAccountManager
    {
        UserViewModel GetAllUsersWithClaims();

        // Task<IEnumerable<UserViewModel>> AllUsers();
        UserViewModel AllUsers();
        Task<bool> CreateUserAsync(ApplicationUser user, string password);
        Task<ApplicationUser> GetUserByIdAsync(int userId);
        Task<ApplicationUser> GetUserByUserNameAsync(string userName);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IList<string>> GetUserRolesAsync(ApplicationUser user);
        Task<IEnumerable<ApplicationUser>> GetUsers();
    }
}
