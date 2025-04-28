namespace BookingApp.Entity
{
    public class Room
    {
        public int RoomID { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public bool IsAvailable { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }

}
