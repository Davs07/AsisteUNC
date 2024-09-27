using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AsitenciaUNC_attemp_2.Models

{
    public class Asistencia
    {
        public int Id { get; set; }
        
        public int RegistroId { get; set; }
        [ForeignKey("RegistroId")]
        public virtual Registro Registro { get; set; }

        [Required(ErrorMessage = "Ingrese la hora de entrada")]
        [DataType(DataType.DateTime)]
        public DateTime HoraEntrada { get; set; } = DateTime.Now;

    }
}
