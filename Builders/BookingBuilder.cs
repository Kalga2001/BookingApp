using BookingApp.Entity;
using BookingApp.Enums;

public class BookingBuilder
{
    private readonly Booking _booking = new Booking();
    public BookingBuilder SetPeriod(DateTime from, DateTime to)
    {
        _booking.From = from;
        _booking.To = to;
        return this;
    }

    public BookingBuilder SetUser(int userId)
    {
        _booking.UserID = userId;
        return this;
    }

    public BookingBuilder SetRoom(int roomId)
    {
        _booking.RoomID = roomId;
        return this;
    }

    public BookingBuilder SetChildrenCount(int count)
    {
        _booking.ChildrenCount = count;
        return this;
    }

    public BookingBuilder SetPrice(decimal price)
    {
        _booking.Price = price;
        return this;
    }

    public BookingBuilder SetPayment(PaymentType type)
    {
        _booking.TypeOfPayment = type;
        return this;
    }

    public Booking Build()
    {
        return _booking;
    }
}
