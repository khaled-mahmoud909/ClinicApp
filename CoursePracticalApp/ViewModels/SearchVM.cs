namespace CoursePracticalApp.ViewModels
{
    public class SearchVM
    {

        public List<AppointmentVM> VMs { get; set; } = new List<AppointmentVM>();

        public List<PatientVM> PatientVMs { get; set; } = new List<PatientVM>();

        public SearchFilterVM Filter { get; set; } = new();

    }
}
