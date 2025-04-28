using BookingApp.Helpers;

namespace BookingApp.Interfaces
{
    public interface IBookingService
    {
        CustomResponse CreateBooking(BookingRequest request);
    }
}
