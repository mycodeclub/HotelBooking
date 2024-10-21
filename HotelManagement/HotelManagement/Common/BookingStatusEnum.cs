namespace HotelManagement.Common
{
    public enum BookingStatusEnum
    {
        Inquiry,    // Guest inquired about availability, no payment yet
        Reserved,   // Room held but not fully paid yet (maybe partial payment)
        Confirmed,  // Booking confirmed with payment
        CheckedIn,  // Guest checked in
        CheckedOut, // Guest checked out
        Cancelled   // Booking cancelled
    }
}
