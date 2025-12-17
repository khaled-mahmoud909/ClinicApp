namespace CoursePracticalApp.ViewModels
{
    public class AppointmentVM
    {
        public int PatientId { get; set; }

        public string PatientName { get; set; } = string.Empty;

        public string DateTime { get; set; } = string.Empty;
        
        public string Time { get; set; } = string.Empty;

        public string Date { get; set; } = string.Empty;

        public string DoctorName { get; set; } = string.Empty;

        public int Duration { get; set; }

        public string PatientPhone { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

    }
}
