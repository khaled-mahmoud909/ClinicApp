using CoursePracticalApp.Models;

namespace CoursePracticalApp.ViewModels
{
    public class DoctorAppointmentsVM
    {

        public Doctor doctor { get; set; } = null!;

        public AppointmentsCountVM appointmentsCountVm { get; set; } = null!;
    }
}
