using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using AsitenciaUNC_attemp_2.Data;
using AsitenciaUNC_attemp_2.Models;


namespace AsitenciaUNC_attemp_2.Controllers.Admin
{
    [Route("Admin/Asistencia")]
    public class AsistenciaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AsistenciaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Admin/Asistencia
        [HttpGet("")]
		[Route("")]
		[Route("Index")]
		public async Task<IActionResult> Index()
        {
            var asistencias = await _context.Asistencias
                .Include(a => a.Registro)
                .ToListAsync();

            return View(asistencias); // Pasa la lista de asistencias directamente
        }

        // GET: Admin/Asistencia/Details/5
        [HttpGet("Detalles/{id:int}")]
		[Route("Detalles")]

		public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias
                .Include(a => a.Registro)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // GET: Admin/Asistencia/Crear
        [HttpGet]
        [Route("Crear")]
        public IActionResult Crear()
        {
            ViewData["RegistroId"] = new SelectList(_context.Registros, "Id", "Id");
            return View();
        }

        // POST: Admin/Asistencia/Crear
        [HttpPost("Crear")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Crear(Asistencia asistencia)
        {
            if (ModelState.IsValid)
            {
                _context.Asistencias.Add(asistencia);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RegistroId"] = new SelectList(_context.Registros, "Id", "Id", asistencia.RegistroId);
            return View(asistencia);
        }

        // GET: Admin/Asistencia/Editar/5
        [HttpGet("Editar/{id:int}")]
        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }
            return View(asistencia);
        }

        // POST: Admin/Asistencia/Editar/5
        [HttpPost("Editar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(int id, Asistencia asistencia)
        {
            if (id != asistencia.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Asistencias.Update(asistencia);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AsistenciaExists(asistencia.Id))
                    {
                        return NotFound();
                    }
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(asistencia);
        }

        // GET: Admin/Asistencia/Eliminar/5
        [HttpGet("Eliminar/{id:int}")]
        public async Task<IActionResult> Eliminar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var asistencia = await _context.Asistencias
                .Include(a => a.Registro)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (asistencia == null)
            {
                return NotFound();
            }

            return View(asistencia);
        }

        // POST: Admin/Asistencia/Eliminar/5
        [HttpPost("Eliminar/{id:int}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EliminarPost(int? id)
        {
            var asistencia = await _context.Asistencias.FindAsync(id);
            if (asistencia == null)
            {
                return NotFound();
            }

            _context.Asistencias.Remove(asistencia);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AsistenciaExists(int id)
        {
            return _context.Asistencias.Any(e => e.Id == id);
        }
    }
}
