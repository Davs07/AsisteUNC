using AsitenciaUNC_attemp_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AsitenciaUNC_attemp_2.Data;

namespace AsitenciaUNC_attemp_2.Controllers.User
{
    [Authorize]
    public class PerfilUserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;

        public PerfilUserController(ApplicationDbContext context, SignInManager<Usuario> signInManager, UserManager<Usuario> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var usuarioActual = await _userManager.GetUserAsync(User); // Obtener el usuario autenticado
            if (usuarioActual == null)
            {
                return RedirectToAction("InicioSesion", "Auth"); // Redirigir a inicio de sesión si no está autenticado
            }
            return View(usuarioActual);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Usuario model)
        {
            var usuario = await _userManager.FindByIdAsync(model.Id); // Usar UserManager para buscar el usuario
            if (usuario != null)
            {
                usuario.Nombre = model.Nombre;
                usuario.Apellido = model.Apellido;
                usuario.CorreoElectronico = model.CorreoElectronico;

                var result = await _userManager.UpdateAsync(usuario); // Usar UserManager para actualizar

                if (result.Succeeded)
                {
                    // Si el usuario actualiza su correo, es posible que debas actualizar la sesión:
                    await _signInManager.RefreshSignInAsync(usuario);
                    return RedirectToAction("Index");
                }
                else
                {
                    // Manejar errores si la actualización falla
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model); // Si hay errores, retornar a la vista para mostrar mensajes de error
        }
    }
}