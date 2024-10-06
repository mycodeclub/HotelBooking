using HotelManagement.Models;

namespace HotelManagement.ViewModels
{
    public class RoomsAvilibilityVM
    {
        public DateTime BookingDate { get; set; }
        public List<Room>? Rooms { get; set; }
    }
}
