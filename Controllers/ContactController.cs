using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
