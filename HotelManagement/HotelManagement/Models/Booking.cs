using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }

        [NotMapped]
        public int GuestsNum { get; set; }


        public List<string>? RoomIds { get; set; }
        public List<Room>? Rooms { get; set; }

        public List<int>? HallIds { get; set; }
        public List<Hall>? Halls { get; set; }


        public int AdvanceAmt { get; set; }
        public int RemainingAmt { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

    }
}
