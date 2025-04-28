using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class BlogController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
