using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace SimpleManagementSystem.Controllers.Auth
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email, string password)
        {
            if (ModelState.IsValid)
            {
                SignInResult result = await _signInManager.PasswordSignInAsync(email, password, false, false);

                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index), "Home");
                }
            }

            return View();
        }
    }
}