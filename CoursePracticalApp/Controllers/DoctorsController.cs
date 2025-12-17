using CoursePracticalApp.Helpers;
using CoursePracticalApp.Models;
using CoursePracticalApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CoursePracticalApp.Controllers
{
    [Authorize(Roles = "DOCTOR")]
    public class DoctorsController : Controller
    {

        private readonly ClinicContext _db;

        public DoctorsController(ClinicContext db)
        {
            _db = db;
        }

        public IActionResult Dashboard()
        {

            var AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            var today = DateTime.Today;
            var startOfMonth = new DateOnly(today.Year, today.Month, 1);
            var endOfMonth = startOfMonth.AddMonths(1);

            var doctor = _db.Doctors.Include(d => d.Appointments
                                    .Where(a => a.AppointmentDate >= startOfMonth &&
                                     a.AppointmentDate <= endOfMonth))
                                    .Single(d => d.AppUserId == AppUserId);

            var appointments = doctor.Appointments;

            AppointmentsCountVM vm = new AppointmentsCountVM
            {
                AppointmentsCount = appointments.Count,
                CompletedAppointmentsCount = appointments.Count(a => a.Status == AppointmentStatus.Completed.ToString()),
                UpcomingAppointmentsCount = appointments.Count(a => a.Status == AppointmentStatus.Upcoming.ToString()),
                CanceledAppointmentsCount = appointments.Count(a => a.Status == AppointmentStatus.Canceled.ToString())
            };

            return View(new DoctorAppointmentsVM { doctor=doctor, appointmentsCountVm= vm });
        }

        public IActionResult MyAppointments()
        {
            var AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var doctor = _db.Doctors
                .Where(d => d.AppUserId == AppUserId)
                .Include(d => d.AppUser)
                .First();
            var appointments = _db.Appointments
                .Include(a => a.Patient)
                .Where(a => a.DoctorId == doctor.Id)
                .Select(a => a.ToAppointmentVM(doctor))
                .ToList();
            return View(appointments);
        }
    }
}
