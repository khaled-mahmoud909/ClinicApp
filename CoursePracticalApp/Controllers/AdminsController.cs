using CoursePracticalApp.Helpers;
using CoursePracticalApp.Models;
using CoursePracticalApp.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Threading.Tasks;

namespace CoursePracticalApp.Controllers
{
    [Authorize(Roles = "APP_ADMIN")]
    public class AdminsController : Controller
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly ClinicContext _context;

        public AdminsController(UserManager<IdentityUser> userManager, ClinicContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult UserManagement()
        {
            var specialities = _context.Specialities.Select(s => s.Name).ToList();
            ViewBag.Specialities = new SelectList(specialities);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(AddUserVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View("UserManagement", vm);
            }

            var existingUser = await _userManager.FindByEmailAsync(vm.Email);

            if (existingUser != null)
            {
                ModelState.AddModelError(string.Empty, "User with this email already exists.");
                return View("UserManagement", vm);
            }

            var newUser = new AppUser
            {
                FirstName = vm.FirstName,
                LastName = vm.LastName,
                Email = vm.Email,
                EmailConfirmed = true,
                UserName = vm.Email.Split("@")[0],
                PhoneNumber = vm.PhoneNumber,
                HireDate = vm.CreatedAt,
                IsActive = vm.IsActive
            };

            var result = await _userManager.CreateAsync(newUser, vm.Password);


            if(!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("UserManagement", vm);
            }

            result = await _userManager.AddToRoleAsync(newUser, vm.UserRole);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
                return View("UserManagement", vm);
            }

            if (vm.UserRole == AppRoles.DOCTOR.ToString())
            {

                var speciality = _context.Specialities.First(s => s.Name == vm.Speciality);

                var doctor = new Doctor
                {
                    Speciality = speciality,
                    AppUserId = newUser.Id
                };
                _context.Doctors.Add(doctor);
                await _context.SaveChangesAsync();
            }
            else if (vm.UserRole == AppRoles.RECEPTIONEST.ToString())
            {
                var receptionist = new Receptionist
                {
                    ShiftType = "Morning",
                    AppUserId = newUser.Id
                };
                _context.Receptionists.Add(receptionist);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction("");
        }

    }
}
