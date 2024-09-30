using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Room
    {
        [Key]
        public string RoomNumber { get; set; } = string.Empty;
        public int Rent { get; set; }

        [NotMapped]
        public bool?
            IsAvailable { get { return Guests != null; } }
        public List<Guest>? Guests { get; set; }
    }
}
