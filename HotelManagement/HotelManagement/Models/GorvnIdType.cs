using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Models
{
    public class GorvnIdType
    {
        [Key]
        public int Id { get; set; } 
        public string IdType{ get; set; } 
    }
}
