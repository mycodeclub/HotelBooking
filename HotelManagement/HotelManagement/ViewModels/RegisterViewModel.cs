using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace HotelManagement.ViewModels
{ 
    public class RegisterViewModel
    {
        [Display(Name = "Mobile No.")]
        [Required(ErrorMessage = "Phone Number Required!")]
        [StringLength(10, MinimumLength = 10)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]
        public string PhoneNumber { get; set; }


        [Required]
        [EmailAddress]
        [Display(Name = "Email Id")]
        public string Email { get; set; }

        public string Address { get; set; }

    

        [Required]
        //[StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        public List<string> Roles { get; set; }

    }
}
