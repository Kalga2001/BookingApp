using BookingApp.Models;

public abstract class BaseValidator : IValidator
{
    protected IValidator _nextValidator;

    public void SetNext(IValidator nextValidator)
    {
        _nextValidator = nextValidator;
    }

    public virtual bool Validate(PaymentRequest paymentRequest)
    {
        if (_nextValidator != null)
        {
            return _nextValidator.Validate(paymentRequest);
        }

        return true; 
    }
}