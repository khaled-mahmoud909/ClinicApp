using CoursePracticalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.ViewModels
{
    public class PatientUpdateVM
    {

        [MaxLength(150), Display(Name = "Full Name")]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(10), Display(Name = "National Id"), RegularExpression("[12]\\d{9}", ErrorMessage = "The input should consists of 10 digits and start with 1 or 2")]
        public string NationalId { get; set; } = string.Empty;

        [MaxLength(150), EmailAddress]
        public string Email {  get; set; } = string.Empty;

        [MaxLength(10), MinLength(10), Display(Name = "Phone Number")]
        public string PhoneNumber {  get; set; } = string.Empty;

        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }

        public Patient Topatient()
        {
            return new Patient
                {
                FullName = FullName,
                NationalId = NationalId,
                Email = Email,
                PhoneNumber = PhoneNumber,
                DateOfBirth = DateOfBirth,
            };
        }
    }
}
