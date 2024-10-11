using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace HotelManagement.Models
{
    public class Guest
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public int? GovnId { get; set; }
        [ForeignKey("GovnId")]
        public GorvnIdType? GorvnIdType { get; set; }
        public string GovnIdNumber { get; set; } = string.Empty;

        [NotMapped]
        public IFormFile? GovIdFile { get; set; }
        public string GovIdFilePath { get; set; } = string.Empty;


        [NotMapped]
        public string? FullName { get { return FirstName + LastName; } }
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;




    }
}
