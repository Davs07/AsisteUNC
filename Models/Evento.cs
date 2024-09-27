using AsitenciaUNC_attemp_2.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsitenciaUNC_attemp_2.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nombre del evento requerido")]
        public string Titulo { get; set; }

        [Required(ErrorMessage = "Descripción del evento requerido")]
        public string Descripcion { get; set; }

        //[Required(ErrorMessage = "Fecha del inicio del evento requerido")]
        public DateOnly? FechaInicio { get; set; }

        //[Required(ErrorMessage = "Hora de inicio del evento requerido")]
        public TimeOnly? HoraInicio { get; set; }

        //[Required(ErrorMessage = "Fecha de finalización del evento requerido")]
        public DateOnly? FechaFinal {  get; set; }

        //[Required(ErrorMessage = "Hora de finalización del evento requerido")]
        public TimeOnly? HoraFinal { get; set; }

        //[Required(ErrorMessage = "Ubicación del evento requerido")]
        public string? Ubicacion { get; set; }

        //[Required(ErrorMessage = "Capacidad del evento requerido")]
        public int? Capacidad {  get; set; }

        //[Required(ErrorMessage = "Capacidad del evento requerido")]
        public TipoEvento? Tipo { get; set; }
        //[Required(ErrorMessage = "Capacidad del evento requerido")]
        public ModalidadEnum? Modalidad { get; set; } 

		public DateTime CreadoEn { get; set; } = DateTime.Now;
		public DateTime? ActualizadoEn { get; set; }

		// Relación con el Organizador (Usuario)
		[Required(ErrorMessage = "Organizador del evento requerido")]
		public string IdOrganizador { get; set; } // Foreign key

        [ForeignKey("IdOrganizador")]
        public virtual Usuario Organizador { get; set; } // Propiedad de navegación


		public string? QRInvitacion { get; set; }


		// Relación con Registro
		public List<Registro> Registros { get; set; } = new List<Registro>();
	}
}
