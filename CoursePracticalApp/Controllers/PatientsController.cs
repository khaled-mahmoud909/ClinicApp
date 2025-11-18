using CoursePracticalApp.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;

namespace CoursePracticalApp.Controllers
{
    public class PatientsController : Controller
    {

        private readonly ClinicContext _db;

        public PatientsController(ClinicContext db)
        {
            _db = db;
        }

        public IActionResult Index(PatientFilterVM vm)
        {
            var patients = _db.Patients
                            .Where(p => vm.Id == null || p.Id == vm.Id)
                            .Where(p => vm.FullName == null || p.FullName.Contains(vm.FullName))
                            .Where(p => vm.PhoneNumber == null || p.PhoneNumber ==  vm.PhoneNumber)
                            .Where(p => vm.NationalId == null || p.NationalId == vm.NationalId)
                            .Select(p => p.ToPatientVM()).ToList();
            return View(new PatientFilterListVM { patientVMs=patients, PatientFilterVM=vm });
        }

        public IActionResult Details(int id)
        {
            var patient = _db.Patients.Single(p => p.Id == id).ToPatientVM();
            return View(patient);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(PatientCreateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            var p = vm.Topatient();
            _db.Patients.Add(p);
            _db.SaveChanges();
            return RedirectToAction("Details", new {p.Id});
        }

        public IActionResult Update(int id)
        {
            var patient = _db.Patients.Single(p => p.Id == id).ToPatientUpdateVM();
            return View(patient);
        }

        [HttpPost]
        public IActionResult Update(int id, PatientUpdateVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var patient = _db.Patients.Single(P => P.Id == id);
            patient.FullName = vm.FullName;
            patient.PhoneNumber = vm.PhoneNumber;
            patient.Email = vm.Email;
            patient.DateOfBirth = vm.DateOfBirth;
            patient.NationalId = vm.NationalId;

            _db.SaveChanges();
            return RedirectToAction("Details", new {id});

        }

        public IActionResult Delete(int id)
        {
            var patient = _db.Patients.Single(p => p.Id == id);
            _db.Patients.Remove(patient);
            _db.SaveChanges();
            return Ok();
        }
    }
}
