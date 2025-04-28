using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BookingApp.Helpers;
using BookingApp.Interfaces;

namespace BookingApp.Controllers
{
    public class BookingController : Controller
    {
        private readonly IBookingService _bookingService;
        private readonly LoggerSingleton _logger; 

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
            _logger = LoggerSingleton.Instance; 
        }

        public IActionResult Index()
        {
            _logger.Log("Accessed Booking Index page.");
            return View();
        }

        public IActionResult Create()
        {
            _logger.Log("Accessed Booking Create page (GET).");
            return View();
        }

        [HttpPost]
        public IActionResult Create([FromBody] BookingRequest request)
        {
            try
            {
                if (DateTime.Today > request.From)
                {
                    var errorMessage = "The 'From' date cannot be in the past.";
                    _logger.Log($"Booking creation failed: {errorMessage}");
                    return Json(new CustomResponse
                    {
                        Code = 400,
                        Message = errorMessage
                    });
                }

                if (request.From > request.To)
                {
                    return Json(new CustomResponse
                    {
                        Code = 400,
                        Message = "The 'From' date cannot be later than the 'To' date."
                    });
                }

                var response = _bookingService.CreateBooking(request);
                _logger.Log($"Booking created for user: {request.UserID} on date: {request.From}");
                return Json(new CustomResponse
                {
                    Code = response.Code,
                    Message = response.Message
                });
            }
            catch (Exception ex)
            {
                _logger.Log($"Exception during booking creation: {ex.Message}");
                throw;
            }
        }
    }
}
