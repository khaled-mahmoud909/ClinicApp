using CoursePracticalApp.Models;
using CoursePracticalApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoursePracticalApp.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        public int PatientId { get; set; }

        public int DoctorId { get; set; }

        public DateOnly AppointmentDate { get; set; }

        public TimeOnly AppointmentTime { get; set; }

        public int Duration { get; set; } 

        public string Status { get; set; } = string.Empty;

        public string Reason {  get; set; } = string.Empty;

        public string? Description { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }

        public Patient Patient { get; set; } = null!;

        public Doctor Doctor { get; set; } = null!;

        public List<Note> Notes { get; set; } = new List<Note>();


        public AppointmentVM ToAppointmentVM()
        {
            return new AppointmentVM
            {
                PatientId = PatientId,
                PatientName = Patient.FullName,
                DoctorName = Doctor.AppUser.FirstName + " " + Doctor.AppUser.LastName,
                DateTime = AppointmentDate.ToString() + " - " + AppointmentTime.ToString(),
                Duration = Duration,
                PatientPhone = Patient.PhoneNumber,
                Status = Status,
                Type = Reason
            };
        }
        public AppointmentVM ToAppointmentVM(Doctor doctor)
        {
            return new AppointmentVM
            {
                PatientId = PatientId,
                PatientName = Patient.FullName,
                DoctorName = doctor.AppUser.FirstName + " " + doctor.AppUser.LastName,
                Date = AppointmentDate.ToString("ddd MMM dd, yyyy"),
                Time = AppointmentTime.ToString("hh:mm tt"),
                Duration = Duration,
                PatientPhone = Patient.PhoneNumber,
                Status = Status,
                Type = Reason
            };
        }
    }
}
