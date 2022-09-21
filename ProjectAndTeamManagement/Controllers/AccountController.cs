using Domain.IdentityAuth;
using Domain.IdentityAuth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ProjectAndTeamManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        // GET
        public IActionResult Logout()
        {
            return View();
        }

        // GET
        public IActionResult Login()
        {
            return View();
        }

        // GET
        public IActionResult Register()
        {
            return View();
        }

        // POST
        public async Task<IActionResult> LoginAccount(Login model)
        {
            if (ModelState.IsValid)
            {
                var identityResult = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (identityResult.Succeeded)
                {
                    
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Email or password is incorrect!");
                }
            }
            return RedirectToAction("Login");
        }

        // POST
        public async Task<IActionResult> RegisterAccount(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    RoleId = model.RoleId, 
                    TeamId = 1
                };

                var role = await _roleManager.FindByIdAsync(model.RoleId.ToString());

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, role.ToString());
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

            return Redirect("Register");
        }

        // POST
        public async Task<IActionResult> LogoutAccount()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        // POST
        public IActionResult DontLogout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
