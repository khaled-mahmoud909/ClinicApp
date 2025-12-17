using System.ComponentModel.DataAnnotations;

namespace CoursePracticalApp.ViewModels
{
    public class AppointmentCreateVM
    {

        [Required]
        public int PatientId { get; set; }

        [Required]
        public string Specialty { get; set; } = null!;
        
        [Required]
        public int DoctorId { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateOnly AppointmentDate {  get; set; }

        [Required]
        [DataType(DataType.Time)]
        public TimeOnly AppointmentTime { get; set; }

        [Required]
        [AllowedValues([30, 45, 60])]
        public int Duration { get; set; }

        [Required]
        [AllowedValues(["Consultation", "Followup", "Checkup", "Emergency"], ErrorMessage="Choose a valid Appointment type")]
        public string AppointmentType { get; set; } = null!;

        [MaxLength(300)]
        public string? AppointmentDescription { get; set; } = string.Empty;

    }


}
