using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Booking
    {
        [Key]
        public int UniqueId { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime ExpectedCheckIn { get; set; }
        public DateTime ExpectedCheckOut { get; set; }
        [Required]
        public string RoomId { get; set; } = string.Empty;
        [ForeignKey("RoomId")]
        public Room? Room { get; set; }

        //public DateTime ExpectedCheckIn { get; set; }
        //public DateTime ExpectedCheckOut { get; set; }
        public List<Guest>? Guests { get; set; }


        public DateTime ActualCheckIn { get; set; }
        public DateTime ActualCheckOut { get; set; }
        public int BookingAmt { get; set; }
        public int BalanceAmt { get; set; }

        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        [NotMapped]
        public int NumberOfGuests { get { return Guests == null ? 0 : Guests.Count; } } 
    }
}
