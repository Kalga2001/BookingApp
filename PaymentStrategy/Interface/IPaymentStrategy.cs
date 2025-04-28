using BookingApp.Models;

public interface IPaymentStrategy
{
    void ProcessPayment(int paymentID, PaymentRequest paymentRequest);
}
