using BookingApp.Models;

public interface IValidator
{
    bool Validate(PaymentRequest paymentRequest);
    void SetNext(IValidator nextValidator);
}