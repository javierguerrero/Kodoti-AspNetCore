using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CommonLayer.Extensions;
using DtoLayer;
using FrontEnd.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace FrontEnd.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            return View(
                await _userService.Get(User.GetUserId())
                );
        }

        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateDto model)
        {
            model.Id = User.GetUserId();
            return View(
                await _userService.Update(model)
            );
        }

    }
}