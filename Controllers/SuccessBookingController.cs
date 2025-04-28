using Microsoft.AspNetCore.Mvc;

namespace BookingApp.Controllers
{
    public class SuccessBookingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
