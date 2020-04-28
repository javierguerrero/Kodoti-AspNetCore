using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainLayer.Identity;
using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FrontEnd.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signManager)
        {
            _userManager = userManager;
            _signManager = signManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserLoginViewModel model)
        {
            var result = await _signManager.PasswordSignInAsync(model.Email, model.Password, model.RemeberMe, false);

            if (result.Succeeded)
            {
                return Redirect("~/");
            }
            return View();
        }

        public IActionResult NewUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewUserViewModel model)
        {
            var result = await _userManager.CreateAsync(
                new ApplicationUser { 
                    UserName = model.Email,
                    Email = model.Email 
                }, model.Password);
            return View(result.Succeeded);
        }

        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return Redirect("~/");
        }

    }
}