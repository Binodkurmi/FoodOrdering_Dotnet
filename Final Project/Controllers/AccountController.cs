using Final_Project.Models;
using Final_Project.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project.Controllers
{
	public class AccountController : Controller
	{
		private readonly SignInManager<Customer> signInManager;
		private readonly UserManager<Customer> userManager;

		public AccountController(SignInManager<Customer> signInManager, UserManager<Customer> userManager)
		{
			this.signInManager = signInManager;
			this.userManager = userManager;
		}
		public IActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> LoginAsync(LoginVM model)
		{
			if (ModelState.IsValid)
			{
				var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
				if (result.Succeeded)
				{
					return RedirectToAction("Index", "Food");
				}

				ModelState.AddModelError("", "Invalid login attempt");
				return View(model);
			}
			return View(model);
		}

		public IActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Register(RegisterVM model)
		{
			if (ModelState.IsValid)
			{
				Customer user = new()
				{
					Name = model.Name,
					PhoneNumber = model.PhoneNumber,
					UserName = model.Email,
					Email = model.Email,
				};

				var result = await userManager.CreateAsync(user, model.Password);

				if (result.Succeeded)
				{
					await signInManager.SignInAsync(user, false);
					return RedirectToAction("Login", "Account");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}
			return View(model);
		}

		public async Task<IActionResult> Logout()
		{
			await signInManager.SignOutAsync();
			return RedirectToAction("Login", "Account");
		}
	}
}
