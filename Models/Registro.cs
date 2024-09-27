using AsitenciaUNC_attemp_2.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsitenciaUNC_attemp_2.Models
{
    public class Registro
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ingrese el ID del usuario")]
        public string IdUsuario { get; set; }
        [ForeignKey("IdUsuario")]
        public virtual Usuario Usuario { get; set; }

        [Required(ErrorMessage = "Ingrese el ID del evento")]
        public int IdEvento { get; set; }
        [ForeignKey("IdEvento")]
        public virtual Evento Evento { get; set; } // Propiedad de navegación

        [Required(ErrorMessage = "Ingrese la fecha de registro")]
        [DataType(DataType.DateTime)]
        public DateTime FechaRegistro { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Ingrese el estado")]
        public EstadoRegistro Estado { get; set; }

        public string CodigoQrAsistencia { get; set; }

        // Relación con Asistencia
        public virtual ICollection<Asistencia> Asistencias { get; set; }
    }

    public enum EstadoRegistro
    {
        [Display(Name = "Me interesa")]
        MeInteresa,
        [Display(Name = "Voy a asistir")]
        Registrado,
        [Display(Name = "Asistió")]
        Asistio,
    }
}