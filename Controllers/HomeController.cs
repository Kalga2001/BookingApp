using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

    }
}
