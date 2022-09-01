using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SiotohBlog.Interface;
using SiotohBlog.Models;
using SiotohBlog.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static SiotohBlog.Controllers.Common.Enum;

namespace SiotohBlog.Controllers
{
    public class AdminController : BaseController
    {
        private UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private RoleManager<IdentityRole> _roleManager;
        private readonly IAccountManager _accountManager;
        private readonly IBlogRepo _blog;
        private readonly ApplicationDbContext _context;

        public AdminController ()
        {

        }
        public AdminController(IBlogRepo blog, ApplicationDbContext context,
            UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager,
            IAccountManager accountManager, IMapper mapper)
        {
            _blog = blog;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _accountManager = accountManager;
            _mapper = mapper;
        }

        public ViewResult Index()
        {
            return View();
        }
        public ViewResult RoleList()
        {
            var result = _roleManager.Roles;
            List<Models.RoleModel> RoleList = _mapper.Map<List<Models.RoleModel>>(result);
            return View(RoleList);
        }

        public ActionResult CreateRole() => View();


        [HttpPost]
        // [Authorize(Policy = Claims.Admin)]
        public async Task<ActionResult> CreateRole([Required] string name)
        {
            if (ModelState.IsValid)
            {
                //  IdentityResult result = await roleManager.CreateAsync(name);
                var role = new IdentityRole
                {
                    Name = name
                };
                // var mappedUser = _mapper.Map<Role>(name);
                IdentityResult result = await _roleManager.CreateAsync(role);

                //  RoleModel roles = _mapper.Map<RoleModel>(result);

                if (result.Succeeded)
                {
                    TempData["message"] = string.Format("{0} has been updated.");

                    dynamic transRef = TempData["Message"];

                    Alert("success", transRef, NotificationType.success);
                    return RedirectToAction(nameof(RoleList));
                }

                else
                {
                    // Errors(result);
                }
                // TempData["Message"] = result;
                //return View(roles);
            }
            return View(name);
        }
        [HttpPost, ActionName("EditAUser")]
        public async Task<ActionResult> EditUser(EditUserModel model)
        {
            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user != null)
            {
                using (var sha256 = SHA256.Create())
                {
                    // Send a sample text to hash.  
                    var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(model.Password));
                    // Get the hashed string.  
                    var hashedPassword = BitConverter.ToString(hashedBytes).Replace("-", "").ToUpper();

                    user.Email = model.NewEmail;
                    user.PasswordHash = hashedPassword;
                    // _context.Users.Add(user);
                }

                _context.SaveChanges();
                return View(user);

            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<ActionResult> UpdateUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id)
;
            if (user != null)
                return View(user);
            else
                return RedirectToAction(nameof(Index));
        }

        public ActionResult UserList()
        {
            var usersModel = new List<UserViewModel>();
            var results = _context.Users.ToList();
            foreach(var user in results)
            {
                var u = new UserViewModel();
                u.Email = user.Email;
                usersModel.Add(u);

            }
            return View(usersModel);
        }
       

    }
}