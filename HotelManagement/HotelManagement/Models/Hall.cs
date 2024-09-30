using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelManagement.Models
{
    public class Hall
    {
        [Key]
        public string HallNumber { get; set; } = string.Empty;
        public int Rent { get; set; }
        [NotMapped]
        public bool? IsAvailable { get; set; }
    }
}
