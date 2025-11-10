using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Etui.Models;
using Etui.Models.ViewModels;

namespace Etui.Controllers
{
        public class AccountController : Controller
        {
                private UserManager<IdentityUser> _userManager;
                private SignInManager<IdentityUser> _signInManager;

                public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
                {
                        _userManager = userManager;
                        _signInManager = signInManager;
                }

                public IActionResult Create() => View();

                [HttpPost]
                public async Task<IActionResult> Create(User user)
                {
                        if (ModelState.IsValid)
                        {
                                IdentityUser newUser = new IdentityUser { UserName = user.UserName, Email = user.Email };
                                IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

                                if (result.Succeeded)
                                {
                                        return Redirect("/admin/products");
                                }

                                foreach (IdentityError error in result.Errors)
                                {
                                        ModelState.AddModelError("", error.Description);
                                }

                        }

                        return View(user);
                }

                public IActionResult Login(string returnUrl) => View(new LoginViewModel { ReturnUrl = returnUrl });

                [HttpPost]
                public async Task<IActionResult> Login(LoginViewModel loginVM)
                {
                        if (ModelState.IsValid)
                        {
                                Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(loginVM.UserName, loginVM.Password, false, false);

                                if (result.Succeeded)
                                {
                                        return Redirect(loginVM.ReturnUrl ?? "/");
                                }

                                ModelState.AddModelError("", "Niepopranwy login lub hasło");
                        }

                        return View(loginVM);
                }

                public async Task<RedirectResult> Logout(string returnUrl = "/")
                {
                        await _signInManager.SignOutAsync();

                        return Redirect(returnUrl);
                }

        }
}
