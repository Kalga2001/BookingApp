using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
