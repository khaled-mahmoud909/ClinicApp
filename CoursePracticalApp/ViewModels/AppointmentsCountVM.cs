namespace CoursePracticalApp.ViewModels
{
    public class AppointmentsCountVM
    {

        public int AppointmentsCount { get; set; } = 0;

        public int CompletedAppointmentsCount { get; set; } = 0;

        public int UpcomingAppointmentsCount { get; set; } = 0;

        public int CanceledAppointmentsCount { get; set; } = 0;
    }
}
