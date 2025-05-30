﻿namespace BookingApp.Entity
{
    public class User
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<Role> Roles { get; set; }
        public bool IsActive { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}
