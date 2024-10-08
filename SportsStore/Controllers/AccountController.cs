using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Filters;
using SportsStore.Models.ViewModels;

namespace SportsStore.Controllers
{
    [Authorize]
    [Route("Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public ViewResult Login(Uri returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                return this.View(new LoginViewModel
                {
                    ReturnUrl = returnUrl,
                });
            }
            
            return this.View();
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        [ValidateModel]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (loginViewModel is null || loginViewModel.Name is null || loginViewModel.Password is null)
            {
                return this.View(loginViewModel);
            }

            IdentityUser? user = await this.userManager.FindByNameAsync(loginViewModel.Name);

            if (user != null)
            {
                await this.signInManager.SignOutAsync();

                if ((await this.signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false)).Succeeded)
                {
                    return this.RedirectToAction("Products", "Admin");
                }
            }

            this.ModelState.AddModelError(string.Empty, "Invalid name or password.");

            return this.View(loginViewModel);
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout(Uri returnUrl)
        {
            if (this.ModelState.IsValid)
            {
                await this.signInManager.SignOutAsync();
                return this.RedirectToAction("Login", returnUrl);
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
