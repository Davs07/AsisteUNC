using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsitenciaUNC_attemp_2.Data;
using AsitenciaUNC_attemp_2.Models;
namespace AsitenciaUNC_attemp_2.Controllers.Admin
{
	[Route("Admin/Registro")]
	public class RegistroController : Controller
	{
		private readonly ApplicationDbContext _context;

		public RegistroController(ApplicationDbContext context)
		{
			_context = context;
		}

		// Acción para mostrar la lista de registros 
		[Route("")]
		public async Task<IActionResult> Index()
		{
			var registros = await _context.Registros.ToListAsync();
			return View(registros);
		}

		// Acción para mostrar los detalles de un registro específico 
		[Route("Detalles/{id?}")]
		public async Task<IActionResult> Detalles(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registro = await _context.Registros
				.FirstOrDefaultAsync(m => m.Id == id);
			if (registro == null)
			{
				return NotFound();
			}

			return View(registro);
		}

		// Acción para crear un nuevo registro 
		[HttpGet]
		[Route("Crear")]
		public IActionResult Crear()
		{
			return View();
		}

		[HttpPost]
		[Route("Crear")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Crear([Bind("Id,IdUsuario,IdEvento,FechaRegistro,Estado,CodigoQrAsistencia")] Registro registro)
		{
			if (ModelState.IsValid)
			{
				_context.Add(registro);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(registro);
		}

		// Acción para editar un registro 
		[HttpPost]
		[Route("Editar/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Editar(int id, [Bind("Id,IdUsuario,IdEvento,FechaRegistro,Estado,CodigoQrAsistencia")] Registro registro)
		{
			if (id != registro.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(registro);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!RegistroExists(registro.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(registro);
		}

		// Acción para eliminar un registro 
		[HttpGet]
		[Route("Eliminar/{id?}")]
		public async Task<IActionResult> Eliminar(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var registro = await _context.Registros
				.FirstOrDefaultAsync(m => m.Id == id);
			if (registro == null)
			{
				return NotFound();
			}

			return View(registro);
		}

		[HttpPost, ActionName("Eliminar")]
		[Route("Eliminar/{id}")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EliminarConfirmado(int id)
		{
			var registro = await _context.Registros.FindAsync(id);
			if (registro != null)
			{
				_context.Registros.Remove(registro);
				await _context.SaveChangesAsync();
			}
			return RedirectToAction(nameof(Index));
		}

		// Método auxiliar para verificar si un registro existe 
		private bool RegistroExists(int id)
		{
			return _context.Registros.Any(e => e.Id == id);
		}
	}
}