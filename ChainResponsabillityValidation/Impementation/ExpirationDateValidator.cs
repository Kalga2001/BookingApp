using BookingApp.Models;
using System.ComponentModel.DataAnnotations;

public class ExpirationDateValidator : BaseValidator
{
    public override bool Validate(PaymentRequest paymentRequest)
    {
        var expirationDate = paymentRequest.ExpirationDate;

        var regex = new System.Text.RegularExpressions.Regex(@"^(0[1-9]|1[0-2])\/?([0-9]{2})$");
        if (!regex.IsMatch(expirationDate))
        {
            throw new ValidationException("Expiration date must be in MM/YY format.");
        }

        return base.Validate(paymentRequest);
    }
}