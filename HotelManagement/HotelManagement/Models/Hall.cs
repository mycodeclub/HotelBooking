using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class Hall
    {
        [Key]
        public string HallNumber { get; set; }
        public int Rent { get; set; }

    }
}
