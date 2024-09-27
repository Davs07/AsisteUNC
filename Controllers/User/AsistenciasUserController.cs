using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsitenciaUNC_attemp_2.Data;

namespace AsitenciaUNC_attemp_2.Controllers.User
{
    [Authorize]
    public class AsistenciasUserController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AsistenciasUserController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> MisAsistencias()
		{
			// Obtener el nombre de usuario del usuario autenticado
			var correoUsuario = User.Identity.Name;

			// Consultar las asistencias del usuario autenticado
			var asistencias = await _context.Asistencias
				.Include(a => a.Registro)
				.ThenInclude(r => r.Usuario)
				.Where(a => a.Registro.Usuario.CorreoElectronico == correoUsuario)
				.ToListAsync();

			return View(asistencias);
		}

	}

}
