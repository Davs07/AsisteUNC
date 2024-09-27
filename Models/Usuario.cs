using AsitenciaUNC_attemp_2.Enums;
using Microsoft.AspNetCore.Identity;

namespace AsitenciaUNC_attemp_2.Models
{
    public class Usuario:IdentityUser
	{
        public string Nombre { get; set; }
		public string Apellido { get; set; }
		public string CorreoElectronico { get; set; }
		public string ContrasenaHash { get; set; }
		public RolEnum Rol { get; set; }
		public DateTime CreadoEn { get; set; } = DateTime.Now;
		public DateTime? ActualizadoEn { get; set; }

        // Relación con Notificaciones
        public ICollection<Notificacion> Notificaciones { get; set; }
        // Relación con Registros
        public List<Registro> Registros { get; set; } = new List<Registro>();

		// Relación con los Eventos que organiza
		//public List<Evento> EventosOrganizados { get; set; } = new List<Evento>();
	}

}
