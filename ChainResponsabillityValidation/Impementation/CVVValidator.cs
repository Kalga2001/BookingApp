using BookingApp.Models;
using System.ComponentModel.DataAnnotations;

public class CVVValidator : BaseValidator
{
    public override bool Validate(PaymentRequest paymentRequest)
    {
        var cvv = paymentRequest.CVV;

        if (cvv.Length < 3 || cvv.Length > 4)
        {
            throw new ValidationException("CVV must be 3 or 4 digits.");
        }

        return base.Validate(paymentRequest);
    }
}