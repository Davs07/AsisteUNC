using AsitenciaUNC_attemp_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AsitenciaUNC_attemp_2.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var eventos = GetEventos() ?? new List<Evento>();
            return View(eventos);
        }

        private List<Evento> GetEventos()
        {
            // Ejemplo de lista de eventos de prueba
            return new List<Evento>
                            {
                                new Evento { Id = 1, Titulo = "Taller de Programaci�n", Descripcion = "Aprende las bases de la programaci�n.", FechaInicio = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), Ubicacion = "Auditorio EPIS" },
                                new Evento { Id = 2, Titulo = "Conferencia de IA", Descripcion = "La inteligencia artificial en la actualidad.", FechaInicio = DateOnly.FromDateTime(DateTime.Now.AddDays(5)), Ubicacion = "Aula Magna UNC" },
                                new Evento { Id = 3, Titulo = "Hackathon 2024", Descripcion = "Competencia de desarrollo tecnol�gico.", FechaInicio = DateOnly.FromDateTime(DateTime.Now.AddDays(10)), Ubicacion = "Laboratorio 101" }
                            };
        }

        public IActionResult Eventos()
        {
            // Ejemplo de lista de eventos de prueba
            var eventos = new List<Evento>
                            {
                                new Evento { Id = 1, Titulo = "Taller de Programaci�n", Descripcion = "Aprende las bases de la programaci�n.", FechaInicio = DateOnly.FromDateTime(DateTime.Now.AddDays(2)), Ubicacion = "Auditorio EPIS" },
                                new Evento { Id = 2, Titulo = "Conferencia de IA", Descripcion = "La inteligencia artificial en la actualidad.", FechaInicio = DateOnly.FromDateTime(DateTime.Now.AddDays(5)), Ubicacion = "Aula Magna UNC" },
                                new Evento { Id = 3, Titulo = "Hackathon 2024", Descripcion = "Competencia de desarrollo tecnol�gico.", FechaInicio = DateOnly.FromDateTime(DateTime.Now.AddDays(10)), Ubicacion = "Laboratorio 101" }
                            };

            return View(eventos); // Pasamos la lista de eventos a la vista
        }

        public IActionResult Talleres()
        {
            return View();
        }

        public IActionResult Blog()
        {
            var publicaciones = new List<Publicacion>
                            {
                                new Publicacion { Id = 1, Titulo = "C�mo prepararse para un taller de programaci�n", Autor = "Juan P�rez", FechaPublicacion = DateTime.Now.AddDays(-3), Resumen = "Consejos para aprovechar al m�ximo tu participaci�n en talleres de programaci�n." },
                                new Publicacion { Id = 2, Titulo = "Beneficios de asistir a eventos acad�micos", Autor = "Ana L�pez", FechaPublicacion = DateTime.Now.AddDays(-5), Resumen = "Explora los beneficios de asistir a conferencias y talleres organizados por la UNC." },
                                new Publicacion { Id = 3, Titulo = "Qu� esperar del Hackathon 2024", Autor = "Carlos Mej�a", FechaPublicacion = DateTime.Now.AddDays(-7), Resumen = "Descubre los retos y premios que te esperan en el pr�ximo Hackathon de la UNC." }
                            };

            ViewBag.Publicaciones = publicaciones;

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
