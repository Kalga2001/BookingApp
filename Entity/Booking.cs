using BookingApp.Enums;

namespace BookingApp.Entity
{
    public class Booking
    {
        public int BookingID { get; set; }

        public DateTime From { get; set; }
        public DateTime To { get; set; }

        public int ChildrenCount { get; set; }
        public decimal Price { get; set; }

        public int RoomID { get; set; }
        public Room Room { get; set; }

        public int? PaymentID { get; set; }
        public Payment? Payment { get; set; }

        public PaymentType TypeOfPayment { get; set; }
        public int UserID { get; set; }  
        public User User { get; set; }
    }

}
