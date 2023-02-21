using Attendance.Core.Entities;
using Attendance.Web.Models.Account;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Attendance.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        
        private readonly IMapper mapper;

        public UserController(UserManager<AppUser> userManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.mapper = mapper;
        }

        public UserController()
        {
        }

        public IActionResult Index()
        {
            var model = new UserListViewModel();
            var users = userManager.Users.ToList().Select(x =>
            {
                var role = userManager.GetRolesAsync(x).Result.FirstOrDefault();
                var usermodel = mapper.Map<UserViewModel>(x);
                usermodel.Role = role;
                return usermodel;
            });
            model.UserViewModels = users.ToList();
            model.Register = new RegisterViewModel();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddUser(UserListViewModel model)
        {
            if(model.Register != null){
            var user = new AppUser()
            {
                Email = model.Register.Email,
                PasswordHash = model.Register.Password,
                UserName = model.Register.Email,
                FirstName = model.Register.FirstName,
                LastName = model.Register.LastName,
                PhoneNumber = model.Register.PhoneNumber
            };
                if (user.Email != null && user.FirstName != null && user.LastName != null && model.Register.Password != null)
                {
                      var result = await userManager.CreateAsync(user, model.Register.Password);
                    if (result.Succeeded)
                    {
                        await userManager.AddToRoleAsync(user, UserRole.Member.ToString());
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
