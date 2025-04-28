using BookingApp.DataContext;
using BookingApp.Enums;
using BookingApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using BookingApp.Helpers;

namespace BookingApp.Controllers
{
    public class PaymentController : Controller
    {
        private readonly LoggerSingleton _logger; 

        public PaymentController()
        {
            _logger = LoggerSingleton.Instance; 
        }

        public IActionResult Index()
        {
            _logger.Log("Accessed Payment Index page.");
            return View();
        }

        [HttpPost]
        public IActionResult ProcessPayment([FromBody] PaymentRequest paymentRequest)
        {
            var cardNumberValidator = new CardNumberValidator();
            var cardHolderNameValidator = new CardHolderNameValidator();
            var expirationDateValidator = new ExpirationDateValidator();
            var cvvValidator = new CVVValidator();

            cardNumberValidator.SetNext(cardHolderNameValidator);
            cardHolderNameValidator.SetNext(expirationDateValidator);
            expirationDateValidator.SetNext(cvvValidator);

            try
            {
                if (!cardNumberValidator.Validate(paymentRequest))
                {
                    _logger.Log("Payment validation failed.");
                    return BadRequest("Invalid payment details.");
                }
            }
            catch (ValidationException ex)
            {
                _logger.Log($"Payment validation exception: {ex.Message}");
                return BadRequest(ex.Message);
            }

            using (var _bookingDbContext = new BookingAppDbContext())
            {
                int lastPaymentID = _bookingDbContext.Payment.OrderByDescending(p => p.PaymentID).FirstOrDefault()?.PaymentID ?? 1;
                PaymentType paymentType = _bookingDbContext.Payment.FirstOrDefault(x => x.PaymentID == lastPaymentID).Type;
                IPaymentStrategy paymentStrategy = GetPaymentStrategy(paymentType);

                paymentStrategy.ProcessPayment(lastPaymentID, paymentRequest);

                _logger.Log($"Processed payment ID: {lastPaymentID}, PaymentType: {paymentType}");
            }

            return Ok("Payment processed successfully");
        }

        private IPaymentStrategy GetPaymentStrategy(PaymentType type)
        {
            switch (type)
            {
                case PaymentType.CreditCard:
                    return new CreditCardPaymentStrategy();
                case PaymentType.Cash:
                    return new CashPaymentStrategy();
                default:
                    _logger.Log("Invalid payment type encountered.");
                    throw new ArgumentException("Invalid payment type");
            }
        }
    }
}
