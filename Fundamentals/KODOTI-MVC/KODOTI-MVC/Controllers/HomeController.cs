using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using KODOTI_MVC.Models;
using KODOTI_MVC.ViewModels;

namespace KODOTI_MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult AboutUs ()
        {
            ViewData["Bar"] = "Foo";
            ViewBag.Bar2 = "Foo2";

            return View(new AboutUsViewModel
            {
                Title = "Acerca de nosotros",
                Description = "todo lo que tienes que saber",
                Collaborators = new List<string>
                {
                    "Jose",
                    "Miguel",
                    "Tomas"
                }
            });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
