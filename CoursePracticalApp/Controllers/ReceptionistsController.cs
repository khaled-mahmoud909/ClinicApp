using CoursePracticalApp.Models;
using CoursePracticalApp.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CoursePracticalApp.Controllers
{
    [Authorize(Roles = "RECEPTIONEST")]
    public class ReceptionistsController : Controller
    {

        ClinicContext _context;

        public ReceptionistsController(ClinicContext context)
        {
            _context = context;
        }


        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult BookAppointment()
        {
            var specialties = _context.Specialities.Select(s => s.Name).ToList();
            ViewBag.Specialties = new SelectList(specialties);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult BookAppointment(AppointmentCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                var specialties = _context.Specialities.Select(s => s.Name).ToList();
                ViewBag.Specialties = new SelectList(specialties);
                return View(vm);
            }

            var haveAppointmentBooked = _context.Appointments.Any(a =>
                a.PatientId == vm.PatientId &&
                a.DoctorId == vm.DoctorId &&
                a.AppointmentDate >= DateOnly.FromDateTime(DateTime.Now) &&
                a.Status == "Scheduled"
            );

            if (haveAppointmentBooked) {
                ModelState.AddModelError(string.Empty, "This patient already has a scheduled appointment with the selected doctor.");
                var specialties = _context.Specialities.Select(s => s.Name).ToList();
                ViewBag.Specialties = new SelectList(specialties);
                return View(vm);
            }

            Appointment appointment = new Appointment
            {
                PatientId = vm.PatientId,
                DoctorId = vm.DoctorId,
                AppointmentDate = vm.AppointmentDate,
                AppointmentTime = vm.AppointmentTime,
                Duration = vm.Duration,
                Status = "Scheduled",
                Reason = vm.AppointmentType,
                CreatedAt = DateTime.Now,
                Description = vm.AppointmentDescription
            };
            _context.Appointments.Add(appointment);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Appointment booked successfully!";
            return RedirectToAction("BookAppointment");
        }

        public IActionResult SearchPatients(string searchTerm)
        {
            var patients = _context.Patients
                .Where(p => p.FullName.Contains(searchTerm) || p.PhoneNumber.Contains(searchTerm))
                .Select(p => new {p.Id, p.FullName, p.PhoneNumber})
                .OrderBy(p => p.FullName)
                .ToList();

            return Json(patients);
        }

        public IActionResult SearchAppointments(string searchTerm)
        {
            var appointments = _context.Appointments
                .Where(a => a.Patient.FullName.Contains(searchTerm) || a.Doctor.AppUser.FirstName.Contains(searchTerm) || a.Doctor.AppUser.LastName.Contains(searchTerm))
                .Select(a => new 
                {
                    a.Id,
                    PatientName = a.Patient.FullName,
                    DoctorName = "Dr. " + a.Doctor.AppUser.FirstName + " " + a.Doctor.AppUser.LastName,
                    a.AppointmentDate,
                    a.AppointmentTime,
                    a.Status
                })
                .OrderBy(a => a.AppointmentDate)
                .ThenBy(a => a.AppointmentTime)
                .ToList();
            return Json(appointments);
        }

        public IActionResult GetDoctorsBySpecialty(string specialty)
        {
            var doctors = _context.Doctors
                .Where(d => d.Speciality.Name == specialty)
                .Select(d => new { d.Id, FullName = "Dr. " + d.AppUser.FirstName + " " + d.AppUser.LastName })
                .OrderBy(d => d.FullName)
                .ToList();
            return Json(doctors);
        }

        public IActionResult GetAvailableSlots(int doctorId, DateOnly appointmentDate)
        {
            var bookedSlots = _context.Appointments
                .Where(a => a.DoctorId == doctorId
                && a.AppointmentDate == appointmentDate
                && a.Status != "Canceled")
                .Select(a => new
                {
                    start = a.AppointmentTime,
                    end = a.AppointmentTime.AddMinutes(a.Duration)
                })
                .ToList();

            var allSlots = new List<object>();

            for (var time = new TimeOnly(9, 0); time < new TimeOnly(17, 0); time = time.AddMinutes(30))
            {
                var slotEnd = time.AddMinutes(30);
                bool isBooked = bookedSlots.Any(bs => 
                    (time < bs.end && slotEnd > bs.start)
                );
                allSlots.Add(new
                {
                    Time = time.ToString("hh:mm tt").ToUpper(),
                    RawTime = time.ToString(),
                    isBooked
                });
            }
            return Json(allSlots);
        }

        public IActionResult RegisterPatient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult RegisterPatient(PatientCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            if (!vm.HasConsentData || !vm.HasConsentTreatment)
            {
                ModelState.AddModelError(string.Empty, "Patient must provide consent for data processing and treatment.");
                return View(vm);
            }

            if (vm.HasInsurance)
            {
                if (string.IsNullOrWhiteSpace(vm.InsuranceProvider) ||
                    string.IsNullOrWhiteSpace(vm.InsuranceNumber) ||
                    vm.ValidFrom == default ||
                    vm.ValidTo == default)
                {
                    ModelState.AddModelError(string.Empty, "All insurance details must be provided if the patient has insurance.");
                    return View(vm);
                }
                if(vm.ValidFrom > DateOnly.FromDateTime(DateTime.Now))
                {
                    ModelState.AddModelError(string.Empty, "Insurance 'Valid From' date cannot be in the future.");
                    return View(vm);
                }

                if (vm.ValidTo <= vm.ValidFrom)
                {
                    ModelState.AddModelError(string.Empty, "Insurance 'Valid To' date must be later than 'Valid From' date.");
                    return View(vm);
                }
                if (vm.ValidTo < DateOnly.FromDateTime(DateTime.Now))
                {
                    ModelState.AddModelError(string.Empty, "Insurance is expired. Please provide valid insurance details.");
                    return View(vm);
                }
            }

            if (vm.DateOfBirth >= DateOnly.FromDateTime(DateTime.Now))
            {
                ModelState.AddModelError(string.Empty, "Date of Birth must be a date in the past.");
                return View(vm);
            }

            string AppUserId = User.FindFirst(ClaimTypes.NameIdentifier)!.Value;

            int ReceptionistId = _context.Receptionists
                .Where(r => r.AppUserId == AppUserId)
                .Select(r => r.Id)
                .FirstOrDefault();

            Patient patient = vm.Topatient(ReceptionistId);

            if (patient != null)
            {
                _context.Patients.Add(patient);
                _context.SaveChanges();

                // Logic to save patient to database would go here
                TempData["SuccessMessage"] = $"Patient {patient.FullName} registered successfully! Patient ID: #{patient.Id}";
                return RedirectToAction("RegisterPatient");
            }
            else
            {
                TempData["ErrorMessage"] = "Failed to create patient record.";
                return View(vm);
            }
        }

        public IActionResult Search(SearchFilterVM vm)
        {
            if(vm.IsAppointmentSearch)
            {    
                var initQuery = _context.Appointments
                                           .Where(a => (string.IsNullOrEmpty(vm.AppointmentFilter.PatientName) || a.Patient.FullName.Contains(vm.AppointmentFilter.PatientName)))
                                           .Where(a => string.IsNullOrEmpty(vm.AppointmentFilter.DoctorName) || (a.Doctor.AppUser.FirstName + " " + a.Doctor.AppUser.LastName).Contains(vm.AppointmentFilter.DoctorName))
                                           .Where(a => vm.AppointmentFilter.AppointmentDate == default || a.AppointmentDate == vm.AppointmentFilter.AppointmentDate);

                var totalRecords = initQuery.Count();

                var appointments = initQuery
                                    .OrderByDescending(a => a.AppointmentDate)
                                    .ThenByDescending(a => a.AppointmentTime)
                                    //.Skip((vm.page - 1) * vm.pageSize)
                                    //.Take(vm.pageSize)
                                    .Include(a => a.Patient)
                                    .Include(a => a.Doctor)
                                    .ThenInclude(d => d.AppUser)
                                    .Select(a => a.ToAppointmentVM())
                                    .ToList();

                SearchFilterVM filterVM = new SearchFilterVM
                {
                    IsAppointmentSearch = true,
                    AppointmentFilter = vm.AppointmentFilter
                };

                return View(new SearchVM { VMs = appointments,  Filter = filterVM});
            }
            else
            {
                var initQuery = _context.Patients
                                        .Where(p => string.IsNullOrEmpty(vm.PatientFilter.FullName) || p.FullName.Contains(vm.PatientFilter.FullName))
                                        .Where(p => string.IsNullOrEmpty(vm.PatientFilter.PhoneNumber) || p.PhoneNumber.Contains(vm.PatientFilter.PhoneNumber))
                                        .Where(p => string.IsNullOrEmpty(vm.PatientFilter.NationalId) || p.NationalId.Contains(vm.PatientFilter.NationalId));

                var totalRecords = initQuery.Count();

                var patients = initQuery
                                .OrderBy(p => p.FullName)
                                //.Skip((vm.PatientFilter.page - 1) * vm.PatientFilter.pageSize)
                                //.Take(vm.PatientFilter.pageSize)
                                .Include(p => p.Appointments)
                                .Select(p => p.ToPatientVM(p.Appointments.Count(), p.Appointments.OrderByDescending(a => a.AppointmentDate).Select(a => a.AppointmentDate).First()))
                                .ToList();

                SearchFilterVM filterVM = new SearchFilterVM
                {
                    IsAppointmentSearch = false,
                    PatientFilter = vm.PatientFilter
                };
                return View(new SearchVM { PatientVMs = patients, Filter = filterVM });
            }
        }

    }
}
