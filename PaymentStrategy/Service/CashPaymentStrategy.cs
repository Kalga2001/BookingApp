using BookingApp.DataContext;
using BookingApp.Models;

public class CashPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(int paymentID, PaymentRequest paymentRequest)
    {
        using (var _bookingDbContext = new BookingAppDbContext())
        {
            var currentPayment = _bookingDbContext.Payment.FirstOrDefault(x => x.PaymentID == paymentID);
            currentPayment.PaymentCardInfo = null;
            _bookingDbContext.Payment.Update(currentPayment);
            _bookingDbContext.SaveChanges();
        }
    }
}