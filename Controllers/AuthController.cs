using AsitenciaUNC_attemp_2.Models;
using AsitenciaUNC_attemp_2.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AsitenciaUNC_attemp_2.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
	{
		private readonly SignInManager<Usuario> _signInManager;
		private readonly UserManager<Usuario> _userManager;

		public AuthController(SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
		{
			_signInManager = signInManager;
			_userManager = userManager;
		}

		public IActionResult InicioSesion()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> InicioSesion(LoginVM model)
		{
			if (ModelState.IsValid)
			{
				var result = await _signInManager.PasswordSignInAsync(model.Email!, model.Contraseña!, model.RememberMe, false);

				if (result.Succeeded)
				{
					return RedirectToAction("Index", "EventosUser");
				}

				ModelState.AddModelError("", "Invalid login attempt.");
				return View(model);
			}
			return View(model);
		}

		public IActionResult Registro()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Registro(RegisterVM model)
		{
			if (ModelState.IsValid)
			{
				Usuario user = new()
				{
					Nombre = model.Nombre,
					UserName = model.Email,
					Email = model.Email,
				};

				var result = await _userManager.CreateAsync(user, model.Contrasena!);
				if (result.Succeeded)
				{
					await _signInManager.SignInAsync(user, false);

					return RedirectToAction("Index", "EventosUser");
				}
				foreach (var error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
			}

			return View(model);
		}

		public async Task<IActionResult> CerrarSesion()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction("Index", "Home");
		}
	}
}