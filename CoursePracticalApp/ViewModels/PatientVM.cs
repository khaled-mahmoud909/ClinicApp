using CoursePracticalApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.Models
{
    public class PatientVM
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string NationalId { get; set; } = string.Empty;

        public string Email {  get; set; } = string.Empty;

        public string PhoneNumber {  get; set; } = string.Empty;

        public DateOnly DateOfBirth { get; set; }

    }
}
