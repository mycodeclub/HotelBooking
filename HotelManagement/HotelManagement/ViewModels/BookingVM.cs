using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using HotelManagement.Models;

namespace HotelManagement.ViewModels
{
    public class BookingVM
    {
        public int Id { get; set; }
        public List<RoomsAvilibilityVM>? AvailableRooms { get; set; }
        public List<Room>? RoomsList { get; set; }
        public List<Hall>? HallsList { get; set; }
        public List<Room>? BookedRooms  { get; set; }
        public List<Hall>? BookedHalls { get; set; }
        public int AdvanceAmt { get; set; }
        public int RemainingAmt { get; set; }
         public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
    }
}
