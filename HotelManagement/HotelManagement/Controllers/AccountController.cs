using HotelManagement.Models;
using HotelManagement.EF;
 
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using HotelManagement.ViewModels;
using BpstEducation.Services;
using Microsoft.EntityFrameworkCore;
using HotelManagement.Services;

namespace HotelManagement.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserServiceBAL _userService;


        public AccountController( AppDbContext context, UserManager<AppUser> userManager,
           SignInManager<AppUser> signInManager, IUserServiceBAL userService )
        {
            _userService = userService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
          

        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task< IActionResult> Login()
        {
            return await ReDirectIfLoggedIn();
        }

        [HttpPost]
        public async Task<IActionResult> Login(Login model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.LoginName, model.Password, model.RememberMe, lockoutOnFailure: false);

                if (result.Succeeded)
                    return await ReDirectIfLoggedIn();
                else { ModelState.AddModelError("", "Invalid Email Id or Password"); }
            }
            return View(model);
        }
        public async Task<IActionResult> ReDirectIfLoggedIn()
        {
            if (_signInManager.IsSignedIn(User))
            {
                var user = await _userManager.GetUserAsync(User);
                var role = await _userManager.GetRolesAsync(user);
                if (role.Contains("Admin")) return RedirectToAction("Index", "Home", new { Area = "Admin" });
                else return View("Login");
            }
            else
                return View("Login");// RedirectToAction("Login", "Account");
        }

        public async Task<IActionResult> CreateMasterUser()
        {
            var errorStr = string.Empty;
            try
            {
                var appUser = new AppUser()
                {
                    UserName = "admin@bpst.com",
                    Email = "admin@bpst.com",
                    Password = "admin@bpst.com",
                    ConfirmPassword = "admin@bpst.com",
                    PhoneNumber = "9999999999",
                };
                var userRoles = await _context.Roles.Select(r => r.Name).ToListAsync();
                var result = await _userService.AddUser(appUser, userRoles);
                foreach (var error in result.Errors)
                {
                    if (error.Code == "DuplicateUserName")
                        return RedirectToAction("AutoLogin");
                    else
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                        errorStr += "Some Error: " + error.Code;
                    }
                }
            }
            catch (Exception ex)
            {
                errorStr = "Some Error: " + ex.Message;
            }
            if (string.IsNullOrWhiteSpace(errorStr))
                return RedirectToAction("AutoLogin");
            return RedirectToAction("Login");
        }
        public async Task<IActionResult> AutoLogin()
        {
            var result = await _signInManager.PasswordSignInAsync("admin@bpst.com", "admin@bpst.com", true, lockoutOnFailure: false);
            if (result.Succeeded)
                return await ReDirectIfLoggedIn();
            else
                return RedirectToAction("CreateMasterUser");
            return RedirectToAction("Index", "Home");
        }
    }
}
