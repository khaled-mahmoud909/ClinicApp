using CoursePracticalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.ViewModels
{
    public class PatientVM
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string NationalId { get; set; } = string.Empty;

        public string Email {  get; set; } = string.Empty;

        public string PhoneNumber {  get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

        public bool IsActive { get; set; }

        public int TotalAppointments { get; set; }

        public string LastAppintment { get; set; } = null!;

        public int Age 
        { 
            get
            {
                var today = DateTime.Today;
                var age = today.Year - DateOfBirth.Year;
                if (DateOfBirth > new DateOnly(today.Year, today.Month, today.Day))
                {
                    age--;
                }
                return age;
            }
        }

    }
}
