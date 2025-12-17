using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.Models
{
    public class Doctor
    {

        public int Id { get; set; }

        public string AppUserId { get; set; } = null!;

        public int SpecialityId { get; set; }

        public AppUser AppUser { get; set; } = null!;

        public Speciality Speciality { get; set; } = null!;

        public List<Appointment> Appointments { get; set; } = new List<Appointment>();

    }
}
