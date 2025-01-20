
using System.ComponentModel.DataAnnotations;

namespace HotelManagement.ViewModels
{
    public class Login
    {
        [Required]
        [Display(Name = "Login Name")]
        public string LoginName { get; set; }

        [Required]
        public string Password { get; set; }
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    
    }

}
