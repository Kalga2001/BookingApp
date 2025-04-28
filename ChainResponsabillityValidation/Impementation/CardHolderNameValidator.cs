using BookingApp.Models;
using System.ComponentModel.DataAnnotations;

public class CardHolderNameValidator : BaseValidator
{
    public override bool Validate(PaymentRequest paymentRequest)
    {
        var cardHolderName = paymentRequest.CardHolderName;

        if (cardHolderName.Length > 100)
        {
            throw new ValidationException("Card holder name is too long.");
        }

        return base.Validate(paymentRequest);
    }
}