using CoursePracticalApp.ViewModels;
using System.Collections.Specialized;

namespace CoursePracticalApp.Helpers
{
    public static class SidebarMenu
    {

        public static readonly SidebarOption[] AdminMenu = new[]
        {
            new SidebarOption { Name = "Dashboard", Icon = "bi bi-layout-wtf me-2", action="Dashboard" },
            new SidebarOption { Name = "User Management", Icon = "bi bi-people me-2", action="UserManagement" },
            new SidebarOption { Name = "Doctors", Icon = "bi bi-person-badge me-2", action="Doctors" },
            new SidebarOption { Name = "Receptionists", Icon = "bi bi-person-workspace me-2", action="Receptionists" },
            new SidebarOption { Name = "Appointments", Icon = "bi bi-calendar-check me-2", action="Appointments" },
            new SidebarOption { Name = "Patients", Icon = "bi bi-person-heart me-2", action="Patients" },
            new SidebarOption { Name = "Reports & Analytics", Icon = "bi bi-graph-up me-2", action="Reports" },
            new SidebarOption { Name = "System Settings", Icon = "bi bi-gear me-2", action="Settings" }
        };

        public static readonly SidebarOption[] DoctorMenu = new[]
        {
            new SidebarOption { Name = "Dashboard", Icon = "bi bi-layout-wtf me-2", action="Dashboard" },
            new SidebarOption { Name = "My Appointments", Icon = "bi bi-calendar-check me-2", action="MyAppointments" },
            new SidebarOption { Name = "Patient Records", Icon = "bi bi-folder2-open me-2", action="PatientRecords" },
        };

        public static readonly SidebarOption[] ReceptionistMenu = new[]
        {
            new SidebarOption { Name = "Dashboard", Icon = "bi bi-layout-wtf me-2", action="Dashboard" },
            new SidebarOption { Name = "Book Appointment", Icon = "bi bi-calendar-plus me-2", action="BookAppointment" },
            new SidebarOption { Name = "Register Patient", Icon = "bi bi-person-plus me-2", action="RegisterPatient" },
            new SidebarOption { Name = "Search", Icon = "bi bi-search me-2", action="Search" }
        };

    }
}
