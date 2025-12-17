using CoursePracticalApp.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoursePracticalApp.Controllers
{
    public class AuthController : Controller
    {

        private SignInManager<IdentityUser> _signInManager;

        public AuthController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginVM vm)
        {

            if(!ModelState.IsValid)
            {
                return View(vm);
            }

            var result = await _signInManager.PasswordSignInAsync(vm.Username, vm.Password, true, true);
            if (!result.Succeeded) {
                ModelState.AddModelError("Password", "Invalid username or password");
                return View(vm);
            }

            var role = await _signInManager.UserManager.GetRolesAsync(await _signInManager.UserManager.FindByNameAsync(vm.Username));

            return Redirect(vm.UserRole + "/Dashboard");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
