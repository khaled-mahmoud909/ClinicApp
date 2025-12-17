namespace CoursePracticalApp.ViewModels
{
    public class AppointmentFilterVM
    {

        public int id { get; set; }

        public string PatientName { get; set; } = null!;

        public string DoctorName { get; set; } = null!;

        public DateOnly AppointmentDate { get; set; }


        public int page { get; set; }
        public int pageSize { get; set; } = 5;
        public int totalRecords { get; set; }

        public int totalPages => (int)Math.Ceiling((double)totalRecords / pageSize);
    }
}
