using HotelManagement.Models;

namespace HotelManagement.ViewModels
{
    public class RoomsAvilibilityVM
    {
        public DateTime BookingDate { get; set; }
        public List<Room>? AvailableRooms { get; set; }
        public List<Hall>? AvailableHalls { get; set; }
    }
}
