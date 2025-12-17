namespace CoursePracticalApp.ViewModels
{
    public class SearchFilterVM
    {
        public bool IsAppointmentSearch { get; set; }

        public AppointmentFilterVM? AppointmentFilter { get; set; } = new();

        public PatientFilterVM? PatientFilter { get; set; } = new();
    }
}
