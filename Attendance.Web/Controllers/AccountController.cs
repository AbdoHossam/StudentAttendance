using Attendance.Core.Entities;
using Attendance.Web.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Attendance.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signinManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signinManager, UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.signinManager = signinManager;
            this.userManager = userManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterAsync(RegisterViewModel Vm, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser()
                {
                    Email = Vm.Email,
                    PasswordHash = Vm.Password,
                    UserName = Vm.Email,
                    FirstName = Vm.FirstName,
                    LastName = Vm.LastName,
                    PhoneNumber = Vm.PhoneNumber,
                };
                var result = await userManager.CreateAsync(user, Vm.Password);
                if (result.Succeeded)
                {
                    _ = await userManager.AddToRoleAsync(user, UserRole.Member.ToString());
                    var userId = JsonConvert.DeserializeObject<string>(string.IsNullOrEmpty(HttpContext.Session.GetString("UserId")) ? "" : HttpContext.Session.GetString("UserId"));
                
                    await signinManager.SignInAsync(user, isPersistent: Vm.RememberMe);//to keep cookie after closing browser?

                    if (string.IsNullOrEmpty(ReturnUrl))
                    {
                        return RedirectToAction("index", "home");
                    }
                    else
                        return LocalRedirect(ReturnUrl);
                }
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                    {
                        ModelState.AddModelError("Email", error.Description);
                    }
                }

            }

            return View(Vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(bool passwordReset = false)
        {
            if (passwordReset)
            {
                ViewBag.Password = "Your password has been updated try to Login now";
            }
            return View(new LoginViewModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel Vm, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(Vm.Email);
                if (user != null)
                {

                    var result = await signinManager.PasswordSignInAsync(user.UserName, Vm.Password, Vm.RememberMe, false);

                    if (result.Succeeded)
                    {
                        //var logged_user = await userManager.FindByNameAsync(user.UserName);
                      
                        //var claims = await userManager.GetClaimsAsync(user);
                        //if (claims.Any(x=>x.Type != "firstName"))
                        //{
                        //    await userManager.AddClaimAsync(user, new Claim("firstName", user.FirstName));
                        //}
                        
                        if (string.IsNullOrEmpty(ReturnUrl))
                        {
                            return RedirectToAction("Index", "Home");
                        }
                        else
                            return LocalRedirect(ReturnUrl);

                    }
                    else
                    {
                        Vm.ErrorMessage = "Password is Wrong";
                    }
                }
                else
                {
                    Vm.ErrorMessage = "Email is wrong";
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(Vm);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            await signinManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

    }
}
