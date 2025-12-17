using CoursePracticalApp.Models;
using CoursePracticalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.Models
{
    public class Patient
    {
        public int Id { get; set; }

        [MaxLength(40)]
        public string FullName { get; set; } = string.Empty;

        [MaxLength(10)]
        public string NationalId { get; set; } = string.Empty;

        [MaxLength(150)]
        public string Email {  get; set; } = string.Empty;

        [MaxLength(10), MinLength(10)]
        public string PhoneNumber {  get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        [MaxLength(10)]
        [Required]
        public string Gender { get; set; } = string.Empty;

        [MaxLength(3)]
        [Required]
        public string BloodGroup { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true;

        [MaxLength(100)]
        [Required]
        public string EmgContactName { get; set; } = string.Empty;

        [MaxLength(10), MinLength(10)]
        [Required]
        public string EmgContactPhone { get; set; } = string.Empty;

        [Required]
        public bool HasInsurance { get; set; } = false;

        [MaxLength(100)]
        public string? InsuranceProvider { get; set; }

        [MaxLength(20)]
        public string? InsuranceNumber { get; set; }

        public DateOnly? ValidFrom { get; set; }

        public DateOnly? ValidTo { get; set; }

        [Required]
        public bool HasConsentData { get; set; }

        [Required]
        public bool HasConsentTreatment { get; set; }

        public DateTime CreatedAt { get; set; }

        public int ReceptionistId { get; set; }

        public Receptionist Receptionist { get; set; } = null!;

        public List<Appointment> Appointments { get; set; } = new();

        public PatientVM ToPatientVM(int totalAppointments, DateOnly? lastAppointment)
        {
            return new PatientVM
            {
                Id = Id,
                FullName = FullName,
                NationalId = NationalId,
                Email = Email,
                PhoneNumber = PhoneNumber,
                DateOfBirth = DateOfBirth,
                IsActive = IsActive,
                TotalAppointments = totalAppointments,
                LastAppintment = lastAppointment.HasValue ? lastAppointment.ToString() : "N/A",
            };

        }

        public PatientUpdateVM ToPatientUpdateVM()
        {
            return new PatientUpdateVM
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
