using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SimpleManagementSystem.ViewModels.Login;

namespace SimpleManagementSystem.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;

        public LoginController(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }
        
        public IActionResult Index(string ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginViewModel loginView, string? ReturnUrl)
        {
            ViewData["ReturnUrl"] = ReturnUrl;

            if (!ModelState.IsValid) return View();
            var result = await _signInManager.PasswordSignInAsync(loginView.Email, loginView.Password, true, false);

            if (result.Succeeded)
            {
                if (ReturnUrl != null) return Redirect(ReturnUrl);
                    
                return RedirectToAction(nameof(Index), "Home");
            }
                
            ModelState.AddModelError("Email", "Credentials incorrect");

            return View();
        }
    }
}