using CoursePracticalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.ViewModels
{
    public class PatientCreateVM
    {

        [MaxLength(20), Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [MaxLength(20), Display(Name = "Last Name")]
        public string LastName { get; set; } = string.Empty;

        [Display(Name = "Date Of Birth")]
        public DateOnly DateOfBirth { get; set; }

        [AllowedValues(["Male", "Female"], ErrorMessage = "Gender must be either Male or Female")]
        public string Gender { get; set; } = string.Empty;

        [MaxLength(10), Display(Name = "National ID / Passport"), RegularExpression("[12]\\d{9}", ErrorMessage = "The input should consists of 10 digits and start with 1 or 2")]
        public string NationalId { get; set; } = string.Empty;

        [MaxLength(3), Display(Name = "Blood Group")]
        [AllowedValues(["A+", "A-", "B+", "B-", "AB+", "AB-", "O+", "O-"], ErrorMessage = "Invalid blood group")]
        public string BloodGroup { get; set; } = string.Empty;

        [MaxLength(150), EmailAddress]
        public string Email {  get; set; } = string.Empty;

        [MaxLength(10), MinLength(10), Display(Name = "Phone Number")]
        public string PhoneNumber {  get; set; } = string.Empty;

        [MaxLength(100), Display(Name = "Contact Name")]
        public string EmgContactName { get; set; } = string.Empty;

        [MaxLength(10), MinLength(10), Display(Name = "Contact Phone")]
        public string EmgContactPhone { get; set; } = string.Empty;

        [Required]
        public bool HasInsurance { get; set; } = false;

        [MaxLength(100), Display(Name = "Insurance Provider")]
        public string? InsuranceProvider { get; set; } = string.Empty;

        [MaxLength(20), Display(Name = "Insurance Number")]
        [RegularExpression("\\w{5,20}", ErrorMessage = "Insurance number must be between 5 and 20 alphanumeric characters")]
        public string? InsuranceNumber { get; set; } = string.Empty;

        [Display(Name = "Valid From")]
        [DataType(DataType.Date)]
        public DateOnly? ValidFrom { get; set; }

        [Display(Name = "Valid Unitl")]
        [DataType(DataType.Date)]
        public DateOnly? ValidTo { get; set; }


        [Required]
        [AllowedValues([true], ErrorMessage = "Patient must consent")]
        public bool HasConsentData { get; set; }

        [Required]
        [AllowedValues([true], ErrorMessage = "Patient must consent")]
        public bool HasConsentTreatment { get; set; }

        public Patient Topatient(int id)
        {
            return new Patient
                {
                FullName = $"{FirstName} {LastName}",
                NationalId = NationalId,
                Email = Email,
                PhoneNumber = PhoneNumber,
                DateOfBirth = DateOfBirth,
                Gender = Gender,
                BloodGroup = BloodGroup,
                EmgContactName = EmgContactName,
                EmgContactPhone = EmgContactPhone,
                HasInsurance = HasInsurance,
                InsuranceProvider = InsuranceProvider,
                InsuranceNumber = InsuranceNumber,
                ValidFrom = ValidFrom,
                ValidTo = ValidTo,
                HasConsentData = HasConsentData,
                HasConsentTreatment = HasConsentTreatment,
                ReceptionistId = id,
            };
        }
    }
}
