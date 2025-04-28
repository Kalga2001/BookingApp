using BookingApp.DataContext;
using BookingApp.Enums;
using BookingApp.Helpers;
using BookingApp.Interfaces;

namespace BookingApp.Services
{
    public class BookingService : IBookingService
    {
        public CustomResponse CreateBooking(BookingRequest request)
        {
            using (var _bookingDbContext = new BookingAppDbContext())
            {
                var room = _bookingDbContext.Room.Find(request.RoomID);
                var user = _bookingDbContext.User.Find(request.UserID);
                var paymentType = GetPaymentType(request.TypeOfPayment);

                if (room == null || user == null)
                {
                    return new CustomResponse { Code = 404, Message = "Room or User not found" };
                }

                var booking = new BookingBuilder()
                    .SetPeriod(request.From, request.To)
                    .SetUser(request.UserID)
                    .SetRoom(request.RoomID)
                    .SetChildrenCount(request.ChildrenCount)
                    .SetPrice(request.Price)
                    .SetPayment(paymentType)
                    .Build();

                var payment = new Payment
                {
                    Type = paymentType,
                    UserID = request.UserID,
                    PaymentCardInfo = null,
                    Bookings = new[] { booking }
                };

                _bookingDbContext.Payment.Add(payment);
                _bookingDbContext.Booking.Add(booking);
                _bookingDbContext.SaveChanges();

                return new CustomResponse { Code = 201, Message = "Booking created" };
            }
        }

        public PaymentType GetPaymentType(int paymentTypeID)
        {
            switch (paymentTypeID)
            {
                case 0:
                    return PaymentType.CreditCard;
                case 1:
                    return PaymentType.Cash;
            }

            return PaymentType.Cash;
        }
    }
}
