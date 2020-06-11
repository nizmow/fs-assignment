using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Application.Models;
using Application.Services;

namespace Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly INumberToEnglishService numberToEnglishService;

        public HomeController(INumberToEnglishService numberToEnglishService)
        {
            this.numberToEnglishService = numberToEnglishService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<ViewResult> Index([Required][Range(-999999999999, 999999999999)] decimal? number)
        {
            if (ModelState.IsValid)
            {
                ViewData["Result"] = await this.numberToEnglishService.CalculateEnglishAndLog(number.Value);
                ViewData["RequestedNumber"] = number;
            }

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}