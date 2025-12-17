using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursePracticalApp.Models
{
    public class AppUser : IdentityUser
    {

        [MaxLength(50)]
        public string? FirstName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? LastName { get; set; }

        [Column(TypeName = "date")]
        public DateTime? HireDate { get; set; }

        public bool IsActive { get; set;  } = true;
    }
}
