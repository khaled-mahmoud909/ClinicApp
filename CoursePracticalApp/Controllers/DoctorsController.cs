using CoursePracticalApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoursePracticalApp.Controllers
{
    public class DoctorsController : Controller
    {
        public IActionResult Index()
        {
            var doctors = Constants.Doctors;
            return View(doctors);
        }
    }
}
