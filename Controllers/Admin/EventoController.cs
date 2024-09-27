using Microsoft.AspNetCore.Mvc;
using AsitenciaUNC_attemp_2.Data;
using AsitenciaUNC_attemp_2.Models;

namespace AsitenciaUNC_attemp_2.Controllers.Admin
{
    [Route("Admin/Evento")]
    public class EventoController : Controller
    {
        private readonly ApplicationDbContext _db;

        public EventoController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: Admin/Evento
        [HttpGet]
        [Route("")]
        [Route("Index")]
        public IActionResult Index(string searchString)
        {
            var eventos = from e in _db.Eventos
                          select e;

            if (!string.IsNullOrEmpty(searchString))
            {
                eventos = eventos.Where(s => s.Titulo.Contains(searchString));
            }

            return View(eventos);
        }

        // GET: Admin/Evento/Crear
        [HttpGet]
        [Route("Crear")]
        public IActionResult Crear()
        {
            return View();
        }

        // POST: Admin/Evento/Crear
        [HttpPost]
        [Route("Crear")]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Evento evento)
        {
            if (ModelState.IsValid)
            {
                _db.Eventos.Add(evento);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Admin/Evento/Editar/5
        [HttpGet]
        [Route("Editar/{id:int}")]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Eventos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Admin/Evento/Editar
        [HttpPost]
        [Route("Editar")]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Evento evento)
        {
            if (ModelState.IsValid)
            {
                var eventoExistente = _db.Eventos.Find(evento.Id);
                if (eventoExistente == null)
                {
                    return NotFound();
                }

                eventoExistente.Titulo = evento.Titulo;
                eventoExistente.Descripcion = evento.Descripcion;
                eventoExistente.FechaInicio = evento.FechaInicio;
                eventoExistente.HoraInicio = evento.HoraInicio;
                eventoExistente.FechaFinal = evento.FechaFinal;
                eventoExistente.HoraFinal = evento.HoraFinal;
                eventoExistente.Ubicacion = evento.Ubicacion;
                eventoExistente.Capacidad = evento.Capacidad;
                eventoExistente.Tipo = evento.Tipo;
                eventoExistente.Modalidad = evento.Modalidad;
                eventoExistente.CreadoEn = evento.CreadoEn;
                eventoExistente.ActualizadoEn = DateTime.Now;
                eventoExistente.IdOrganizador = evento.IdOrganizador;
                eventoExistente.QRInvitacion = evento.QRInvitacion;

                _db.Eventos.Update(eventoExistente);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(evento);
        }

        // GET: Admin/Evento/Eliminar/5
        [HttpGet]
        [Route("Eliminar/{id:int}")]
        public IActionResult Eliminar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = _db.Eventos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        // POST: Admin/Evento/Eliminar
        [HttpPost, ActionName("Eliminar")]
        [Route("Eliminar/{id:int}")]
        [ValidateAntiForgeryToken]
        public IActionResult EliminarPost(int? id)
        {
            var obj = _db.Eventos.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Eventos.Remove(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Admin/Evento/VerDetalles/5
        [HttpGet]
        [Route("VerDetalles/{id:int}")]
        public IActionResult VerDetalles(int id)
        {
            var evento = _db.Eventos.Find(id);
            if (evento == null)
            {
                return NotFound();
            }
            return View(evento);
        }
    }
}
