using BookingApp.Entity;
using BookingApp.Enums;

public class Payment
{
    public int PaymentID { get; set; }

    public PaymentType Type { get; set; }

    public int UserID { get; set; }
    public User User { get; set; }
    public PaymentCardInfo? PaymentCardInfo { get; set; }
    public ICollection<Booking> Bookings { get; set; }
}
