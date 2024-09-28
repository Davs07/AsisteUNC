using AsitenciaUNC_attemp_2.Models;

namespace AsitenciaUNC_attemp_2.ViewModels
{
    public class EventDetailsVM
    {
        public Evento Evento { get; set; }
        public List<Registro> Registrados { get; set; }
        public List<Registro> Asistentes { get; set; }
    }
}
