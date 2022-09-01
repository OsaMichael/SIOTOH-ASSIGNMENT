using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SiotohBlog.Interface;
using SiotohBlog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static SiotohBlog.Models.UserModel;

namespace SiotohBlog.Repository
{
    public class AccountManager : IAccountManager
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountManager(
              UserManager<ApplicationUser> userManager,
              RoleManager<IdentityRole> roleManager, ApplicationDbContext context)

        // IHttpContextAccessor httpAccessor)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;

        }

        public async Task<ApplicationUser> GetUserByIdAsync(int userId)
        {
            return await _userManager.FindByIdAsync(userId.ToString());
        }

        public async Task<ApplicationUser> GetUserByUserNameAsync(string userName)
        {
            return await _userManager.FindByNameAsync(userName);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email)
        {
            return await _userManager.FindByEmailAsync(email)
;
        }

        public async Task<IList<string>> GetUserRolesAsync(ApplicationUser user)
        {
            return await _userManager.GetRolesAsync(user.ToString());
        }

        public async Task<IEnumerable<ApplicationUser>> GetUsers()
        {
            return await _userManager.Users.ToListAsync();
        }

        public UserViewModel GetAllUsersWithClaims()
        {

            //  var clm = await _userManager.Users.ToListAsync();
            var users = _userManager.Users.ToList();
            var model = new UserViewModel
            {
                Users = users.Select(u => new UserModel
                {
                    Id = u.Id.ToString(),
                    Email = u.Email,
                    Claims = _userManager.GetClaimsAsync(u.ToString()).Result.Select(c => new ClaimDto { Type = c.Type }).ToList(),
                }).ToList()
            };
            return model;
        }

        public UserViewModel AllUsers()
        {
            var results = _context.Users.ToList();

            //List<User> mappedUser = _mapper.Map<List<User>>(results);

            var usersModel = new UserViewModel
            {

                Users = results.Select(x => new UserModel
                {
                    Email = x.Email,
                    Id = x.Id.ToString()
                }).ToList()

            };
            return usersModel;
        }

        //public async Task<IEnumerable<ApplicationUser>> GetRoles()
        //{
        //    var result = _roleManager.Roles;
        //    return await Task.FromResult(result.ToList().Wait;
        //}

        public async Task<bool> CreateUserAsync(ApplicationUser user, string password)
        {
            var result = await _userManager.CreateAsync(user, password);
            if (!result.Succeeded)
                return (false);

            if (!result.Succeeded)
            {
               // await DeleteUserAsync(user);
                return false;
            }

            return (true);
        }



        //public async Task<(bool Succeeded, string[] Error)> UpdateUserAsync(ApplicationUser user)
        //{
        //    return await UpdateUserAsync(user, null);
        //}
    }
}