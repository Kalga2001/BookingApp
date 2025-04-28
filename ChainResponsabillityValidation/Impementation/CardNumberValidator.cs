using BookingApp.Models;
using System.ComponentModel.DataAnnotations;

public class CardNumberValidator : BaseValidator
{
    public override bool Validate(PaymentRequest paymentRequest)
    {
        var cardNumber = paymentRequest.CardNumber;

        if (cardNumber.Length < 13 || cardNumber.Length > 19)
        {
            throw new ValidationException("Card number must be between 13 and 19 digits.");
        }

        return base.Validate(paymentRequest);
    }
}