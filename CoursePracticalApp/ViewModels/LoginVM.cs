using CoursePracticalApp.Helpers;
using System.ComponentModel.DataAnnotations;

namespace CoursePracticalApp.ViewModels
{
    public class LoginVM
    {

        [Display(Name = "User Role")]
        public string UserRole { get; set; } = AppRoles.DOCTOR.ToString();

        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; } = string.Empty;


        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
