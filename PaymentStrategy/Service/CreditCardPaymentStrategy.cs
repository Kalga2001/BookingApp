using BookingApp.DataContext;
using BookingApp.Models;

public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(int paymentID, PaymentRequest paymentRequest)
    {
        using (var _bookingDbContext = new BookingAppDbContext())
        {
            var currentPayment = _bookingDbContext.Payment.FirstOrDefault(x => x.PaymentID == paymentID);
            if (currentPayment != null)
            {
                currentPayment.PaymentCardInfo = new PaymentCardInfo
                {
                    CardHolderName = paymentRequest.CardHolderName,
                    CardNumber = paymentRequest.CardNumber,
                    CVV = paymentRequest.CVV,
                    ExpirationDate = paymentRequest.ExpirationDate,
                    PaymentID = paymentID
                };
            }

            _bookingDbContext.Payment.Update(currentPayment);
            _bookingDbContext.SaveChanges();
        }
    }
}