using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AsitenciaUNC_attemp_2.Data;
using AsitenciaUNC_attemp_2.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using QRCoder;
using static System.Net.WebRequestMethods;
using AsitenciaUNC_attemp_2.ViewModels;

[Authorize]
public class EventosUserController : Controller
{
    private readonly ApplicationDbContext _db;
    private readonly UserManager<Usuario> _userManager;
    private readonly IConfiguration _configuration;


    public EventosUserController(ApplicationDbContext db, UserManager<Usuario> userManager)
    {
        _db = db;
        _userManager = userManager;
    }

    string url1 = "https://d9e5-190-116-36-68.ngrok-free.app/registrarasistencia/";


	// Paginación y búsqueda
	[BindProperty(SupportsGet = true)]
	public int? Pagina { get; set; }
	public int TotalRegistros { get; set; }
	[BindProperty(SupportsGet = true)]
	public string TerminoBusqueda { get; set; }

    // Index: Muestra la lista de eventos
    public async Task<IActionResult> Index(string buscar, int pagina = 1)
    {
        int pageSize = 10; // Número de elementos por página
        var query = _db.Eventos.Include(e => e.Organizador).AsQueryable();

        if (!string.IsNullOrEmpty(buscar))
        {
            query = query.Where(e => e.Titulo.Contains(buscar));
        }

        var totalRegistros = await query.CountAsync();
        var eventos = await query
            .Skip((pagina - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        var viewModel = new IndexVM
        {
            Eventos = eventos,
            PaginaActual = pagina,
            TotalPaginas = (int)Math.Ceiling(totalRegistros / (double)pageSize),
            Buscar = buscar
        };

        return View(viewModel);
    }

    // Index: Muestra la lista de eventos
    public async Task<IActionResult> Eventos()
    {
        var usuarioActual = await _userManager.GetUserAsync(User);
        if (usuarioActual == null)
        {
            return RedirectToAction("InicioSesion", "Auth");
        }
        var eventos = await _db.Eventos.Where(e => e.IdOrganizador == usuarioActual.Id).ToListAsync();
        return View(eventos);
    }

    // Detalles: Muestra los detalles de un evento específico
    public async Task<IActionResult> Detalles(int id)
    {
        var evento = await _db.Eventos
            .Include(e => e.Organizador) // Incluye la relación con el organizador
            .FirstOrDefaultAsync(e => e.Id == id);

        var registrados = await _db.Registros
            .Include(r => r.Usuario) // Incluye la relación con el usuario
            .Where(r => r.IdEvento == id)
            .ToListAsync();

        var asistentes = await _db.Registros
            .Include(r => r.Usuario) // Incluye la relación con el usuario
            .Where(r => r.IdEvento == id && r.Estado == EstadoRegistro.Asistio)
            .ToListAsync();

        if (evento == null)
        {
            return NotFound();
        }
        var viewModel = new EventDetailsVM
        {
            Evento = evento,
            Registrados = registrados,
            Asistentes = asistentes
        };

        return View(viewModel);
    }

    // Crear: Carga el formulario de creación de evento
    public IActionResult Crear()
    {
        return View();
    }

    // Crear (POST): Crea un nuevo evento asignando el IdOrganizador al usuario autenticado
    //[ValidateAntiForgeryToken]
    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> Crear(Evento evento)
    {
        var usuarioActual = await _userManager.GetUserAsync(User);
        if (usuarioActual == null)
        {
            return RedirectToAction("InicioSesion", "Auth");
        }
        evento.IdOrganizador = usuarioActual.Id;
        //if (!ModelState.IsValid)
        //{
        //    // Mostrar los errores de ModelState
        //    var errors = ModelState.Values.SelectMany(v => v.Errors);
        //    foreach (var error in errors)
        //    {
        //        Console.WriteLine(error.ErrorMessage); // O utiliza algún sistema de logs
        //    }
        //    // Regresa la vista con los errores
        //    return RedirectToAction("Index");
        //}

        _db.Eventos.Add(evento);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }


    // Editar: Carga el formulario de edición de evento
    public async Task<IActionResult> Editar(int id)
    {
        var evento = await _db.Eventos.FindAsync(id);
        if (evento == null)
        {
            return NotFound();
        }
        return View(evento);
    }

    // Editar (POST): Actualiza un evento existente
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(int id, Evento evento)
    {
        if (id != evento.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                // Validar que la fecha y hora de inicio sean anteriores a la fecha y hora de finalización
                if (evento.FechaInicio > evento.FechaFinal ||
                    (evento.FechaInicio == evento.FechaFinal && evento.HoraInicio >= evento.HoraFinal))
                {
                    ModelState.AddModelError("", "La fecha y hora de inicio deben ser anteriores a la fecha y hora de finalización.");
                    return View(evento);
                }

                // Buscar el evento existente
                var eventoExistente = await _db.Eventos.FindAsync(id);
                if (eventoExistente == null)
                {
                    return NotFound();
                }

                // Actualizar campos del evento existente
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
                eventoExistente.QRInvitacion = evento.QRInvitacion;
                eventoExistente.ActualizadoEn = DateTime.Now;  // Asigna la fecha de actualización

                _db.Update(eventoExistente);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(evento.Id))
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
        return View(evento);
    }


    // Acción para registrarse en un evento
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> RegistrarseEvento(int id)
    {
        var usuarioActual = await _userManager.GetUserAsync(User);
        if (usuarioActual == null)
        {
            return RedirectToAction("InicioSesion", "Auth");
        }

        var registro = new Registro
        {
            IdUsuario = usuarioActual.Id,
            IdEvento = id,
            FechaRegistro = DateTime.Now,
            Estado = EstadoRegistro.Registrado
        };

        _db.Registros.Add(registro);
        await _db.SaveChangesAsync();


        // Generar el URL para el código QR
        string url = $"{url1}{registro.Id}";

        registro.CodigoQrAsistencia = url;

        _db.Registros.Update(registro);
        await _db.SaveChangesAsync();

        return RedirectToAction("Index");
    }

	// Redirigir a ver el código qr
	[HttpGet]
	public async Task<IActionResult> VerQr(int idEvento)
	{
		var usuarioActual = await _userManager.GetUserAsync(User);
		if (usuarioActual == null)
		{
			return RedirectToAction("InicioSesion", "Auth");
		}

		var registro = await _db.Registros
			.Where(r => r.IdEvento == idEvento && r.IdUsuario == usuarioActual.Id)
			.FirstOrDefaultAsync();
		if (registro == null)
		{
			return NotFound();
		}

		string qrCode = Qr(registro.CodigoQrAsistencia);

		return View("~/Views/Checkin/Qr.cshtml", qrCode);
	}

	// Acción para cancelar el registro en un evento
	[HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> EliminarRegistroEvento(int id)
    {
        var usuarioActual = await _userManager.GetUserAsync(User);
        if (usuarioActual == null)
        {
            return RedirectToAction("InicioSesion", "Auth");
        }

        var registro = await _db.Registros.FirstOrDefaultAsync(r => r.IdUsuario == usuarioActual.Id && r.IdEvento == id);
        if (registro != null)
        {
            _db.Registros.Remove(registro);
            await _db.SaveChangesAsync();
        }

        return RedirectToAction("Index");
    }

    // Acción para verificar si el usuario está registrado en un evento
    [HttpGet]
    public async Task<bool> EstaRegistrado(int eventoId)
    {
        var usuarioActual = await _userManager.GetUserAsync(User);
        if (usuarioActual == null)
        {
            return false;
        }

        return await _db.Registros
            .AnyAsync(r => r.IdUsuario == usuarioActual.Id && r.IdEvento == eventoId);
    }

    // Qr: Genera codigo QR a partir de la url
    public string Qr(string texto)
    {
        QRCodeGenerator qrGenerator = new QRCodeGenerator();
        QRCodeData qrCodeData = qrGenerator.CreateQrCode(texto, QRCodeGenerator.ECCLevel.Q);
        PngByteQRCode qrCode = new PngByteQRCode(qrCodeData);
        byte[] qrCodeImage = qrCode.GetGraphic(20);
        string qr = Convert.ToBase64String(qrCodeImage);
        return qr;
    }

    // Eliminar: Carga el formulario de confirmación de eliminación
    [HttpGet]
    [Route("Eliminar/{id:int}")]
    public async Task<IActionResult> Eliminar(int id)
    {
        var evento = await _db.Eventos.FindAsync(id);
        if (evento == null)
        {
            return NotFound();
        }
        return View(evento);
    }

    // Eliminar (POST): Elimina un evento
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> ConfirmarEliminar(int id)
    {
        var evento = await _db.Eventos
            .Include(e => e.Registros) // Incluye los registros asociados
            .FirstOrDefaultAsync(e => e.Id == id);

        if (evento == null)
        {
            return NotFound();
        }

     

        // Elimina los registros asociados
        _db.Registros.RemoveRange(evento.Registros);

        // Elimina el evento
        _db.Eventos.Remove(evento);

        await _db.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool EventoExists(int id)
    {
        return _db.Eventos.Any(e => e.Id == id);
    }

   
}
